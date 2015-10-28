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
    public class Clans
    {
        public uint id;
        public string name;
        public string ally;
        public bool enemy;
        public override string ToString()
        {
            return name;
        }

    }


    public class skill
    {
        public string name;
        public uint id;

        public DateTime lastuse;
        public uint hitTime;
        public uint reuseDelay;
        public ManualResetEvent mre;
        public override string ToString()
        {
            return name;
        }


        public bool succeed;
        object skilllock;
        public skill()
        {
            succeed = false;
            skilllock = new object();
        }

        public bool skillstate()
        {
            lock (skilllock)
            {
                return succeed;
            }
        }

        public void setstate(bool state)
        {
            lock (skilllock)
            {
                succeed = state;
            }
        }

        public void setstate(uint hittime, uint reuse, DateTime time, bool state)
        {
            lock (skilllock)
            {
                hitTime = hittime;
                lastuse = time;
                reuseDelay = reuse;
                succeed = state;
                mre.Set();
            }
        }

    }


    public class GameServer
    {
        //constructor
        public bool usebsoe = false;
        public bool allbsoe = false;
        public bool battack;
        public bool distanceupdates;
        public BotView bwindow;
        public bool bPercentRecover = false;
        public double PercentRecover = 80;

        public string[] charClasses = {
                                                "Human Fighter", "Warrior", "Gladiator", "Warlord", "Human Knight", "Paladin", "Dark Avenger", "Rogue", "Treasure Hunter", "Hawkeye", "Human Mystic", "Human Wizard", "Sorceror", "Necromancer", "Warlock", "Cleric", "Bishop", "Prophet",
                                                "Elven Fighter", "Elven Knight", "Temple Knight", "Swordsinger", "Elven Scout", "Plainswalker", "Silver Ranger", "Elven Mystic", "Elven Wizard", "Spellsinger", "Elemental Summoner", "Elven Oracle", "Elven Elder",
                                                "Dark Fighter", "Palus Knight", "Shillien Knight", "Bladedancer", "Assassin", "Abyss Walker", "Phantom Ranger", "Dark Elven Mystic", "Dark Elven Wizard", "Spellhowler", "Phantom Summoner", "Shillien Oracle", "Shillien Elder",
                                                "Orc Fighter", "Orc Raider", "Destroyer", "Orc Monk", "Tyrant", "Orc Mystic", "Orc Shaman", "Overlord", "Warcryer",
                                                "Dwarven Fighter", "Dwarven Scavenger", "Bounty Hunter", "Dwarven Artisan", "Warsmith",
                                                "dummyEntry1", "dummyEntry2", "dummyEntry3", "dummyEntry4", "dummyEntry5", "dummyEntry6", "dummyEntry7", "dummyEntry8", "dummyEntry9", "dummyEntry10", "dummyEntry11", "dummyEntry12", "dummyEntry13", "dummyEntry14", "dummyEntry15",
                                                "dummyEntry16", "dummyEntry17", "dummyEntry18", "dummyEntry19", "dummyEntry20", "dummyEntry21", "dummyEntry22", "dummyEntry23", "dummyEntry24", "dummyEntry25", "dummyEntry26", "dummyEntry27", "dummyEntry28", "dummyEntry29", "dummyEntry30",
                                                "Duelist", "DreadNought", "Phoenix Knight", "Hell Knight", "Sagittarius", "Adventurer",
                                                "Archmage", "Soultaker", "Arcana Lord", "Cardinal", "Hierophant",
                                                "Eva Templar", "Sword Muse", "Wind Rider", "Moonlight Sentinel", "Mystic Muse", "Elemental Master", "Eva's Saint",
                                                "Shillien Templar", "Spectral Dancer", "Ghost Hunter", "Ghost Sentinel", "Storm Screamer", "Spectral Master", "Shillien Saint",
                                                "Titan", "Grand Khauatari", "Dominator", "Doomcryer",
                                                "Fortune Seeker", "Maestro"};

        public enum EffectType
        {
            BUFF, CHARGE, DMG_OVER_TIME, HEAL_OVER_TIME, COMBAT_POINT_HEAL_OVER_TIME, MANA_DMG_OVER_TIME, MANA_HEAL_OVER_TIME, RELAXING, STUN, ROOT, SLEEP, HATE, FAKE_DEATH, CONFUSION, CONFUSE_MOB_ONLY, MUTE, FEAR, SILENT_MOVE, SEED, PARALYZE, STUN_SELF, PSYCHICAL_MUTE, REMOVE_TARGET, TARGET_ME
        }

        public int sleepeffect = 128;
        public int root = 512;
        public int medusastate = 2048;
        public bool buffs = false;
        public List<Client> clist;
        public string global = "";

        //Pots
        public bool cppots = true;
        public bool ghppots = true;
        public bool elixir = true;
        public bool qhp = false;
        public uint cpelixir = 1000, hpelixir = 2000, ghphp = 400, qhphp = 2500;

        public List<shots> shotlist;

        //clans
        public Dictionary<uint, Clans> clanlist;
        public Dictionary<uint, Clans> enemyclans;

        //players
        public Dictionary<uint, CharInfo> allplayerinfo;
        public Dictionary<uint, CharInfo> playerlist;
        public Dictionary<uint, CharInfo> attacklist;
        public Dictionary<uint, CharInfo> enemylist;
        public Dictionary<uint, CharInfo> deadlist;
        public CharInfo target = null;
        public List<uint> deletedenemies;
        public List<string> enemynames;

        public class Items
        {
            public uint id;
            public string name;

            public override string ToString()
            {
                return name;
            }

        }

        public class WatchedPlayers
        {
            public uint objid;
            public string name;
            public uint cp, maxcp;
            public uint hp, maxhp;
            public uint mp, maxmp;

            public override string ToString()
            {
                return name;
            }

        }

        public Dictionary<uint, WatchedPlayers> wlist;

        //network
        public TcpListener gsListen;
        public string gsIP;
        public int gsPort;

        //skills
        public Dictionary<uint, skillmap> skills;
        public string Targetter;
        public uint TargetterID = 0;
        //purg protection
        public uint PurgId = 0xffffffff;
        public uint LPid = 0xfffffff;
        public uint MimrId = 0xffffff;

        public bool autofollow = false;
        public bool autotalk = false;
        public Int32 talkdelay = 1;
        //leader
        public Client leader;
        public Thread targetselection;

        //command strings
        public List<string> commandlists;

        public int AttackDistance = 1200;

        public bool AssistLeader = false;

        public Dictionary<uint, Client.NPC> npclist;
        public Dictionary<uint, Client.NPC> moblist;
        public Dictionary<uint, Items> itemlist;


        public GameServer(string _gsIP, int _gsPort, string _lip)
        {
            IPAddress localip = IPAddress.Parse(_lip);
            // Console.WriteLine(localip.ToString());
            gsListen = new TcpListener(System.Net.IPAddress.Any, 7777);
            gsIP = _gsIP;
            gsPort = _gsPort;

            commandlists = new List<string>(128);

            //initialize members
            clanlist = new Dictionary<uint, Clans>();
            enemyclans = new Dictionary<uint, Clans>();
            allplayerinfo = new Dictionary<uint, CharInfo>();
            playerlist = new Dictionary<uint, CharInfo>();
            attacklist = new Dictionary<uint, CharInfo>();
            enemylist = new Dictionary<uint, CharInfo>();
            deadlist = new Dictionary<uint, CharInfo>();
            wlist = new Dictionary<uint, WatchedPlayers>();
            deletedenemies = new List<uint>();
            enemynames = new List<string>();
            distanceupdates = true;
            targetselection = new Thread(this.selectTarget);
            target = null;

            npclist = new Dictionary<uint, Client.NPC>();
            moblist = new Dictionary<uint, Client.NPC>();

            shotlist = new List<shots>();
            {
                StreamReader sReader = new StreamReader(new FileStream("shotid.txt", FileMode.Open,
                    FileAccess.Read, FileShare.Read), Encoding.UTF8);

                while (true)
                {
                    string line = sReader.ReadLine();
                    if (line == null)
                        break;
                    char[] sep = new char[4];
                    sep[0] = '=';
                    sep[1] = '[';
                    sep[2] = ']';
                    sep[3] = '\t';
                    string[] split = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    //id = 2, name = 4
                    shots _s = new shots();
                    _s.id = Convert.ToUInt32(split[2]);
                    _s.name = split[4];

                    shotlist.Add(_s);
                }
            }
            robeids = new List<uint>();
            lightarmor = new List<uint>();
            {
                StreamReader lReader = new StreamReader(new FileStream("armor.sql", FileMode.Open,
                    FileAccess.Read, FileShare.Read), Encoding.UTF8);
                while (true)
                {
                    string line = lReader.ReadLine();
                    if (line == null)
                        break;
                    if (line.Contains("--"))
                        continue;
                    if (line.Length < 6)
                        continue;
                    char[] sep = new char[4];
                    sep[0] = '('; sep[1] = ')'; sep[2] = ','; sep[3] = ';';
                    string[] splits = line.Split(sep, 6, StringSplitOptions.RemoveEmptyEntries);
                    if (splits[4] == "\'magic\'")
                    {
                        robeids.Add(Convert.ToUInt32(splits[0]));
                    }
                    if (splits[4] == "\'light\'")
                    {
                        lightarmor.Add(Convert.ToUInt32(splits[0]));
                    }

                }
            }
            Console.WriteLine("{0} in robe and {1} in light", robeids.Count, lightarmor.Count);

            itemlist = new Dictionary<uint, Items>();
            {
                StreamReader lReader = new StreamReader(new FileStream("etcitem.sql", FileMode.Open,
                    FileAccess.Read, FileShare.Read), Encoding.UTF8);
                while (true)
                {
                    string line = lReader.ReadLine();
                    if (line == null)
                        break;
                    if (line.Contains("--"))
                        continue;
                    if (line.Length < 6)
                        continue;
                    char[] sep = new char[4];
                    sep[0] = '('; sep[1] = ')'; sep[2] = ','; sep[3] = ';';
                    string[] splits = line.Split(sep, 6, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        Items i = new Items();
                        i.id = Convert.ToUInt32(splits[0]);
                        i.name = splits[1];
                        itemlist.Add(i.id, i);

                    }
                    catch
                    {
                    }
                }
            }

            Console.WriteLine("Item count = {0}", itemlist.Count);

            skills = new Dictionary<uint, skillmap>();
            {
                StreamReader lReader = new StreamReader(new FileStream("skill_trees.sql", FileMode.Open,
                    FileAccess.Read, FileShare.Read), Encoding.UTF8);
                while (true)
                {
                    string line = lReader.ReadLine();
                    if (line == null)
                        break;
                    if (line.Contains("--"))
                        continue;
                    if (line.Length < 6)
                        continue;
                    char[] sep = new char[5];
                    sep[0] = '('; sep[1] = ')'; sep[2] = ','; sep[3] = '\''; sep[4] = ';';
                    string[] splits = line.Split(sep, 6, StringSplitOptions.RemoveEmptyEntries);
                    uint skillid = Convert.ToUInt32(splits[1]);
                    skillmap s = new skillmap();
                    s.id = skillid;
                    s.name = splits[3];
                    if (!skills.ContainsKey(skillid))
                        skills.Add(skillid, s);

                }
            }

            clist = new List<Client>();
            leader = null;
            //start UI thread
            bwindow = new BotView(this);
            bwindow.Show();
        }
        public bool flagfight = false;
        public bool kill2waywar = false;

        public List<uint> robeids;
        public List<uint> lightarmor;
        public void selectTarget()
        {
            while (true)
            {
                try
                {
                    if (battack == false)
                    {
                        Thread.Sleep(50);
                        continue;
                    }
                    CharInfo[] elist = null;
                    target = null;
                    do
                    {
                        try
                        {
                            elist = new CharInfo[enemylist.Count];

                            enemylist.Values.CopyTo(elist, 0);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    while (false);
                    //FIRST PASS - ROBE ARMORS
                    foreach (CharInfo temp in elist)
                    {
                        if (temp == null)
                            continue;

                        if (flagfight == true)
                            if (temp.rpvpflag == 0 && (temp.relation & 0x00002) != 0
                            && ((temp.relation & 0x080000) != 0))
                                continue;


                        if (deadlist.ContainsKey(temp.ID))
                        {
                            if (temp.isAlikeDead == 0)
                            {
                                deadlist.Remove(temp.ID);
                            }
                            else
                                continue;
                        }

                        if (temp != null && temp.isAlikeDead == 1)
                        {
                            if (!deadlist.ContainsKey(temp.ID))
                            {
                                deadlist.Add(temp.ID, temp);
                            }
                            continue;
                        }


                        if (!robeids.Contains(temp.Chest))
                        {
                            //is not a robe user
                            continue;
                        }

                        if (temp != null && temp.distance < AttackDistance &&
                            ((temp.AbnormalEffects & medusastate) == 0)
                            && temp.isAlikeDead != 1 && temp.peace != 1)
                        {
                            if (target == null)
                            {
                                target = temp;
                            }
                            if (temp.distance < target.distance)
                            {
                                target = temp;
                            }
                        }

                    }

                    //2nd pass - light armors
                    if (target == null)
                    {
                        foreach (CharInfo temp in elist)
                        {
                            if (temp == null)
                                continue;
                            if (flagfight == true && temp != null)
                                if (temp.rpvpflag == 0 && (temp.relation & 0x00002) != 0
                                && ((temp.relation & 0x080000) != 0))
                                    continue;

                            if (deadlist.ContainsKey(temp.ID))
                            {
                                if (temp.isAlikeDead == 0)
                                {
                                    deadlist.Remove(temp.ID);
                                }
                                else
                                    continue;
                            }

                            if (temp != null && temp.isAlikeDead == 1)
                            {
                                if (!deadlist.ContainsKey(temp.ID))
                                {
                                    deadlist.Add(temp.ID, temp);
                                }
                                continue;
                            }

                            if (temp != null && !lightarmor.Contains(temp.Chest))
                            {
                                //is not a robe user
                                continue;
                            }
                            if (temp != null && temp.distance < AttackDistance &&
                                ((temp.AbnormalEffects & medusastate) == 0)
                                && temp.isAlikeDead != 1 && temp.peace != 1)
                            {
                                if (target == null)
                                {
                                    target = temp;
                                }
                                if (temp.distance < target.distance)
                                {
                                    target = temp;
                                }
                            }
                        }
                    }
                    //3rd pass closest
                    if (target == null)
                    {
                        foreach (CharInfo temp in elist)
                        {
                            if (temp == null)
                                continue;
                            if (flagfight == true && temp != null)
                                if ((temp.rpvpflag == 0 && (temp.relation & 0x00002) != 0
                                && ((temp.relation & 0x080000) != 0)) || temp.relation == 0)
                                    continue;

                            if (deadlist.ContainsKey(temp.ID))
                            {
                                if (temp.isAlikeDead == 0)
                                {
                                    deadlist.Remove(temp.ID);
                                }
                                else
                                    continue;
                            }

                            if (temp != null && temp.isAlikeDead == 1)
                            {
                                if (!deadlist.ContainsKey(temp.ID))
                                {
                                    deadlist.Add(temp.ID, temp);
                                }
                                continue;
                            }

                            if (temp != null && temp.distance < AttackDistance &&
                                ((temp.AbnormalEffects & medusastate) == 0)
                                && temp.isAlikeDead != 1 && temp.peace != 1)
                            {
                                if (target == null)
                                {
                                    target = temp;
                                }
                                if (temp.distance < target.distance)
                                {
                                    target = temp;
                                }
                            }

                        }
                    }
                    if (target != null)
                    {
                        if (!attacklist.ContainsKey(target.ID))
                        {
                            attacklist.Add(target.ID, target);
                            enemylist.Remove(target.ID);
                        }
                        else
                            enemylist.Remove(target.ID);
                    }
                    if (target == null)
                    {
                        foreach (CharInfo temp in elist)
                        {
                            if (temp != null && temp.peace == 1)
                            {
                                temp.peace = 0;
                                continue;
                            }
                        }
                    }

                    if (target == null || enemylist.Count < 1)
                    {
                        Array.Clear(elist, 0, elist.Length);
                        elist = new CharInfo[attacklist.Values.Count];
                        attacklist.Values.CopyTo(elist, 0);
                        foreach (CharInfo i in elist)
                        {
                            if (i != null)
                            {
                                if (i.peace == 1)
                                    i.peace = 0;
                                enemylist.Add(i.ID, i);
                                attacklist.Remove(i.ID);
                            }
                        }
                    }
                    //if (target != null)
                    //{
                    //    if (robeids.Contains(target.Chest))
                    //        Console.WriteLine("{0} is a robe user", target.Name);
                    //    else if (lightarmor.Contains(target.Chest))
                    //        Console.WriteLine("{0} is a light user", target.Name);
                    //    else
                    //        Console.WriteLine("{0} is a heavy or no armor user", target.Name);
                    //}
                    for (int counter = 0; counter < 40; counter++)
                    {
                        Thread.Sleep(250);
                        if(target != null)
                        {
                            if (target != null && target.distance < AttackDistance &&
                                ((target.AbnormalEffects & medusastate) == 0)
                                && target.isAlikeDead != 1 && target.peace != 1)
                                break;

                        }
                        else
                            break;


                    }
                }
                catch (ThreadInterruptedException e)
                {
                    System.Console.WriteLine("Switching targets");
                }
                catch(Exception e)
                {
                    System.Console.WriteLine(e.ToString());
                }

            }

        }

        public void startListen()
        {
            gsListen.Start();
            while (true)
            {
                Socket newsocket = gsListen.AcceptSocket();
                Client c = new Client(newsocket, this);
                clist.Add(c);
            }
        }

        public void deleteObject(uint id)
        {
            if (target == null)
                return;
            if (target.ID == id)
            {
                target.peace = 1;
            }
        }

        public void UpdateTarget(CharInfo cinfo)
        {
            if (target == null)
                return;
            if (cinfo.ID == target.ID)
            {
                target = cinfo;
            }

        }
    }
}
