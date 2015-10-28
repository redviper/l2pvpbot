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
        //public string skillname;
        //public uint skillid;
        public skill useskill;
        public int condition;
        public int comparison;
        public int value;
        public override string ToString()
        {
            return useskill.name;
        }
        public uint used = 0;
    }

    public class ClientItems
    {
        public GameServer.Items item;
        public InventoryInfo inventory;
        public override string ToString()
        {
            return item.name;
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
        //public string skillname;
        //public uint skillid;
        public skill useskill;
        public int condition;
        public int comparison;
        public int value;
        public uint effect;
        public uint MP;
        public override string ToString()
        {
            return useskill.name;
        }
    }


    public class PlayerBuffs
    {
        public uint buffid;
        public Dictionary<uint, skill> bufflist;
        public string player;
        public uint objid;
        public ManualResetEvent mre;
        public uint bufftimer;
        public DateTime lastuse;
        public bool self = false;
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
        public GameT15Crypter t15crypt;
        public Queue mq;
        public Queue updateq;
        public Queue hpmq;
        public System.Threading.ManualResetEvent update_mre;
        public System.Threading.ManualResetEvent q_mre;
        public System.Threading.ManualResetEvent buff_mre;
        public System.Threading.ManualResetEvent fightbuff_mre;
        public System.Threading.ManualResetEvent sbuff_mre;
        public Object m_lock;
        private object updateq_lock;
        public bool Leader = false;
        public bool battack = false;
        public bool shiftattack = false;
        public bool skillattack = false;
        public bool defense = false;

        public shots useshot;
        public List<htmcommand> commandlist;

        public Player_Info pinfo;
        public Dictionary<uint, evtSkill> doonskill;
        public Dictionary<uint, evtSkill> doafterskill;
        DateTime oldtime;
        public uint GCP;
        public uint LCP;
        public uint GHP;
        public uint EHP_S;
        public uint EHP_A;
        public uint ECP_S;
        public uint ECP_A;
        public uint QHP;
        public List<skill> skilllist;
        public List<ClientItems> itemlist;
        public List<ClientItems> useItems;
        public object dslock, aslock;
        public BuffForm buffform;
        public ItemUseForm iform;
        Random x;
        public List<AttackSkills> askills;
        public List<DefenseSkills> dskills;

        Thread inthread, outthread, sendthread;
        public Skills asform;
        public Defense dsform;

        public Thread statusmonitor;
        public Thread updatestatusthread;
        public Thread movethread;
        public Thread singlebuffthread;
        public Thread fightbuffthread;
        public Thread itemthread;
        public int adist = 900;
        public bool blessing = false;

        //big ass hack here
        Thread PeriodicThread;
        Thread attackthread, skillthread, defendthread, buffthread, dancethread, timebuffthread;

        //buff list
        public List<PlayerBuffs> bufflist;
        public object bufflock;

        public Party pform;
        public List<PlayerBuffs> fightbufflist;
        public Fight fform;

        object dancelock;

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
                attackthread.Abort();
                singlebuffthread.Abort();
                fightbuffthread.Abort();
                dancethread.Abort();
                timebuffthread.Abort();
                buffthread.Abort();
                partythread.Abort();
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

                bufflist = new List<PlayerBuffs>();
                bufflock = new object();
                fightbufflist = new List<PlayerBuffs>();

                commandlock = new Object();
                commandlist = new List<htmcommand>(20);
                askills = new List<AttackSkills>();
                dskills = new List<DefenseSkills>();
                skilllist = new List<skill>();
                //                itemlist = new List<ClientItems>();
                doafterskill = new Dictionary<uint, evtSkill>();
                doonskill = new Dictionary<uint, evtSkill>();
                buffform = new BuffForm(this, gs);
                itemlist = new List<ClientItems>();
                useItems = new List<ClientItems>();
                m_lock = new Object();
                mq = new Queue();
                updateq = new Queue();
                updateq_lock = new Object();
                hpmq = new Queue();
                q_mre = new ManualResetEvent(false);
                update_mre = new ManualResetEvent(false);
                buff_mre = new ManualResetEvent(false);
                fightbuff_mre = new ManualResetEvent(false);
                sbuff_mre = new ManualResetEvent(false);
                item_mre = new ManualResetEvent(false);
                asform = new Skills(this, gs);
                dsform = new Defense(this, gs);
                pform = new Party(this, gs);
                fform = new Fight(this, gs);
                iform = new ItemUseForm(this, gs);
                x = new Random();
                pinfo = new Player_Info();
                aslock = new object();
                dslock = new object();
                dancelock = new object();
                initParty();
                rebuffqueue = new Queue<PlayerBuffs>();
                rebufflock = new object();
                redolist = new Queue<ReSkill>();
                redolistlock = new object();

                PeriodicThread = new Thread(PeriodicFunction);
                updatestatusthread = new Thread(this.updatestatefunc);
                skillthread = new Thread(this.skillfunction);
                defendthread = new Thread(this.defendfunction);
                attackthread = new Thread(this.attackfunction);
                buffthread = new Thread(this.bufffunction);
                movethread = new Thread(this.movepawnthread);
                statusmonitor = new Thread(this.statusmonthread);
                singlebuffthread = new Thread(this.singlebufffunction);
                fightbuffthread = new Thread(this.fightbufffunction);
                itemthread = new Thread(this.itemfunction);
                dancethread = new Thread(this.dancefunction);
                timebuffthread = new Thread(this.timebufffunction);

                inthread = new Thread(this.dataIn);
                outthread = new Thread(this.dataOut);
                sendthread = new Thread(this.sendData);

                IPEndPoint remoteGS = new IPEndPoint(IPAddress.Parse(gs.gsIP), gs.gsPort);
                proxy2server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                proxy2server.Connect(remoteGS);

                p2c = new NetworkStream(proxy2client, FileAccess.ReadWrite, true);
                p2s = new NetworkStream(proxy2server, FileAccess.ReadWrite, true);

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

                    int xkey = buffer[21] + buffer[22] * 256 + buffer[23] * 256 * 256 + buffer[24] * 256 * 256 * 256;
                    System.Console.WriteLine("Key Packet");
                    System.Console.WriteLine(buffer[21]);
                    System.Console.WriteLine(buffer[22]);
                    System.Console.WriteLine(buffer[23]);
                    System.Console.WriteLine(buffer[24]);

                    c.crypt_in = new Crypt();
                    c.crypt_out = new Crypt();
                    c.crypt_client_in = new Crypt();
                    c.crypt_client_out = new Crypt();
                    t15crypt = new GameT15Crypter();
                    t15crypt.generateOpcodeTable(xkey);
                    //t15crypt = null;

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
                buffthread.Start();
                singlebuffthread.Start();
                itemthread.Start();
                fightbuffthread.Start();
                dancethread.Start();
                timebuffthread.Start();

                PeriodicThread.Start();

            }
            catch
            {
                if (gs.leader == this)
                {
                    gs.leader = null;
                }
                if (proxy2client != null)
                    proxy2client.Close();
                if (proxy2server != null)
                    proxy2server.Close();

                gs.bwindow.d_removeClient(cv);
                if (inthread != null)
                {
                    inthread.Abort();
                    outthread.Abort();
                    sendthread.Abort();
                    updatestatusthread.Abort();
                    movethread.Abort();
                    statusmonitor.Abort();
                    if (cv != null)
                        gs.bwindow.d_removeClient(cv);
                }
            }
        }

        #region update
        uint attacking = 0;
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

                        if (packettype == 0x33)
                        {
                            //System.Console.WriteLine("attack packet");
                            data.ReadUInt32();
                            attacking = data.ReadUInt32();
                        }
                        else if (packettype == 0x1f)
                        {
                            //System.Console.WriteLine("action failed");
                        }
                        else if (packettype == 0x49)
                        {
                            //System.Console.WriteLine("skill canceled");
                        }
                        else if (packettype == 0xc7)
                        {
                            //System.Console.WriteLine("skill cool time");
                        }
                        else if (packettype == 0xb9)
                        {
                            packetMyTargetSelected(data);
                        }
                        else if (packettype == 0x24)
                        {
                            packetTargetUnselected(data);
                        }
                        else if (packettype == 0x0c)
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
                        else if (packettype == 0x48)
                        {
                            packetMagicSkillUse(data);
                        }
                        else if (packettype == 0x25)
                        {
                            //starting attack
                            //attacking = data.ReadUInt32();
                        }
                        else if (packettype == 0x26)
                        {
                            //stopping attack
                            //attacking = 0;

                        }
                        //else
                        //{
                        //    Console.WriteLine("packettype = {0}", packettype.ToString());
                        //}

                        data.SetIndex(1);
                        if (gs.leader == this)
                        {

                            if (packettype == 0x23)
                                LeaderPacket_TargetSelected(data);
                            else if (packettype == 0x0c)
                                LeaderPacket_NPCInfo(data);
                            else if (packettype == 0x24)
                                LeaderPacket_TargetUnSelected(data);
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
                                            //gs.targetselection.Interrupt();
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
                        //MessageBox.Show(E.StackTrace, "Update function thread");
                        //MessageBox.Show(E.ToString());
                    }
                }
                update_mre.Reset();

            }
        }

        private void packetTargetUnselected(ByteBuffer data)
        {
            uint tarid = data.ReadUInt32();
            if (pinfo.ObjID == tarid)
            {
                targetid = 0;
                //attackthread.Interrupt();
                //skillthread.Interrupt();
            }
        }



        private void packetMagicSkillUse(ByteBuffer data)
        {
            skill currentskill = null;
            uint charid = data.ReadUInt32();
            if (pinfo.ObjID == charid)
            {
                //our skill launched
                data.ReadUInt32();
                uint skillid = data.ReadUInt32();
                data.ReadUInt32();
                uint hittime = data.ReadUInt32();
                uint reuse = data.ReadUInt32();
                foreach (skill s in skilllist)
                {
                    if (s.id == skillid)
                    {
                        currentskill = s;
                        break;
                    }
                }
                if (currentskill != null)
                {
                    currentskill.setstate(hittime, reuse, DateTime.Now, true);
                }
            }

        }

        private void LeaderPacket_NPCInfo(ByteBuffer data)
        {
            NPC newnpc = new NPC();
            int index = data.GetIndex();
            newnpc.Load_2(data);
            //ok we have new NPC 
            //now we need to add this to the list of either mobs or NPC
            if (newnpc.isAttackable)
            {
                if (!gs.moblist.ContainsKey(newnpc.objid))
                {
                    gs.moblist.Add(newnpc.objid, newnpc);
                }
                else
                {
                    //Console.WriteLine("repeated mob");
                    data.SetIndex(index);
                    gs.moblist[newnpc.objid].Load_2(data);
                }
            }
            else
            {
                if (!gs.npclist.ContainsKey(newnpc.objid))
                {
                    gs.npclist.Add(newnpc.objid, newnpc);
                }
                else
                {
                    //Console.WriteLine("repeated npc");
                    data.SetIndex(index);
                    gs.npclist[newnpc.objid].Load_2(data);
                }
            }

        }

        private void LeaderPacket_TargetUnSelected(ByteBuffer data)
        {
            uint objid = data.ReadUInt32();
            if (objid == pinfo.ObjID)
            {
                //target unselected
                targetid = 0;
                if (this == gs.leader)
                {
                    //foreach (Client c in gs.clist)
                    //{
                    //    if (c != null)
                    //    {
                    //        c.attack_mre.Reset();
                    //        c.skill_mre.Reset();
                    //    }
                    //}
                }
            }

        }

        private void packetMyTargetSelected(ByteBuffer data)
        {
            uint objid = data.ReadUInt32();
            targetid = objid;
            if (this == gs.leader)
            {
                //foreach (Client c in gs.clist)
                //{
                //    if (c != null)
                //    {
                //        c.skill_mre.Set();
                //        c.attack_mre.Set();
                //    }
                //}
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
                    gs.leader = gs.clist[0];
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
                attackthread.Abort();
                statusmonitor.Abort();
                inthread.Abort();
                outthread.Abort();
                sendthread.Abort();
                updatestatusthread.Abort();
                movethread.Abort();
                PeriodicThread.Abort();
                skillthread.Abort();
                defendthread.Abort();
                attackthread.Abort();
                singlebuffthread.Abort();
                fightbuffthread.Abort();
                dancethread.Abort();
                timebuffthread.Abort();
                buffthread.Abort();
                partythread.Abort();

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
