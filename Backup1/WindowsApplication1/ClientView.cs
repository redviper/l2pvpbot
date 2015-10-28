using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace l2pvp
{
    public partial class ClientView : UserControl
    {
        Client c;
        public ClientView(Client _c)
        {
            InitializeComponent();
            c = _c;
            foreach (shots s in c.gs.shotlist)
            {
                shotbox.Items.Add(s);
            }
        }

        private void bt_logout_Click(object sender, EventArgs e)
        {
            c.logout();
        }

        private void bt_Leader_Click(object sender, EventArgs e)
        {
            c.setLeader();
        }

        private void bt_Buffs_Click(object sender, EventArgs e)
        {
            if (c != null)
            {
                c.buffform.Activate();
                c.buffform.Show();
            }
        }

        private void bt_Skills_Click(object sender, EventArgs e)
        {
            if (c != null)
            {
                c.asform.Activate();
                c.asform.Show();
            }

        }

        private void bt_Party_Click(object sender, EventArgs e)
        {
            if (c != null)
            {
                c.pform.Activate();
                c.pform.Show();
            }
        }

        private void bt_Defense_Click(object sender, EventArgs e)
        {
            if (c != null)
            {
                c.dsform.Activate();
                c.dsform.Show();
            }
        }

        private void cb_Attack_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Attack.Checked)
                c.battack = true;
            else
                c.battack = false;
        }

        private void cb_Shift_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Shift.Checked)
                c.shiftattack = true;
            else
                c.shiftattack = false;
        }

        private void bskills_CheckedChanged(object sender, EventArgs e)
        {
            if (bskills.Checked)
                c.skillattack = true;
            else
                c.skillattack = false;

        }

        private void bdefend_CheckedChanged(object sender, EventArgs e)
        {
            if (bdefend.Checked)
                c.defense = true;
            else
                c.defense = false;
        }

        private void tb_Attackdistance_TextChanged(object sender, EventArgs e)
        {
            try
            {
                c.adist = Convert.ToInt32(tb_Attackdistance.Text);
            }
            catch
            {
                c.adist = 900;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                c.blessing = true;
            else
                c.blessing = false;
        }

        private void shotbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = shotbox.SelectedIndex;
            if (index == -1)
                c.useshot = null;
            else
            {
                shots s = (shots)shotbox.SelectedItem;
                c.useshot = s;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                c.autofollow = true;
                c.followdistance = Convert.ToInt32(textBox1.Text);
            }
            else
            {
                c.autofollow = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                c.autotalk = true;
                c.talktime = Convert.ToInt32(textBox2.Text);
            }
            else
            {
                c.autotalk = false;
            }
        }

        private void rebuff_Click(object sender, EventArgs e)
        {
            try
            {
                c.buff_mre.Set();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void itbtn_Click(object sender, EventArgs e)
        {
            c.item_mre.Set();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (c != null)
            {
                c.fform.Activate();
                c.fform.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c != null)
            {
                c.iform.Activate();
                c.iform.Show();
            }
        }
    }
}
