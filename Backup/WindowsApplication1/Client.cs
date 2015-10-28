using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.IO;


namespace l2pvp
{
    public class AttackSkills
    {
        public string skillname;
        public uint skillid;
        public int condition;
        public int comparison;
        public int value;
        public override string ToString()
        {
            return skillname;
        }
    }

    public class shots
    {
        public uint id;
        public string name;
        public uint objid;

        public override string ToString()
        {
            return name;
        }
    }

    public class DefenseSkills
    {
        public string skillname;
        public uint skillid;
        public int condition;
        public int comparison;
        public int value;
        public uint effect;
        public uint MP;
        public override string ToString()
        {
            return skillname;
        }
    }

    public partial class Client
    {
        public Socket proxy2client;
        public Socket proxy2server;
        public GameServer gs;
        public ClientView cv;
        public NetworkStream p2s;
        public NetworkStream p2c;
        //public BufferedStream p2s, p2c;
        public Crypt crypt_in;
        public Crypt crypt_out;
        public Crypt crypt_client_in;
        public Crypt crypt_client_out;
        public Queue mq;
        public Queue updateq;
        public Queue hpmq;
        public System.Threading.ManualResetEvent update_mre;
        public System.Threading.ManualResetEvent q_mre;
        public Object m_lock;
        private object updateq_lock;
        public bool Leader = false;
        public bool battack = false;
        public bool shiftattack = false;
        public bool skillattack = false;
        public bool defense = false;

        public shots useshot;

        public Player_Info pinfo;
        public Dictionary<uint, uint> doonskill;
        public Dictionary<uint, uint> doafterskill;
        DateTime oldtime;
        public uint GCP;
        public uint LCP;
        public uint GHP;
        public uint EHP_S;
        public uint EHP_A;
        public uint ECP_S;
        public uint ECP_A;
        public uint QHP;
        public List<uint> skilllist;
        public object dslock, aslock;
        public BuffForm buffform;
        Random x;
        public List<AttackSkills> askills;
        public List<DefenseSkills> dskills;

        Thread inthread, outthread, sendthread;
        public Skills asform;
        public Defense dsform;

        public Thread statusmonitor;
        public Thread updatestatusthread;
        public Thread movethread;
        public int adist = 900;
        public bool blessing = false;

//big ass hack here
        Thread PeriodicThread;
        Thread attackthread, skillthread, defendthread;

        ~Client()
        {
            try
            {
                statusmonitor.Abort();
                inthread.Abort();
                outthread.Abort();
                sendthread.Abort();
                updatestatusthread.Abort();
                movethread.Abort();
                PeriodicThread.Abort();
                skillthread.Abort();
                defendthread.Abort();
            }
            catch
            {
            }

        }
        public Client(Socket _socket, GameServer _gs)
        {
            try
            {
                gs = _gs;
                proxy2client = _socket;
                cv = new ClientView(this);
                gs.bwindow.SuspendLayout();
                gs.bwindow.d_addClient(cv);
                gs.bwindow.ResumeLayout(true);

                askills = new List<AttackSkills>();
                dskills = new List<DefenseSkills>();
                skilllist = new List<uint>();
                doafterskill = new Dictionary<uint, uint>();
                doonskill = new Dictionary<uint, uint>();
                buffform = new BuffForm(this, gs);
                m_lock = new Object();
                mq = new Queue();
                updateq = new Queue();
                updateq_lock = new Object();
                hpmq = new Queue();
                q_mre = new ManualResetEvent(false);
                update_mre = new ManualResetEvent(false);
                asform = new Skills(this, gs);
                dsform = new Defense(this, gs);
                x = new Random();
                pinfo = new Player_Info();
                aslock = new object();
                dslock = new object();

                PeriodicThread = new Thread(PeriodicFunction);
                updatestatusthread = new Thread(this.updatestatefunc);
                skillthread = new Thread(this.skillfunction);
                defendthread = new Thread(this.defendfunction);
                attackthread = new Thread(this.attackfunction);
                movethread = new Thread(this.movepawnthread);
                statusmonitor = new Thread(this.statusmonthread);

                inthread = new Thread(this.dataIn);
                outthread = new Thread(this.dataOut);
                sendthread = new Thread(this.sendData);

                IPEndPoint remoteGS = new IPEndPoint(IPAddress.Parse(gs.gsIP), gs.gsPort);
                proxy2server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                proxy2server.Connect(remoteGS);

                p2c =new NetworkStream(proxy2client,FileAccess.ReadWrite, true);
                p2s =new NetworkStream(proxy2server, FileAccess.ReadWrite, true);

                {
                    Client c = (Client)this;
                    byte[] buffer;
                    int length = 0;
                    int lenlo = c.p2c.ReadByte();
                    int lenhi = c.p2c.ReadByte();

                    length = lenhi * 256 + lenlo;

                    buffer = new byte[length];
                    buffer[0] = (byte)lenlo;
                    buffer[1] = (byte)lenhi;
                    buffer[2] = (byte)10;
                    c.p2c.Read(buffer, 2, length - 2);
                    c.p2s.Write(buffer, 0, length);

                    lenlo = c.p2s.ReadByte();
                    lenhi = c.p2s.ReadByte();
                    length = lenhi * 256 + lenlo;
                    buffer = new byte[length];
                    buffer[0] = (byte)lenlo;
                    buffer[1] = (byte)lenhi;

                    c.p2s.Read(buffer, 2, length - 2);

                    byte[] key = new byte[16];

                    key[0] = buffer[4];
                    key[1] = buffer[5];
                    key[2] = buffer[6];
                    key[3] = buffer[7];
                    key[4] = buffer[8];
                    key[5] = buffer[9];
                    key[6] = buffer[10];
                    key[7] = buffer[11];
                    key[8] = (byte)0xc8;
                    key[9] = (byte)0x27;
                    key[10] = (byte)0x93;
                    key[11] = (byte)0x01;
                    key[12] = (byte)0xa1;
                    key[13] = (byte)0x6c;
                    key[14] = (byte)0x31;
                    key[15] = (byte)0x97;

                    c.crypt_in = new Crypt();
                    c.crypt_out = new Crypt();
                    c.crypt_client_in = new Crypt();
                    c.crypt_client_out = new Crypt();

                    //crypt for data from server
                    c.crypt_in.setKey(key);
                    //crypt for data to server
                    c.crypt_out.setKey(key);
                    //crypt for data from client
                    c.crypt_client_out.setKey(key);
                    //crypt for data to client
                    c.crypt_client_in.setKey(key);

                    // Console.WriteLine(length);
                    c.p2c.Write(buffer, 0, length);

                }
                System.Console.WriteLine("got keys");
                if (gs.leader == null)
                    gs.leader = this;


                //inthread.Priority = ThreadPriority.BelowNormal;
                //outthread.Priority = ThreadPriority.BelowNormal;

                outthread.Name = "outthread";
                inthread.Name = "inthread";
                sendthread.Name = "sendthread";

                outthread.Start();
                inthread.Start();
                sendthread.Start();
                updatestatusthread.Start();

                
                statusmonitor.Start();
                movethread.Start();
                attackthread.Start();
                defendthread.Start();
                skillthread.Start();

 
                PeriodicThread.Start();
            }
            catch
            {
                if (gs.leader == this)
                {
                    gs.leader = null;
                }
                proxy2client.Close();
                proxy2server.Close();

                gs.bwindow.d_removeClient(cv);
                inthread.Abort();
                outthread.Abort();
                sendthread.Abort();
                updatestatusthread.Abort();
                movethread.Abort();
                statusmonitor.Abort();
                if(cv != null)
                    gs.bwindow.d_removeClient(cv);

            }
        }

        #region update
        public void updatestatefunc()
        {
            ByteBuffer data;

            while (true)
            {
                update_mre.WaitOne();
                while (true)
                {

                    try
                    {
                        lock (updateq_lock)
                        {
                            if (updateq.Count == 0)
                                break;
                            data = (ByteBuffer)updateq.Dequeue();
                            if (data == null)
                                break;
                        }

                        byte packettype = data.ReadByte();
                        //System.Console.WriteLine("SErver sent {0}", packettype);

                        if (packettype == 0x0c)
                        {
                            packetNpcInfo(data);
                        }
                        else if (packettype == 0x32)
                        {
                            packetPCInfo(data);
                        }
                        else if (packettype == 0x11)
                        {
                            packetItemList(data);
                        }
                        else if (packettype == 0x21)
                        {
                            packetInventoryUpdate(data);
                        }
                        else if (packettype == 0x18)
                        {
                            packetStatusUpdate(data);
                        }
                        else if (packettype == 0x5f)
                        {
                            packetSkillList(data);
                        }
                        else if (packettype == 0x5f)
                        {
                            packetSkillList(data);
                        }
                        else if (packettype == 0xf4)
                            packetShortBuffStautsUpdate(data);
                        else if (packettype == 0x62)
                            packetSystemMessage(data);
                        else if (packettype == 0x01)
                        {
                            //revive
                            uint objid = data.ReadUInt32();
                            if (gs.deadlist.ContainsKey(objid))
                                gs.deadlist.Remove(objid);

                            if (gs.allplayerinfo.ContainsKey(objid))
                            {
                                gs.allplayerinfo[objid].isAlikeDead = 0;
                            }
                        }

                        data.SetIndex(1);
                        if (gs.leader == this)
                        {
                            if (packettype == 0x23)
                                LeaderPacket_TargetSelected(data);
                            else if (packettype == 0x62)
                                LeaderPacket_SystemMessage(data);
                            else if (packettype == 0x31)
                                LeaderPacket_CharInfo(data);
                            else if (packettype == 0x2f)
                                LeaderPacket_MoveToLocation(data);
                            else if (packettype == 0x72)
                                LeaderPacket_MoveToPawn(data);
                            else if (packettype == 0x47)
                                LeaderPacket_StopMove(data);
                            else if (packettype == 0x89)
                                LeaderPacket_PledgeInfo(data);
                            else if (packettype == 0x08)
                                LeaderPacket_DeleteObject(data);
                            else if (packettype == 0xce)
                            {
                                uint objid = data.ReadUInt32();
                                int relation = data.ReadInt32();
                                int auto = data.ReadInt32();
                                int karma = data.ReadInt32();
                                int pvpflag = data.ReadInt32();
                                try
                                {
                                    CharInfo c = gs.allplayerinfo[objid];
                                    c.relation = relation;
                                    c.rkarma = karma;
                                    c.rauto = auto;
                                    c.rpvpflag = pvpflag;
                                    if ((c.relation & 0x08000) != 0)
                                    {
                                        //two way war!
                                        if (gs.kill2waywar == true)
                                        {
                                            if (!gs.enemylist.ContainsKey(c.ID))
                                            {
                                                gs.enemylist.Add(c.ID, c);
                                            }
                                        }

                                        if (gs.enemylist.ContainsKey(objid))
                                        {
                                            //in enemy list .. wake up thread
                                            gs.targetselection.Interrupt();
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }

                        }
                        else
                        {
                            if (packettype == 0x47)
                                packetStopMove(data);
                            else if (packettype == 0x2f)
                                packetMoveToLocation(data);
                        }
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.StackTrace, "Update function thread");
                    }
                }
                update_mre.Reset();

            }
        }


        uint bsoeid = 0;

        #endregion

        protected int listdis = 2000;

        public void logout()
        {
            try
            {
                if (gs.leader == this)
                {
                    gs.leader = null;
                }
                try
                {
                    gs.clist.Remove(this);
                }
                catch
                {
                }
                //send logout packet
                proxy2client.Close();
                proxy2server.Close();
                

                statusmonitor.Abort();
                inthread.Abort();
                outthread.Abort();
                sendthread.Abort();
                updatestatusthread.Abort();
                movethread.Abort();
                PeriodicThread.Abort();
                skillthread.Abort();
                defendthread.Abort();
                gs.bwindow.d_removeClient(cv);
            }
            catch
            {

            }
        }

        public void setLeader()
        {
            gs.leader = this;
        }

        public static double convertHeadingToDegree(int heading)
        {
            if (heading == 0) return 360;
            return 9.0 * (heading / 1610.0); // = 360.0 * (heading / 64400.0)
        }
    }

}
