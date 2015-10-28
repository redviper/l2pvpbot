using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace l2pvp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        GameServer gs;
        protected string lsIP, localIP;
        private void bt_listen_Click(object sender, EventArgs e)
        {
            try
            {

                lsIP = tb_ipaddr.Text;
                localIP = textBox1.Text;

                gs = new GameServer(tb_gsip.Text, 7777, localIP);
                Thread tgs = new Thread(this.startGameserver);
                tgs.Start();
                ThreadStart tstart = new ThreadStart(this.connThread);
                Thread ts = new Thread(tstart);
                ts.Start();
                bt_listen.Enabled = false;
                this.ShowInTaskbar = false;
                this.Hide();
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.ToString(), "Error");
                System.Console.WriteLine(excep.StackTrace.ToString());
            }
        }

        private void startGameserver()
        {
            gs.startListen();
        }

        private void connThread()
        {
            if (lsIP.Length < 8)
            {
                lsIP = "216.107.242.195";
            }

            TcpListener local = new TcpListener(System.Net.IPAddress.Any, 2106);
            local.Start(10);
            while (true)
            {
                Socket newclientsocket = local.AcceptSocket();
                Login ls = new Login(lsIP, 2106, localIP, textBox2.Text);
                ThreadStart tstart = new ThreadStart(ls.newConnection);
                Thread ts = new Thread(tstart);
                ls.addConnection(newclientsocket);
                ts.Start();
            }

        }

    }
}