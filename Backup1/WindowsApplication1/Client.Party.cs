using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace l2pvp
{
    public class PartyMember
    {
        uint objid;
        string name;
        uint cur_cp;
        uint max_cp;
        uint cur_hp;
        uint max_hp;
        uint cur_mp;
        uint max_mp;
        uint level;
        uint class_id;

    }

    public partial class Client
    {
        List<PartyMember> partylist;
        public Thread partythread;
        void initParty()
        {   
            //init the partylist
            partylist = new List<PartyMember>();

            //start the party thread
            partythread = new Thread(watchparty);
        }

        public void watchparty()
        {
            while (true)
            {
                //sleep for 50 ms
                Thread.Sleep(50);

                //check party state and take actions

                //now check your own state

            }
        }

        void addPartyMember(CharInfo c)
        {

        }

        void remPartyMember(CharInfo c)
        {

        }

        void joinParty()
        {

        }

        void leaveParty()
        {

        }
    }
}