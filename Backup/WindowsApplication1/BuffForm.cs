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
        ComboBox[] onbufflist;
        ComboBox[] doonbufflist;
        ComboBox[] afterbufflist;
        ComboBox[] doafterbufflist;


        public BuffForm(Client _c, GameServer _gs)
        {
            c = _c;
            gs = _gs;
            InitializeComponent();
            onbufflist = new ComboBox[4];
            doonbufflist = new ComboBox[4];
            afterbufflist = new ComboBox[4];
            doafterbufflist = new ComboBox[4];
            onbufflist[0] = comboBox1;
            onbufflist[1] = comboBox4;
            onbufflist[2] = comboBox6;
            onbufflist[3] = comboBox8;

            doonbufflist[0] = comboBox2;
            doonbufflist[1] = comboBox3;
            doonbufflist[2] = comboBox5;
            doonbufflist[3] = comboBox7;

            afterbufflist[0] = comboBox10;
            afterbufflist[1] = comboBox12;
            afterbufflist[2] = comboBox16;
            afterbufflist[3] = comboBox14;

            doafterbufflist[0] = comboBox9;
            doafterbufflist[1] = comboBox11;
            doafterbufflist[2] = comboBox15;
            doafterbufflist[3] = comboBox13;

            c.doafterskill.Clear();
            c.doonskill.Clear();

            foreach (ComboBox d in onbufflist)
            {
                foreach (string s in gs.skills.Values)
                    d.Items.Add(s);
 
            }
            foreach (ComboBox d in afterbufflist)
            {
                foreach (string s in gs.skills.Values)
                    d.Items.Add(s);

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
                string onskill, doonskill, afterskill, doafterskill;
                uint onskillid = 0, doonskillid = 0, afterskillid = 0, doafterskillid = 0;
                c.doonskill.Clear();
                c.doafterskill.Clear();
                for (int i = 0; i < 4; i++)
                {
                    //get on buff skills

                    if (onbufflist[i].SelectedItem == null || doonbufflist[i].SelectedItem == null)
                    {
                    }
                    else
                    {
                        onskill = onbufflist[i].SelectedItem.ToString();
                        doonskill = doonbufflist[i].SelectedItem.ToString();
                        foreach (uint j in gs.skills.Keys)
                        {
                            if (gs.skills[j] == onskill)
                                onskillid = j;
                            if (gs.skills[j] == doonskill)
                                doonskillid = j;
                        }
                        c.doonskill.Add(onskillid, doonskillid);
                    }

                    if (afterbufflist[i].SelectedItem == null || doafterbufflist[i].SelectedItem == null)
                    {
                    }
                    else
                    {
                        afterskill = afterbufflist[i].SelectedItem.ToString();
                        doafterskill = doafterbufflist[i].SelectedItem.ToString();
                        foreach (uint j in gs.skills.Keys)
                        {
                            if (gs.skills[j] == afterskill)
                                afterskillid = j;
                            if (gs.skills[j] == doafterskill)
                                doafterskillid = j;
                        }
                        c.doafterskill.Add(afterskillid, doafterskillid);
                    }
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error in setting buffs");
                this.Hide();
            }

        }
        public void populateskilllist_d(List<uint> skilllist)
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

        public delegate void poplist(List<uint> skilllist);

        public void populateskilllist(List<uint> skilllist)
        {
            foreach (ComboBox box in doonbufflist)
            {
                box.Items.Clear();
            }
            foreach (ComboBox box in doafterbufflist)
            {
                box.Items.Clear();
            }

            string skillname;
            foreach (uint i in skilllist)
            {
                if (gs.skills.ContainsKey(i))
                {
                    skillname = gs.skills[i];
                    if (skillname != null)
                    {
                        //found skill
                        foreach (ComboBox box in doonbufflist)
                        {
                            box.Items.Add(skillname);
                        }
                        foreach (ComboBox box in doafterbufflist)
                        {
                            box.Items.Add(skillname);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            fname = "buff-" + fname;
            string ev, act;
            StreamWriter writefile = new StreamWriter(new FileStream(fname, FileMode.Create), Encoding.UTF8);
            for (int i = 0; i < 4; i++)
            {
                if (onbufflist[i].SelectedItem != null && doonbufflist[i].SelectedItem != null)
                {
                    ev = onbufflist[i].SelectedItem.ToString();
                    act = doonbufflist[i].SelectedItem.ToString();
                    writefile.WriteLine("On, {0}, {1}", ev, act);
                }
                else
                {
                    writefile.WriteLine("On, null, null");
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (afterbufflist[i].SelectedItem != null && doafterbufflist[i].SelectedItem != null)
                {
                    ev = afterbufflist[i].SelectedItem.ToString();
                    act = doafterbufflist[i].SelectedItem.ToString();
                    writefile.WriteLine("After, {0}, {1}", ev, act);
                }
                else
                {
                    writefile.WriteLine("After, null, null");
                }
            }
            writefile.Flush();
            writefile.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fname = textBox1.Text;
            fname = "buff-" + fname;
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
            while((line = readfile.ReadLine()) != null)
            {
                char[] sep = new char[1];
                sep[0] = ',';
                char[] trim = new char[1];
                trim[0] = ' ';
                string[] split = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                if(split[0] == "On" && on < 4)
                {
                    if (split[1] == "null" || split[2] == "null")
                    {
                        on++;
                    }
                    else
                    {
                        onbufflist[on].SelectedItem = split[1].TrimStart(trim) ;
                        doonbufflist[on].SelectedItem = split[2].TrimStart(trim);
                        on++;
                    }
                }
                else if(split[0] == "After" && after < 4)
                {
                    if (split[1] == "null" || split[2] == "null")
                    {
                        after++;
                    }
                    else
                    {
                        afterbufflist[after].SelectedItem = split[1].TrimStart(trim);
                        doafterbufflist[after].SelectedItem = split[2].TrimStart(trim);
                        after++;
                    }
                }
                               
            }
        }
    }
}