using System;
namespace l2pvp
{
    public partial class Client
    {
        int validateposencrypted = -1;
        #region msghandling
        void dataIn()
        {
            //read from server, pass to client
            byte[] buffer;
            int length = 0;
            int lenlo = 0;
            int lenhi = 0;
            int curread = 0;
            byte[] output;
            try
            {
                while (true)
                {


                    lenlo = p2s.ReadByte();
                    lenhi = p2s.ReadByte();
                    length = lenhi * 256 + lenlo;
                    buffer = new byte[length - 2];
                    curread = 0;
                    while (curread < length - 2)
                    {
                        curread += p2s.Read(buffer, curread, length - curread - 2);
                    }
                    output = UpdateState(buffer);
                    p2c.WriteByte((byte)lenlo);
                    p2c.WriteByte((byte)lenhi);
                    p2c.Write(output, 0, length - 2);
                    buffer = null;
                    output = null;



                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Bug in dataIn thread");
                System.Console.WriteLine(e.ToString());
                if (!gs.clist.Contains(this))
                    return;
            }
        }

        void dataOut()
        {
            //read from client, pass to server
            byte[] buffer;
            int length = 0;
            int lenlo = 0;
            int lenhi = 0;
            int curread = 0;
            try
            {
                //fix this to send message to server in seperate thread
                while (true)
                {

                    lenlo = p2c.ReadByte();
                    lenhi = p2c.ReadByte();
                    length = lenhi * 256 + lenlo;
                    buffer = new byte[length - 2];
                    curread = 0;
                    while (curread < length - 2)
                    {
                        curread += p2c.Read(buffer, curread, length - curread - 2);
                    }
                    NewMessageByPass(buffer);


                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Bug in DataOut thread");
                System.Console.WriteLine(e.ToString());
            }
        }
        public object msglock = new object();
        void sendData()
        {

            byte[] output;
            try
            {
                while (true)
                {

                    q_mre.WaitOne();
                    q_mre.Reset();

                    while ((output = getMessage()) != null)
                    {
                        //System.Console.WriteLine("{0}", output.Length);
                        byte[] lengthbuf = BitConverter.GetBytes(output.Length + 2);
                        p2s.WriteByte(lengthbuf[0]);
                        p2s.WriteByte(lengthbuf[1]);
                        p2s.Write(output, 0, output.Length);
                    }



                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Bug in senddata thread {0}", e.ToString());
                //System.Windows.Forms.MessageBox.Show("Bug in dataIn thread" + e.ToString());
            }
        }
        public int htmlmsgid = -1;
        public void NewMessageByPass(byte[] buffer)
        {

            //no obfuscation needed
            //check use item buffer
            //byte original = buffer[0];
            //t15crypt.decrypt(buffer);
            //byte first = buffer[0];
            //t15crypt.encrypt(buffer);
            //byte last = buffer[0];
            //Console.WriteLine("Packet IDs = {0}, {1}, {2}", original, first, last);
            //if (buffer.Length > 3 && buffer[0] < 0xd1 )
            //{
            //    byte[] decoded = new byte[3];
            //    Array.Copy(buffer, decoded, 3);
            //    if (t15crypt != null)
            //    {
            //        t15crypt.decrypt(decoded);
            //        if (decoded[0] == 0x19)
            //        {
            //            Console.WriteLine("use item called {0}", buffer.Length);
            //        }
            //    }
            //}
            crypt_client_out.decrypt(buffer);
            if (t15crypt != null)
            {
                //make a copy of buffer and then do stuff on it instead of real buffer!

                if (validateposencrypted == -1)
                {
                    byte[] temp = new byte[buffer.Length];
                    buffer.CopyTo(temp, 0);

                    t15crypt.decrypt(temp);
                    if (temp[0] == 89)//validate position
                    {
                        ByteBuffer b = new ByteBuffer(temp);
                        byte type = b.ReadByte();
                        int x = b.ReadInt32();
                        int y = b.ReadInt32();
                        int z = b.ReadInt32();
                        int heading = b.ReadInt32();
                        int data = b.ReadInt32();
                        if (pinfo != null)
                        {
                            pinfo.X = x;
                            pinfo.Y = y;
                            pinfo.Z = z;
                            pinfo.Airship = heading;
                        }
                        validateposencrypted = buffer[0];
                    }
                }
                else if (buffer[0] == validateposencrypted)
                {
                    //only decrypt if it matches
                    byte[] temp = new byte[buffer.Length];
                    buffer.CopyTo(temp, 0);


                    t15crypt.decrypt(temp);
                    if (temp[0] == 89)//validate position
                    {
                        ByteBuffer b = new ByteBuffer(temp);
                        byte type = b.ReadByte();
                        int x = b.ReadInt32();
                        int y = b.ReadInt32();
                        int z = b.ReadInt32();
                        int heading = b.ReadInt32();
                        int data = b.ReadInt32();
                        if (pinfo != null)
                        {
                            pinfo.X = x;
                            pinfo.Y = y;
                            pinfo.Z = z;
                            pinfo.Airship = heading;
                        }
                    }
                }
                if (this == gs.leader)
                {
                    if (htmlmsgid == -1)
                    {
                        //never been decrypted before
                        byte[] temp = new byte[buffer.Length];
                        buffer.CopyTo(temp, 0);


                        t15crypt.decrypt(temp);
                        if (temp[0] == 0x23)
                        {
                            ByteBuffer b = new ByteBuffer(buffer);
                            byte x = b.ReadByte();
                            htmcommand h = new htmcommand();
                            h.s = b.ReadString();
                            h.t = DateTime.Now;
                            h.currenttarget = this.targetid;

                            htmlmsgid = buffer[0];
                        }
                    }
                    else if (buffer[0] == htmlmsgid)
                    {
                        byte[] temp = new byte[buffer.Length];
                        buffer.CopyTo(temp, 0);

                        t15crypt.decrypt(temp);
                        if (temp[0] == 0x23)
                        {
                            ByteBuffer b = new ByteBuffer(temp);
                            byte x = b.ReadByte();
                            htmcommand h = new htmcommand();
                            h.s = b.ReadString();
                            h.t = DateTime.Now;
                            h.currenttarget = this.targetid;
                            foreach (Client c in gs.clist)
                            {
                                if (c != this)
                                {
                                    lock (c.commandlock)
                                    {
                                        c.commandlist.Add(h);
                                    }
                                }
                            }
                        }

                    }

                }
            }
            lock (m_lock)
            {
                mq.Enqueue(buffer);
            }
            q_mre.Set();
        }

        public byte[] UpdateState(byte[] buffer)
        {
            //this buffer is encrypted with crypt_in key - decrypt it 
            crypt_in.decrypt(buffer);
            //buffer is decrypted in place
            //0x04 - user info packet
            //0x03 - char info packet
            //0x01 - char move to location packet
            //0x27 - inventory update packet [not needed for now]
            //0x83 - clan info
            //0x0e - status update
            if (buffer[0] == 0x0b)
            {
                System.Console.WriteLine("char selected packet");
                System.Console.WriteLine(buffer[buffer.Length - 4]);
                System.Console.WriteLine(buffer[buffer.Length - 3]);
                System.Console.WriteLine(buffer[buffer.Length - 2]);
                System.Console.WriteLine(buffer[buffer.Length - 1]);
                int xkey = BitConverter.ToInt32(buffer, buffer.Length - 4);
                t15crypt = new GameT15Crypter();
                t15crypt.generateOpcodeTable(xkey);
            }
            ByteBuffer data = new ByteBuffer(buffer);
            lock (updateq_lock)
            {
                updateq.Enqueue((object)data);
                update_mre.Set();
            }
            //buffer is currently decrypted it
            //encrypt it with crypt_client_in
            crypt_client_in.encrypt(buffer);
            return buffer;
        }

        public void NewMessage(ByteBuffer buffer)
        {
            //need to obfuscate
            //no ex obfuscation right now!
            //if (t15crypt != null)
            //{
            //    byte b = buffer[0];
            //    t15crypt.decrypt(buffer);
            //    byte a = buffer[0];
            //    t15crypt.encrypt(buffer);
            //    System.Console.WriteLine("In = {0}, middle = {1} out = {2}", b, a, buffer[0]);
            //}
            byte[] data = buffer.Get_ByteArray();
            if (t15crypt != null)
            {
                t15crypt.encrypt(data);
                lock (m_lock)
                {
                    mq.Enqueue(data);
                }
                q_mre.Set();
            }
        }

        public void NewMessageBypass(ByteBuffer buffer)
        {
            //do not obfuscate opcode
            lock (m_lock)
            {
                mq.Enqueue(buffer.Get_ByteArray());
            }
            q_mre.Set();
        }

        public void NewMsgHP(ByteBuffer buffer)
        {
            if (t15crypt != null)
            {
                byte[] data = buffer.Get_ByteArray();
                t15crypt.encrypt(data);
                lock (m_lock)
                {
                    hpmq.Enqueue(data);
                }
                q_mre.Set();
            }
        }

        public byte[] getMessage()
        {
            byte[] output;
            if (hpmq.Count > 0)
            {
                lock (m_lock)
                {
                    output = (byte[])hpmq.Dequeue();
                }
                crypt_out.encrypt(output);
                return output;

            }
            else if (mq.Count > 0)
            {
                lock (m_lock)
                {
                    output = (byte[])mq.Dequeue();
                }
                crypt_out.encrypt(output);
                return output;
            }
            else
                return null;
        }
        #endregion
        //if (decoded[0] == 0x48)
        //{
        //    ByteBuffer b = new ByteBuffer(buffer);
        //    byte type = b.ReadByte();
        //    int x = b.ReadInt32();
        //    int y = b.ReadInt32();
        //    int z = b.ReadInt32();
        //    int heading = b.ReadInt32();
        //    int data = b.ReadInt32();
        //    if (pinfo != null)
        //    {
        //        pinfo.X = x;
        //        pinfo.Y = y;
        //        pinfo.Z = z;
        //        pinfo.Airship = heading;
        //    }
        //}

        bool loaded = false;

        public void loadClientConfiguration()
        {

            string username = pinfo.Name;
            string gname = gs.global;
            string temp;

            temp = "dance-" + username + gname;
            if (System.IO.File.Exists(temp))
            {
                buffform.loadconfig_d(temp);
            }

            temp = "defend-" + username + gname;
            if (System.IO.File.Exists(temp))
            {
                dsform.loadconfig_d(temp);
            }

            temp = "fight-" + username + gname;
            if (System.IO.File.Exists(temp))
            {
                fform.loadconfig_d(temp);
            }

            temp = "buffs-" + username + gname;
            if (System.IO.File.Exists(temp))
            {
                lock (bufflock)
                {
                    pform.loadconfig_d(temp);
                }
            }

            temp = "skills-" + username + gname;
            if (System.IO.File.Exists(temp))
            {
                asform.loadconfig_d(temp);
            }
        }

        public void saveConfiguration()
        {
            if (pinfo.ObjID == 0)
                return;
            string username = pinfo.Name;

            string gname = gs.global;

            string temp;

            temp = "dance-" + username + gname;
            buffform.saveConfig(temp);

            temp = "defend-" + username + gname;
            dsform.saveConfig(temp);

            temp = "fight-" + username + gname;
            fform.saveConfig(temp);

            temp = "buffs-" + username + gname;
            pform.saveConfig(temp);

            temp = "skills-" + username + gname;
            asform.saveConfig(temp);
        }
    }


}