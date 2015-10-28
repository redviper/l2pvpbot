using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace l2pvp
{
    public partial class Defense : Form
    {
        Client c;
        GameServer gs;
        public Defense(Client _c, GameServer _gs)
        {
            InitializeComponent();
            c = _c;
            gs = _gs;
            condition.Items.Add("Always");
            condition.Items.Add("HP");
            condition.Items.Add("Distance");

            compare.Items.Add("=");
            compare.Items.Add(">");
            compare.Items.Add("<");

            Effects sleep, hold, medusa, poison;

            medusa = new Effects();
            medusa.name = "Medusa";
            medusa.id = 2048;

            sleep = new Effects();
            sleep.name = "Sleep";
            sleep.id = 128;

            hold = new Effects();
            hold.name = "Root";
            hold.id = 512;


            poison = new Effects();
            poison.name = "Poison";
            poison.id = 2;

            eff.Items.Add(medusa);
            eff.Items.Add(sleep);
            eff.Items.Add(hold);
            eff.Items.Add(poison);

            condition.SelectedIndex = 0;
            compare.SelectedIndex = 0;
            value.Text = "0";
            eff.SelectedIndex = 0;
            tb_mp.Text = "1500";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add to listview
            Effects thisEffect = new Effects();
            DefenseSkills askill = new DefenseSkills();
            askill.comparison = compare.SelectedIndex;
            askill.condition = condition.SelectedIndex;
            string skillname = sl.Items[sl.SelectedIndex].ToString();
            uint skillid = ((skill)sl.Items[sl.SelectedIndex]).id;
            foreach (skill s in c.skilllist)
            {
                if (s.id == skillid)
                {
                    askill.useskill = s;
                }
            }
            try
            {
                askill.value = Convert.ToInt32(value.Text);
            }
            catch
            {
                askill.value = 0;
            }
            thisEffect = ((Effects)eff.SelectedItem);
            askill.effect = thisEffect.id;
            try
            {
                askill.MP = Convert.ToUInt32(tb_mp.Text);
            }
            catch
            {
                askill.MP = 1500;
            }
            ListViewItem item = new ListViewItem(askill.useskill.name);
            item.SubItems.Add(condition.Items[askill.condition].ToString());
            item.SubItems.Add(compare.Items[askill.comparison].ToString());
            item.SubItems.Add(askill.value.ToString());
            item.SubItems.Add(thisEffect.name);
            item.SubItems.Add(askill.MP.ToString());
            item.Tag = askill;
            listView1.Items.Add(item);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lock (c.dslock)
            {
                c.dskills.Clear();
                foreach (ListViewItem item in listView1.Items)
                {
                    c.dskills.Add((DefenseSkills)item.Tag);
                }
            }
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection ic = listView1.SelectedItems;
            foreach (ListViewItem i in ic)
            {
                listView1.Items.Remove(i);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string fname = textBox2.Text;
            fname = "defend-" + fname;
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
            for (int i = 0; i < count; i++)
            {
                try
                {
                    line = readfile.ReadLine();
                    string[] items = line.Split(',');
                    DefenseSkills askill = new DefenseSkills();
                    uint skillid = Convert.ToUInt32(items[0]);
                    foreach (skill s in c.skilllist)
                    {
                        if (s.id == skillid)
                        {
                            askill.useskill = s;
                        }
                    }

                    askill.condition = Convert.ToInt32(items[1]);
                    askill.comparison = Convert.ToInt32(items[2]);
                    askill.value = Convert.ToInt32(items[3]);
                    string skillname = askill.useskill.name;
                    askill.effect = Convert.ToUInt32(items[4]);
                    askill.MP = Convert.ToUInt32(items[5]);
                    ListViewItem item = new ListViewItem(askill.useskill.name);
                    item.SubItems.Add(condition.Items[askill.condition].ToString());
                    item.SubItems.Add(compare.Items[askill.comparison].ToString());
                    item.SubItems.Add(askill.value.ToString());
                    item.SubItems.Add(askill.MP.ToString());
                    foreach (object o in eff.Items)
                    {
                        Effects neweffect = (Effects)o;
                        if (neweffect.id == askill.effect)
                        {
                            //found it
                            item.SubItems.Add(neweffect.name);
                        }
                    }
                    item.Tag = askill;

                    listView1.Items.Add(item);
                }
                catch
                {
                }
            }
            readfile.Close();
            lock (c.dslock)
            {
                c.dskills.Clear();
                foreach (ListViewItem item in listView1.Items)
                {
                    c.dskills.Add((DefenseSkills)item.Tag);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //file format
            //Count
            //<skill id> <condition id> <comparison id> <value>
            string fname = textBox2.Text;
            fname = "defend-" + fname;
            saveConfig(fname);
        }

        public void saveConfig(string fname)
        {
            StreamWriter writefile = new StreamWriter(new FileStream(fname, FileMode.Create), Encoding.UTF8);
            int count = listView1.Items.Count;
            writefile.WriteLine(count.ToString());
            foreach (ListViewItem i in listView1.Items)
            {
                DefenseSkills a = (DefenseSkills)i.Tag;
                writefile.WriteLine("{0},{1},{2},{3},{4},{5}",
                    a.useskill.id, a.condition, a.comparison, a.value, a.effect, a.MP);
            }
            writefile.Flush();
            writefile.Close();
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
            sl.Items.Clear();
            foreach (skill i in skilllist)
            {
                    //found skill
                    sl.Items.Add(i);
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
    public class Effects
    {
        public string name;
        public uint id;

        public override string ToString()
        {
            return name;
        }
    }
}