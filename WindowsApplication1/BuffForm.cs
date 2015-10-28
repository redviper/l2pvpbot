using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using l2pvp;


namespace l2pvp
{

    public partial class BuffForm : Form
    {
        protected Client c;
        protected GameServer gs;

        public BuffForm(Client _c, GameServer _gs)
        {
            c = _c;
            gs = _gs;
            InitializeComponent();

            c.doafterskill.Clear();
            c.doonskill.Clear();


            foreach (skillmap s in gs.skills.Values)
            {
                cbOn.Items.Add(s);
                cbAfter.Items.Add(s);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                c.doonskill.Clear();

                foreach (ListViewItem item in listView1.Items)
                {
                    evtSkill s = (evtSkill)item.Tag;
                    c.doonskill.Add(s.evt.id, s);
                }

                c.doafterskill.Clear();

                foreach (ListViewItem item in listView2.Items)
                {
                    evtSkill s = (evtSkill)item.Tag;
                    c.doafterskill.Add(s.evt.id, s);
                }

                this.Hide();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(), "Error in setting buffs");
                Console.WriteLine("Error in setting buffs {0}", ex.ToString());
                this.Hide();
            }

        }
        public void populateskilllist_d(List<skill> skilllist)
        {
            try
            {
                if (this.InvokeRequired)
                    Invoke(new poplist(populateskilllist), new object[] { skilllist });
                else
                    populateskilllist(skilllist);
            }
            catch
            {
            }
        }

        public delegate void poplist(List<skill> skilllist);

        public void populateskilllist(List<skill> skilllist)
        {
            cbBuffOn.Items.Clear();
            cbBuffAfter.Items.Clear();

            foreach (skill i in skilllist)
            {
                //found skill
                cbBuffAfter.Items.Add(i);
                cbBuffOn.Items.Add(i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            fname = "dance-" + fname;
            saveConfig(fname);
        }

        public void saveConfig(string fname)
        {
            try
            {
                StreamWriter writefile = new StreamWriter(new FileStream(fname, FileMode.Create), Encoding.UTF8);
                foreach (ListViewItem i in listView1.Items)
                {
                    evtSkill s = (evtSkill)i.Tag;
                    writefile.WriteLine("On, {0}, {1}", s.evt.id, s.act.id);

                }
                foreach (ListViewItem i2 in listView2.Items)
                {
                    evtSkill s = (evtSkill)i2.Tag;
                    writefile.WriteLine("After, {0}, {1}", s.evt.id, s.act.id);
                }

                writefile.Flush();
                writefile.Close();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            fname = "dance-" + fname;
            loadConfig(fname);
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
            int on = 0, after = 0;
            listView1.Items.Clear();
            listView2.Items.Clear();

            while ((line = readfile.ReadLine()) != null)
            {
                char[] sep = new char[1];
                sep[0] = ',';
                char[] trim = new char[1];
                trim[0] = ' ';
                string[] split = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                if (split[0] == "On" && on < 6)
                {
                    if (split[1] == "null" || split[2] == "null")
                    {

                    }
                    else
                    {
                        uint evtid = Convert.ToUInt32(split[1].TrimStart(trim));
                        uint actid = Convert.ToUInt32(split[2].TrimStart(trim));

                        skillmap evt = gs.skills[evtid];
                        skill act = null;
                        foreach (skill sk in c.skilllist)
                        {
                            if (actid == sk.id)
                            {
                                act = sk;
                                break;
                            }
                        }
                        if (act == null)
                            continue;

                        evtSkill s = new evtSkill();
                        s.evt = evt;
                        s.act = act;


                        ListViewItem item = new ListViewItem(evt.name);
                        item.SubItems.Add(act.name);
                        item.Tag = s;
                        listView1.Items.Add(item);
                    }
                }
                else if (split[0] == "After" && after < 6)
                {
                    if (split[1] == "null" || split[2] == "null")
                    {

                    }
                    else
                    {
                        uint evtid = Convert.ToUInt32(split[1].TrimStart(trim));
                        uint actid = Convert.ToUInt32(split[2].TrimStart(trim));

                        skillmap evt = gs.skills[evtid];
                        skill act = null;
                        foreach (skill sk in c.skilllist)
                        {
                            if (actid == sk.id)
                            {
                                act = sk;
                                break;
                            }
                        }
                        if (act == null)
                            continue;

                        evtSkill s = new evtSkill();
                        s.evt = evt;
                        s.act = act;


                        ListViewItem item = new ListViewItem(evt.name);
                        item.SubItems.Add(act.name);
                        item.Tag = s;
                        listView2.Items.Add(item);
                    }
                }

            }
            readfile.Close();

            c.doonskill.Clear();

            foreach (ListViewItem item in listView1.Items)
            {
                evtSkill s = (evtSkill)item.Tag;
                c.doonskill.Add(s.evt.id, s);
            }

            c.doafterskill.Clear();

            foreach (ListViewItem item in listView2.Items)
            {
                evtSkill s = (evtSkill)item.Tag;
                c.doafterskill.Add(s.evt.id, s);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Add for onbuff
            skillmap evt = (skillmap)cbOn.SelectedItem;
            if (evt == null)
                return;
            skill act = (skill)cbBuffOn.SelectedItem;
            if (act == null)
                return;

            if (c.doonskill.ContainsKey(evt.id))
            {
                MessageBox.Show("Cannot have multiple skills launch from one skill");
                return;
            }

            evtSkill s = new evtSkill();
            s.evt = evt;
            s.act = act;


            ListViewItem item = new ListViewItem(evt.name);
            item.SubItems.Add(act.name);
            item.Tag = s;
            listView1.Items.Add(item);

            //c.doonskill.Add(s.evt.id, s);
        }

        private void cbON_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //delete for onbuff
            ListView.SelectedListViewItemCollection ic = listView1.SelectedItems;
            foreach (ListViewItem i in ic)
            {
                listView1.Items.Remove(i);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            skillmap evt = (skillmap)cbAfter.SelectedItem;
            if (evt == null)
                return;
            skill act = (skill)cbBuffAfter.SelectedItem;
            if (act == null)
                return;

            if (c.doafterskill.ContainsKey(evt.id))
            {
                MessageBox.Show("Cannot have multiple skills launch from one skill");
                return;
            }

            evtSkill s = new evtSkill();
            s.evt = evt;
            s.act = act;


            ListViewItem item = new ListViewItem(evt.name);
            item.SubItems.Add(act.name);
            item.Tag = s;
            listView2.Items.Add(item);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection ic = listView2.SelectedItems;
            foreach (ListViewItem i in ic)
            {
                listView2.Items.Remove(i);
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

    public class skillmap
    {
        public uint id;
        public string name;
        public override string ToString()
        {
            return name;
        }
    }

    public class evtSkill
    {
        public skillmap evt;
        public skill act;
        public System.Threading.ManualResetEvent mre;
        public bool succeed = false;
        public evtSkill()
        {
            mre = new System.Threading.ManualResetEvent(false);
        }
    }
}