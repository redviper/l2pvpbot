using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections;

namespace l2pvp
{
    public partial class BotView : Form
    {
        public List<uint> newplayers;
        public List<uint> deletedplayer;
        public List<uint> players;
        public object listlock;

        public GameServer gs;
        public BotView(GameServer _gs)
        {
            gs = _gs;
            newplayers = new List<uint>();
            deletedplayer = new List<uint>();
            players = new List<uint>();
            listlock = new Object();
            InitializeComponent();
        }

        public delegate void addClient(UserControl cv);

        public void d_addClient(UserControl cv)
        {
            if (InvokeRequired)
            {
                Invoke(new addClient(f_addClient), new object[] { cv });
            }
            else
                f_addClient(cv);
        }
        public void d_removeClient(UserControl cv)
        {
            if (InvokeRequired)
            {
                Invoke(new addClient(f_removeClient), new object[] { cv });
            }
            else
                f_removeClient(cv);
        }

        protected void f_addClient(UserControl cv)
        {
            panel.SuspendLayout();
            panel.Controls.Add(cv);
            panel.ResumeLayout();
        }

        protected void f_removeClient(UserControl cv)
        {
            panel.SuspendLayout();
            panel.Controls.Remove(cv);
            panel.ResumeLayout();
            panel.Update();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lock (listlock)
            {
                foreach (uint i in newplayers)
                {
                    if (!players.Contains(i))
                        players.Add(i);
                }
                foreach (uint i in deletedplayer)
                {
                    if (players.Contains(i))
                        players.Remove(i);
                }

                newplayers.Clear();
                deletedplayer.Clear();
            }

            foreach (Client c in gs.clist)
            {
                if (c.pinfo != null)
                {
                    c.cv.lb_name.Text = c.pinfo.Name;
                    c.cv.lb_HPMAX.Text = c.pinfo.Max_HP.ToString();
                    c.cv.lb_HP.Text = c.pinfo.Cur_HP.ToString();
                    c.cv.lb_CPMAX.Text = c.pinfo.Max_CP.ToString();
                    c.cv.lb_CP.Text = c.pinfo.Cur_CP.ToString();
                }
            }

            if (gs.target != null)
            {
                lb_targetname.Text = gs.target.Name;
                targethp.Text = gs.target.Cur_HP.ToString();
                targetmaxhp.Text = gs.target.Max_HP.ToString();
            }
            else
            {
                lb_targetname.Text = "None";
                targethp.Text = "0";
                targetmaxhp.Text = "0";

            }

        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked)
            {
                //unchecking it
                gs.distanceupdates = false;
            }
            else
                gs.distanceupdates = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            listView1.SuspendLayout();
            listView1.Items.Clear();
            foreach (uint i in players)
            {
                if (gs.allplayerinfo.ContainsKey(i))
                {
                    CharInfo cinfo = gs.allplayerinfo[i];
                    string distance = Convert.ToString(Convert.ToUInt32(cinfo.distance));
                    ListViewItem item = new ListViewItem(distance);
                    item.Tag = cinfo;
                    item.SubItems.Add(cinfo.Name);
                    if (gs.clanlist.ContainsKey(cinfo.ClanID))
                        item.SubItems.Add(gs.clanlist[cinfo.ClanID].name);
                    else
                        item.SubItems.Add(String.Empty);
                    item.SubItems.Add(cinfo.ID.ToString());
                    if (gs.enemylist.ContainsKey(cinfo.ID) || gs.attacklist.ContainsKey(cinfo.ID))
                        item.Checked = true;
                    listView1.Items.Add(item);
                }
            }

            foreach (Clans cl in gs.clanlist.Values)
            {
                if (!checkedListBox1.Items.Contains(cl))
                {
                    checkedListBox1.Items.Add(cl);
                }
            }
            //            listView1.Sort();
            listView1.ResumeLayout();
            listView1.Update();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gs.battack = true;
            if (gs.targetselection.ThreadState != ThreadState.Running && gs.targetselection.ThreadState != ThreadState.WaitSleepJoin)
                gs.targetselection.Start();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            gs.battack = false;
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked)
                gs.autofollow = true;
            else
                gs.autofollow = false;

        }

        private void BotView_Load(object sender, EventArgs e)
        {
            gs.ghphp = Convert.ToUInt32(textBox13.Text);
            gs.cpelixir = Convert.ToUInt32(textBox14.Text);
            gs.hpelixir = Convert.ToUInt32(textBox12.Text);
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            gs.ghphp = Convert.ToUInt32(textBox13.Text);
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            gs.cpelixir = Convert.ToUInt32(textBox14.Text);
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            gs.hpelixir = Convert.ToUInt32(textBox12.Text);
        }

        private void BotView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fname = textBox15.Text;
            StreamWriter writefile = new StreamWriter(new FileStream(fname, FileMode.Create), Encoding.UTF8);

            //file format
            /*number of enemy clans
             * [name of clans - 1 per line]
             * name 1
             * [on buff line]
             * [after buff line]
             * name 2
             * ...
             * 
            */
            writefile.WriteLine("{0}", gs.enemyclans.Count);
            foreach (Clans c in gs.enemyclans.Values)
            {
                writefile.WriteLine("{0}", c.name);
            }

            writefile.Flush();
            writefile.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fname = textBox15.Text;
            StreamReader readfile;
            try
            {

                readfile = new StreamReader(new FileStream(fname, FileMode.Open), Encoding.UTF8);
                if (readfile == null)
                    return;
            }
            catch
            {
                MessageBox.Show("Couldn't find file");
                return;
            }
            string line;

            line = readfile.ReadLine();
            uint clancount = Convert.ToUInt32(line);
            for (int i = 0; i < clancount; i++)
            {
                line = readfile.ReadLine();
                gs.enemynames.Add(line);
            }

            foreach (string s in gs.enemynames)
            {
                if (s == "Purgatory")
                    continue;
                foreach (Clans c in gs.clanlist.Values)
                {
                    if (s == c.name)
                    {
                        if (!gs.enemyclans.ContainsKey(c.id))
                        {
                            gs.enemyclans.Add(c.id, c);
                            int index = checkedListBox1.Items.IndexOf(c);
                            if (index != -1)
                            {
                                checkedListBox1.SetItemChecked(index, true);
                            }
                            int allplayercount = gs.allplayerinfo.Count;
                            foreach (uint j in gs.allplayerinfo.Keys)
                            {
                                if (gs.allplayerinfo[j].ClanID == c.id)
                                {
                                    //enemy player!
                                    if (!gs.enemylist.ContainsKey(gs.allplayerinfo[j].ID)
                                        && !gs.attacklist.ContainsKey(gs.allplayerinfo[j].ID))
                                        gs.enemylist.Add(gs.allplayerinfo[j].ID, gs.allplayerinfo[j]);
                                }
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Unchecked)
            {
                Clans c = (Clans)checkedListBox1.Items[e.Index];
                string clanname = c.name;
                if (clanname == "Purgatory")
                {
                    MessageBox.Show("Purgatory is your friend!");
                    e.NewValue = CheckState.Unchecked;
                    return;
                }
                int clancount = gs.clanlist.Count;

                if (!gs.enemyclans.ContainsKey(c.id))
                {
                    gs.enemyclans.Add(c.id, c);
                    int allplayercount = gs.allplayerinfo.Count;
                    foreach (CharInfo j in gs.allplayerinfo.Values)
                    {
                        if (j.ClanID == c.id)
                        {
                            //enemy player!
                            if (!gs.enemylist.ContainsKey(j.ID))
                            {
                                gs.enemylist.Add(j.ID, j);
                            }
                        }
                    }
                }
            }
            else if (e.CurrentValue == CheckState.Checked)
            {
                Clans c = (Clans)checkedListBox1.Items[e.Index];
                foreach (CharInfo j in gs.allplayerinfo.Values)
                {
                    if (j.ClanID == c.id)
                    {
                        //enemy player not //fix
                        if (gs.enemylist.ContainsKey(j.ID))
                            gs.enemylist.Remove(j.ID);
                        if (gs.attacklist.ContainsKey(j.ID))
                            gs.attacklist.Remove(j.ID);
                    }
                }
                gs.enemyclans.Remove(c.id);

            }
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            listView1.SuspendLayout();
            uint objectid = Convert.ToUInt32(listView1.Items[e.Index].SubItems[3].Text);
            if (e.CurrentValue == CheckState.Unchecked)
            {
                if (gs.allplayerinfo.ContainsKey(objectid) && !gs.enemylist.ContainsKey(objectid)
                    && !gs.attacklist.ContainsKey(objectid))
                {
                    //in the list
                    //check if this is a purg member
                    if (gs.allplayerinfo[objectid].ClanID == gs.PurgId)
                    {
                        MessageBox.Show("Purgatory is your friend!");
                        e.NewValue = CheckState.Unchecked;
                    }
                    else
                    {
                        gs.enemylist.Add(objectid, gs.allplayerinfo[objectid]);
                        e.NewValue = CheckState.Checked;
                    }

                }
            }
            if (e.CurrentValue == CheckState.Checked)
            {
                if (gs.enemylist.ContainsKey(objectid))
                {
                    gs.enemylist.Remove(objectid);
                }
                else if (gs.attacklist.ContainsKey(objectid))
                {
                    gs.attacklist.Remove(objectid);
                }
                e.NewValue = CheckState.Unchecked;
            }
            listView1.ResumeLayout();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                gs.AttackDistance = Convert.ToInt32(textBox11.Text);
            }
            catch
            {
                gs.AttackDistance = 1200;
            }
        }

        private void cb_CPpots_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_CPpots.Checked)
            {
                gs.cppots = true;

            }
            else
            {
                gs.cppots = false;
            }
        }

        private void cb_HPpots_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_HPpots.Checked)
            {
                gs.ghppots = true;
            }
            else
                gs.ghppots = false;

        }

        private void cb_Elixirs_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Elixirs.Checked)
            {
                gs.elixir = true;
            }
            else
                gs.elixir = false;

        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewItemComparer sorter = new ListViewItemComparer(e.Column);
            if (e.Column == 0)
                sorter.Numeric = true;
            if (listView1.Sorting == SortOrder.Ascending || listView1.Sorting == SortOrder.None)
                listView1.Sorting = SortOrder.Descending;
            else
                listView1.Sorting = SortOrder.Ascending;
            listView1.ListViewItemSorter = sorter;
            listView1.Sort();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                gs.flagfight = true;
            }
            else
                gs.flagfight = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                gs.kill2waywar = true;
            }
            else
                gs.kill2waywar = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                DialogResult res = MessageBox.Show("Are you sure you want to bsoe like a pussy?",
                    "Confirm pussiness", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {

                    gs.usebsoe = true;
                }
                else
                {
                    checkBox3.Checked = false;
                    gs.usebsoe = false;
                }
            }
            else
                gs.usebsoe = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                gs.qhp = true;
            }
            else
                gs.qhp = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            gs.qhphp = Convert.ToUInt32(textBox1.Text);
        }
    }


    public class ListViewItemComparer : IComparer
    {

        private int column;
        private bool numeric = false;

        public int Column
        {

            get { return column; }
            set { column = value; }
        }

        public bool Numeric
        {

            get { return numeric; }
            set { numeric = value; }
        }

        public ListViewItemComparer(int columnIndex)
        {

            Column = columnIndex;
        }

        public int Compare(object x, object y)
        {

            ListViewItem listX = (ListViewItem)x;
            ListViewItem listY = (ListViewItem)y;

            if (Numeric)
            {

                // Convert column text to numbers before comparing.
                // If the conversion fails, just use the value 0.
                decimal listXVal, listYVal;
                try
                {
                    listXVal = Decimal.Parse(listX.SubItems[Column].Text);
                }
                catch
                {
                    listXVal = 0;
                }

                try
                {
                    listYVal = Decimal.Parse(listY.SubItems[Column].Text);
                }
                catch
                {
                    listYVal = 0;
                }

                return Decimal.Compare(listXVal, listYVal);
            }
            else
            {

                // Keep the column text in its native string format
                // and perform an alphabetic comparison.
                string listXText = listX.SubItems[Column].Text;
                string listYText = listY.SubItems[Column].Text;

                return String.Compare(listXText, listYText);
            }
        }
    }
}