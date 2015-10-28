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
using System.IO;

namespace l2pvp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            string fname = "ipfile.txt";
            StreamReader filereader = null;
            try
            {
                filereader = new StreamReader(new FileStream(fname, FileMode.Open), Encoding.UTF8);
                if (filereader == null)
                {
                    InitializeComponent();
                    return;
                }
            }
            catch
            {

            }
            InitializeComponent();
            string line;
            while ((line = filereader.ReadLine()) != null)
            {
                char[] sep = new char[1];
                sep[0] = ':';
                string[] split = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(split[0]);
                Console.WriteLine(split[1]);
                switch (split[0][0])
                {
                    case '1':
                        this.tb_ipaddr.Text = split[1];
                        break;
                    case '2':
                        this.tb_gsip.Text = split[1];
                        break;
                    case '3':
                        this.textBox1.Text = split[1];
                        break;
                    case '4':
                        this.textBox2.Text = split[1];
                        break;
                    default:
                        Console.WriteLine("using default values");
                        break;
                }
            }
            
            //this.tb_ipaddr;
            //this.textBox1;
            //this.textBox2;

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

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

    }
}