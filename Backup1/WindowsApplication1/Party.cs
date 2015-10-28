using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace l2pvp
{
    public partial class Party : Form
    {
        uint buffid;
        public Client c;
        public GameServer gs;
        public Party(Client _c, GameServer _gs)
        {
            buffid = 0;
            c = _c;
            gs = _gs;

            InitializeComponent();
        }

        public void populateskilllist_d(List<skill> skilllist)
        {
            if (this.InvokeRequired)
                Invoke(new poplist(populateskilllist), new object[] { skilllist });
            else
                populateskilllist(skilllist);
        }

        public delegate void poplist(List<skill> skilllist);

        public void populateskilllist(List<skill> skilllist)
        {
            allskills.Items.Clear();
            foreach (skill i in skilllist)
            {
                allskills.Items.Add(i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayerBuffs buff = null;

            char[] sep = new char[1];
            sep[0] = ';';
            string[] names = value.Text.Split(sep);
            uint timeBuff;
            try
            {
                timeBuff = Convert.ToUInt32(tbBuffTime.Text);
            }
            catch
            {
                timeBuff = 18;
            }

            lock (c.bufflock)
            {

                foreach (string name in names)
                {
                    buff = new PlayerBuffs();
                    buff.bufflist = new Dictionary<uint, skill>();
                    buff.mre = new System.Threading.ManualResetEvent(false);
                    buff.buffid = buffid;
                    buffid++;
                    buff.objid = 0;
                    buff.player = name;
                    buff.bufftimer = timeBuff;
                    buff.lastuse = new DateTime();
                    CharInfo[] cinfos = new CharInfo[gs.allplayerinfo.Count];
                    gs.allplayerinfo.Values.CopyTo(cinfos, 0);
                    if (buff.player == c.pinfo.Name || buff.player == "Self" || buff.player == "self")
                    {
                        //self buffs
                        buff.objid = c.pinfo.ObjID;
                    }
                    else if (buff.player == "")
                    {
                        buff.self = true;
                    }
                    else if (buff.player == gs.leader.pinfo.Name)
                    {
                        buff.objid = gs.leader.pinfo.ObjID;
                    }
                    else
                    {
                        foreach (CharInfo cinfo in cinfos)
                        {
                            if (buff.player == cinfo.Name)
                            {
                                buff.objid = cinfo.ID;
                                break;
                            }
                        }
                    }

                    ListBox.ObjectCollection all = sklist.Items;
                    string snames = "";
                    foreach (object o in all)
                    {
                        try
                        {
                            skill s = (skill)o;
                            buff.bufflist.Add(s.id, s);
                            if (snames == "")
                                snames = s.name;
                            else
                                snames = snames + ";" + s.name;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception in add {0}", ex.ToString());
                        }
                    }
                    c.bufflist.Add(buff);
                    //update view box
                    ListViewItem lvit = new ListViewItem(buff.player);
                    lvit.SubItems.Add(snames);
                    lvit.SubItems.Add("--");
                    lvit.Tag = buff;
                    listView1.Items.Add(lvit);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void sl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedskills = allskills.SelectedItems;
            skill s = null;
            foreach (object o in selectedskills)
            {
                try
                {
                    s = (skill)o;
                    if (!sklist.Items.Contains(s))
                    {
                        sklist.Items.Add(s);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in addBtn {0}", ex.ToString());
                }
            }
        }

        private void remBtn_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedskills = sklist.SelectedItems;
            List<object> removelist = new List<object>();

            if (selectedskills == null || selectedskills.Count == 0)
                return;
            foreach (object o in selectedskills)
            {
                removelist.Add(o);
            }

            foreach (object objr in removelist)
            {
                try
                {
                    if (sklist.Items.Contains(objr))
                    {
                        sklist.Items.Remove(objr);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in addBtn {0}", ex.ToString());
                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string fname = textBox2.Text;
            fname = "buffs-" + fname;
            saveConfig(fname);
        }

        public void saveConfig(string fname)
        {
            StreamWriter writefile = new StreamWriter(new FileStream(fname, FileMode.Create), Encoding.UTF8);
            writefile.WriteLine(c.bufflist.Count.ToString());

            foreach (PlayerBuffs pb in c.bufflist)
            {
                writefile.Write("{0}:{1}:", pb.player, pb.bufftimer.ToString());
                foreach (skill s in pb.bufflist.Values)
                {
                    writefile.Write("{0}, ", s.id);
                }
                writefile.WriteLine(" ");
            }

            writefile.Flush();
            writefile.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lock (c.bufflock)
            {

                string fname = textBox2.Text;
                fname = "buffs-" + fname;
                loadConfig(fname);
            }
        }

        public void loadConfig(string fname)
        {
            StreamReader readfile;
            try
            {

                readfile = new StreamReader(new FileStream(fname, FileMode.Open), Encoding.UTF8);
                if (readfile == null)
                    return;
            }
            catch
            {
                MessageBox.Show("couldn't open file {0} for reading", fname);
                return;
            }
            string line;
            int count;
            line = readfile.ReadLine();
            try
            {
                count = Convert.ToInt32(line);
            }
            catch
            {
                count = 0;
            }
            listView1.Items.Clear();
            c.bufflist.Clear();

            buffid = 0;
            char[] sep = new char[2];
            sep[0] = ','; sep[1] = ' ';

            for (int i = 0; i < count; i++)
            {
                try
                {
                    line = readfile.ReadLine();
                    string snames = "";
                    string[] firstsplit = line.Split(':');
                    PlayerBuffs b = new PlayerBuffs();
                    b.player = firstsplit[0];
                    try
                    {
                        b.bufftimer = Convert.ToUInt32(firstsplit[1]);
                    }
                    catch
                    {
                        b.bufftimer = 18;
                    }
                    b.buffid = buffid;
                    buffid++;
                    b.mre = new System.Threading.ManualResetEvent(false);
                    b.objid = 0;
                    b.lastuse = new DateTime();
                    b.bufflist = new Dictionary<uint, skill>();
                    CharInfo[] cinfos = new CharInfo[gs.allplayerinfo.Count];
                    gs.allplayerinfo.Values.CopyTo(cinfos, 0);
                    if (b.player == c.pinfo.Name || b.player == "Self" || b.player == "self")
                    {
                        //self buffs
                        b.objid = c.pinfo.ObjID;
                    }
                    else if (b.player == "")
                    {
                        b.self = true;
                    }
                    else if (b.player == gs.leader.pinfo.Name)
                    {
                        b.objid = gs.leader.pinfo.ObjID;
                    }
                    else
                    {
                        foreach (CharInfo cinfo in cinfos)
                        {
                            if (b.player == cinfo.Name)
                            {
                                b.objid = cinfo.ID;
                                break;
                            }
                        }
                    }
                    string[] secondsplit = firstsplit[2].Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in secondsplit)
                    {
                        try
                        {
                            uint skillid = Convert.ToUInt32(s);
                            string skillname = gs.skills[skillid].name;
                            foreach (skill loadskill in allskills.Items)
                            {
                                if (loadskill.id == skillid)
                                {
                                    //found a match
                                    b.bufflist.Add(skillid, loadskill);
                                    if (snames == "")
                                        snames = loadskill.name;
                                    else
                                        snames = snames + ";" + loadskill.name;
                                    break;
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    c.bufflist.Add(b);
                    //update view box
                    ListViewItem lvit = new ListViewItem(b.player);
                    lvit.SubItems.Add(snames);
                    lvit.SubItems.Add("--");
                    lvit.Tag = b;
                    listView1.Items.Add(lvit);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            readfile.Close();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selects = listView1.SelectedItems;
            lock (c.bufflock)
            {
                foreach (ListViewItem lvit in selects)
                {
                    //need to remove it from client buff list
                    PlayerBuffs b = (PlayerBuffs)lvit.Tag;
                    c.bufflist.Remove(b);
                    listView1.Items.Remove(lvit);
                    listView1.Update();
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selects = listView1.SelectedItems;
            foreach (ListViewItem lvit in selects)
            {
                PlayerBuffs b = (PlayerBuffs)lvit.Tag;

                lock (c.rebufflock)
                {
                    c.rebuffqueue.Enqueue(b);
                    c.sbuff_mre.Set();
                }
            }
        }

        public void loadconfig_d(string fname)
        {
            if (this.InvokeRequired)
                Invoke(new loadconfig(loadConfig), new object[] { fname });
            else
                loadConfig(fname);
        }

        public delegate void loadconfig(string fname);
    }
}