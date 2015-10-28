using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace l2pvp
{
    public partial class ItemUseForm : Form
    {
        Client c;
        GameServer gs;
        public ItemUseForm(Client _c, GameServer _gs)
        {
            InitializeComponent();
            c = _c;
            _gs = gs;



        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            c.useItems.Clear();
            foreach (ListViewItem i in listView1.Items)
            {
                ClientItems ci = (ClientItems)i.Tag;
                c.useItems.Add(ci);
            }
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientItems i = (ClientItems)sl.SelectedItem;

            ListViewItem item = new ListViewItem(i.item.name);
            item.Tag = i;
            listView1.Items.Add(item);
        }

        public void populateitemlist_d(List<ClientItems> itemlist)
        {
            if (this.InvokeRequired)
                Invoke(new poplist(populateitemlist), new object[] { itemlist });
            else
                populateitemlist(itemlist);
        }

        public delegate void poplist(List<ClientItems> itemlist);

        public void populateitemlist(List<ClientItems> itemlist)
        {
            sl.Items.Clear();
            foreach (ClientItems i in itemlist)
            {
                sl.Items.Add(i);
            }
        }
    }
}
