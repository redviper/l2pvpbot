using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace l2pvp
{
    class Login
    {
        string lsIP;
        int lsPort;
        string localIP;


        NetworkStream p2s;
        NetworkStream p2c;

        Thread p2s_thread;
        Thread p2c_thread;

        Socket clientsock;

        bool loggingin;
        string localGSIP;

        LoginCryptServer icrypt;
        LoginCryptClient ocrypt;

        public Login(string _IP, int _Port, string _localIP, string _localGSIP)
        {
            lsIP = _IP;
            lsPort = _Port;
            localIP = _localIP;
            localGSIP = _localGSIP;
            loggingin = true;
            p2s_thread = new Thread(new ThreadStart(this.data_in));
            p2c_thread = new Thread(new ThreadStart(this.data_out));

        }

        public void newConnection()
        {
            try
            {
                //client connected to proxy
                //1) connect to remote server
                IPEndPoint remoteServer = new IPEndPoint(IPAddress.Parse(lsIP), lsPort);
                Socket proxy2server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                proxy2server.Connect(remoteServer);

                //2) server sends some data to client this contains the key and shit
                p2s = new NetworkStream(proxy2server);
                p2c = new NetworkStream(clientsock);

                p2s_thread.Start();
                p2c_thread.Start();
            }
            catch
            {
            }
        }

        private void data_in()
        {
            try
            {
                int lenlo = p2s.ReadByte();
                int lenhi = p2s.ReadByte();

                int length = lenhi * 256 + lenlo;
                byte[] buffer = new byte[length];
                buffer[0] = (byte)lenlo;
                buffer[1] = (byte)lenhi;
                p2s.Read(buffer, 2, length - 2);
                p2c.Write(buffer, 0, length);



                icrypt = new LoginCryptServer();
                ocrypt = new LoginCryptClient();

                byte[] buffer2 = new byte[length - 2];
                Array.Copy(buffer, 2, buffer2, 0, length - 2);

                ocrypt.decrypt(buffer2, 0, length - 2);

                byte[] bfkey = new byte[16];
                Array.Copy(buffer2, 153, bfkey, 0, 16);

                icrypt.setKey(bfkey);
                ocrypt.setKey(bfkey);


                while (loggingin == true)
                {
                    lenlo = p2s.ReadByte();
                    lenhi = p2s.ReadByte();

                    length = lenhi * 256 + lenlo;
                    buffer = new byte[length];
                    byte[] decbuff = new byte[length - 2];
                    buffer[0] = (byte)lenlo;
                    buffer[1] = (byte)lenhi;
                    p2s.Read(buffer, 2, length - 2);

                    Array.Copy(buffer, 2, decbuff, 0, length - 2);
                    icrypt.decrypt(decbuff, 0, length - 2);

                    switch (decbuff[0])
                    {
                        case 4:
                            {
                                //server list packet lets read it and see the ip and port of all the servers
                                int listsize = (int)decbuff[1];
                                int i = 0;

                                IPAddress localip = IPAddress.Parse(localGSIP);
                                byte[] localipbytes = localip.GetAddressBytes();
                                int localport = 7777;
                                byte[] localportbytes = BitConverter.GetBytes(localport);

                                for (i = 0; i < listsize; i++)
                                {
                                    int serverid = (int)decbuff[3 + i * 21];
                                    byte[] ipbyte = new byte[4];
                                    for (int j = 0; j < 4; j++)
                                    {
                                        ipbyte[j] = decbuff[3 + i * 21 + 1 + j];
                                        decbuff[3 + i * 21 + 1 + j] = localipbytes[j];
                                    }
                                    IPAddress gsip = new IPAddress(ipbyte);
                                    Console.WriteLine(gsip.ToString());
                                    byte[] portbyte = new byte[4];
                                    for (int k = 0; k < 4; k++)
                                    {
                                        portbyte[k] = decbuff[3 + i * 21 + 5 + k];
                                        decbuff[3 + i * 21 + 5 + k] = localportbytes[k];
                                    }
                                    int port = BitConverter.ToInt32(portbyte, 0);
                                }
                                //now encrypt the decbuffer
                                ocrypt.encrypt(decbuff, 0, length - 2);
                                p2c.WriteByte((byte)lenlo);
                                p2c.WriteByte((byte)lenhi);
                                p2c.Write(decbuff, 0, length - 2);
                                break;
                            }
                        case 0x07:
                            {
                                //got play ok notification, pass it on to client and exit from the login process
                                //write notification to client
                                Console.WriteLine("exiting loging in thread");
                                ocrypt.encrypt(decbuff, 0, length - 2);
                                p2c.WriteByte((byte)lenlo);
                                p2c.WriteByte((byte)lenhi);
                                p2c.Write(decbuff, 0, length - 2);
                                //set loggingin in to false
                                loggingin = false;
                                //return from this thread
                                p2c.Close();
                                p2s.Close();
                                p2c_thread.Abort();
                                p2s_thread.Abort();
                                return;
                            }
                        case 0x01:
                            {
                                //got play ok notification, pass it on to client and exit from the login process
                                //write notification to client
                                Console.WriteLine("exiting loging in thread");
                                ocrypt.encrypt(decbuff, 0, length - 2);
                                p2c.WriteByte((byte)lenlo);
                                p2c.WriteByte((byte)lenhi);
                                p2c.Write(decbuff, 0, length - 2);
                                //set loggingin in to false
                                loggingin = false;
                                //return from this thread
                                p2c.Close();
                                p2s.Close();
                                p2c_thread.Abort();
                                p2s_thread.Abort();
                                return;
                            }
                        default:
                            ocrypt.encrypt(decbuff, 0, length - 2);
                            p2c.WriteByte((byte)lenlo);
                            p2c.WriteByte((byte)lenhi);
                            p2c.Write(decbuff, 0, length - 2);
                            break;

                    }
                }
            }
            catch
            {
                loggingin = false;
            }

        }


        private void data_out()
        {
            try
            {
                byte[] buffer = new byte[0x1000];
                try
                {
                    while (loggingin == true)
                    {
                        int len = clientsock.Receive(buffer, 0, 0x1000, SocketFlags.None);
                        if (len == 0)
                            break;
                        p2s.Write(buffer, 0, len);
                    }
                }
                catch
                {
                }
                Console.WriteLine("exiting login thread 2");
                loggingin = false;
                p2c.Close();
                p2s.Close();
                clientsock.Close();
                p2s_thread.Abort();
                p2c_thread.Abort();
            }
            catch
            {
            }

        }

        public void addConnection(Socket connection2client)
        {
            clientsock = connection2client;
        }

    }
}
