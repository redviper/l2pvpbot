using System;
namespace l2pvp
{
    public partial class Client
    {
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

            while (true)
            {
                try
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
                catch (Exception e)
                {
                    System.Console.WriteLine("Bug in dataIn thread");
                    System.Console.WriteLine(e.ToString());
                    return;
                }

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

            //fix this to send message to server in seperate thread
            while (true)
            {
                try
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
                    NewMessage(buffer);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Bug in DataOut thread");
                    System.Console.WriteLine(e.ToString());
                    return;
                }
            }
        }

        void sendData()
        {

            byte[] output;

            while (true)
            {
                try
                {
                    q_mre.WaitOne();
                    while ((output = getMessage()) != null)
                    {
                        byte[] lengthbuf = BitConverter.GetBytes(output.Length + 2);
                        p2s.WriteByte(lengthbuf[0]);
                        p2s.WriteByte(lengthbuf[1]);
                        p2s.Write(output, 0, output.Length);
                    }
                    q_mre.Reset();

                }
                catch
                {
                    Console.WriteLine("Bug in senddata thread");
                    return;
                }
            }
        }

        public void NewMessage(byte[] buffer)
        {
            crypt_client_out.decrypt(buffer);
            if (buffer[0] == 0x19)
            {
                Console.WriteLine("used item buffer length\n");
                Console.WriteLine(buffer.Length);
            }
            if (buffer[0] == 0x48)
            {
                ByteBuffer b = new ByteBuffer(buffer);
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
                    pinfo.Heading = heading;
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
            lock (m_lock)
            {
                mq.Enqueue(buffer.Get_ByteArray());
            }
            q_mre.Set();
        }

        public void NewMsgHP(ByteBuffer buffer)
        {
            lock (m_lock)
            {
                hpmq.Enqueue(buffer.Get_ByteArray());
            }
            q_mre.Set();
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
                //if (output[0] == 0x09)
                //{
                //    Console.WriteLine("Sending logout packet");
                //}
                //if (output[0] == 0x46)
                //{
                //    Console.WriteLine("Sending logout packet");
                //}
                if (output[0] == 0x45)
                {
                    Console.WriteLine("Request action use");
                }
                crypt_out.encrypt(output);

                return output;
            }
            else
                return null;
        }
        #endregion

    }
}