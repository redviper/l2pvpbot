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
    public partial class Client
    {
        #region Threads
        protected void useShotFunc()
        {
            if (useshot == null)
                return;
            ByteBuffer requse = new ByteBuffer(9);
            requse.WriteByte(0x14);
            requse.WriteUInt32(useshot.objid);
            requse.WriteUInt32(0);
            NewMsgHP(requse);
        }

        public void skillfunction()
        {
            ByteBuffer actionmsg = new ByteBuffer(18);
            actionmsg.WriteByte(0x1f);

            int actionindex = actionmsg.GetIndex();

            ByteBuffer cancelpacket = new ByteBuffer(3);
            cancelpacket.WriteByte(0x48);
            cancelpacket.WriteInt16(1);

            ByteBuffer useskillmsg = new ByteBuffer(10);
            useskillmsg.WriteByte(0x39);
            int skillindex = useskillmsg.GetIndex();
            useskillmsg.WriteUInt32(0);
            useskillmsg.WriteUInt32(1);
            int shiftindex = useskillmsg.GetIndex();
            useskillmsg.WriteByte(0x00);

            ByteBuffer validateposition = new ByteBuffer(16);
            validateposition.WriteByte(0x59);
            int valposindex = validateposition.GetIndex();
            bool doskill;// = false;

            while (true)
            {
                Thread.Sleep(250);
                if (skillattack == false || gs.battack == false)
                    continue;

                CharInfo mytarget = gs.target;
                if (mytarget != null)
                {
                    if (mytarget.peace == 1 || ((mytarget.AbnormalEffects & gs.medusastate) != 0)
                        || mytarget.isAlikeDead == 1)
                    {
                        if (gs.leader == this)
                        {
                            //I am leader!
                            if (gs.targetselection.ThreadState == ThreadState.WaitSleepJoin)
                                gs.targetselection.Interrupt();
                        }

                    }
                    actionmsg.SetIndex(actionindex);
                    actionmsg.WriteUInt32(mytarget.ID);
                    actionmsg.WriteInt32(pinfo.X);
                    actionmsg.WriteInt32(pinfo.Y);
                    actionmsg.WriteInt32(pinfo.Z);
                    actionmsg.WriteByte(1);
                    NewMessage(actionmsg);

                    if (mytarget.peace == 1 || ((mytarget.AbnormalEffects & gs.medusastate) != 0)
                        || mytarget.isAlikeDead == 1)
                    {
                        if (gs.leader == this)
                        {
                            //I am leader!
                            if (gs.targetselection.ThreadState == ThreadState.WaitSleepJoin)
                                gs.targetselection.Interrupt();
                        }

                    }
                    lock (aslock)
                    {

                        foreach (AttackSkills a in askills)
                        {
                            doskill = false;
                            switch (a.condition)
                            {
                                case 0: //always
                                    doskill = true;
                                    break;
                                case 1: //HP
                                    switch (a.comparison)
                                    {
                                        case 0: //==
                                            if (mytarget.Cur_HP == a.value)
                                                doskill = true;
                                            break;
                                        case 1: //>
                                            if (mytarget.Cur_HP > a.value)
                                                doskill = true;
                                            break;
                                        case 2: //<
                                            if (mytarget.Cur_HP < a.value)
                                                doskill = true;
                                            break;
                                    }
                                    break;
                                case 2: //distance
                                    double distance =
                                        System.Math.Sqrt(Math.Pow((pinfo.X - mytarget.X), 2)
                                        + Math.Pow((pinfo.Y - mytarget.Y), 2) + Math.Pow(pinfo.Z - mytarget.Z, 2));
                                    switch (a.comparison)
                                    {
                                        case 0: //==
                                            if (distance == a.value)
                                                doskill = true;
                                            break;
                                        case 1: //>
                                            if (distance > a.value)
                                                doskill = true;
                                            break;
                                        case 2: //<
                                            if (distance < a.value)
                                                doskill = true;
                                            break;
                                    }
                                    break;

                            }
                            if (doskill == true)
                            {
                                useShotFunc();
                                actionmsg.SetIndex(actionindex);
                                actionmsg.WriteUInt32(mytarget.ID);
                                actionmsg.WriteInt32(pinfo.X);
                                actionmsg.WriteInt32(pinfo.Y);
                                actionmsg.WriteInt32(pinfo.Z);
                                actionmsg.WriteByte(1);

                                useskillmsg.SetIndex(shiftindex);
                                if (shiftattack)
                                    useskillmsg.WriteByte(1);
                                else
                                    useskillmsg.WriteByte(0);

                                useskillmsg.SetIndex(skillindex);
                                useskillmsg.WriteUInt32(a.skillid);
                                NewMsgHP(actionmsg);
                                NewMsgHP(useskillmsg);

                                validateposition.SetIndex(valposindex);
                                validateposition.WriteInt32(pinfo.X);
                                validateposition.WriteInt32(pinfo.Y);
                                validateposition.WriteInt32(pinfo.Z);
                                validateposition.WriteInt32(pinfo.Heading);
                                validateposition.WriteInt32(0);
                                NewMsgHP(validateposition);
                            }
                            Thread.Sleep(250);
                        }
                    }

                }
            }
        }
        public void attackfunction()
        {
            ByteBuffer actionmsg = new ByteBuffer(18);
            actionmsg.WriteByte(0x1f);

            int actionindex = actionmsg.GetIndex();

            ByteBuffer cancelpacket = new ByteBuffer(3);
            cancelpacket.WriteByte(0x48);
            cancelpacket.WriteInt16(1);

            ByteBuffer useskillmsg = new ByteBuffer(10);
            useskillmsg.WriteByte(0x39);
            int skillindex = useskillmsg.GetIndex();
            useskillmsg.WriteUInt32(0);
            useskillmsg.WriteUInt32(1);
            int shiftindex = useskillmsg.GetIndex();
            useskillmsg.WriteByte(0x00);

            ByteBuffer validateposition = new ByteBuffer(16);
            validateposition.WriteByte(0x59);
            int valposindex = validateposition.GetIndex();

            ByteBuffer data = new ByteBuffer(0x12);
            data.WriteByte(0x01);
            //data.WriteUInt32(target.ID);
            int index = data.GetIndex();


            useshot = null;

            while (true)
            {
                Thread.Sleep(250);
                if (battack == false || gs.battack == false)
                    continue;

                CharInfo mytarget = gs.target;

                if (mytarget != null)
                {
                    if (mytarget.peace == 1 || ((mytarget.AbnormalEffects & gs.medusastate) != 0)
                        || mytarget.isAlikeDead == 1)
                    {
                        if (gs.leader == this)
                        {
                            //I am leader!
                            if (gs.targetselection.ThreadState == ThreadState.WaitSleepJoin)
                                gs.targetselection.Interrupt();
                        }

                    }
                    actionmsg.SetIndex(actionindex);
                    actionmsg.WriteUInt32(mytarget.ID);
                    actionmsg.WriteInt32(pinfo.X);
                    actionmsg.WriteInt32(pinfo.Y);
                    actionmsg.WriteInt32(pinfo.Z);
                    actionmsg.WriteByte(1);
                    NewMessage(actionmsg);

                    if (mytarget.peace == 1 || ((mytarget.AbnormalEffects & gs.medusastate) != 0)
                        || mytarget.isAlikeDead == 1)
                    {
                        if (gs.leader == this)
                        {
                            //I am leader!
                            if (gs.targetselection.ThreadState == ThreadState.WaitSleepJoin)
                                gs.targetselection.Interrupt();
                        }

                    }

                    data.SetIndex(index);
                    double distance = 0.0;
                    distance = System.Math.Sqrt(Math.Pow((pinfo.X - mytarget.X), 2) + Math.Pow((pinfo.Y - mytarget.Y), 2) + Math.Pow(pinfo.Z - mytarget.Z, 2));
                    if (distance <= (adist + 25))
                    {
                        useShotFunc();

                        data.WriteUInt32(mytarget.ID);
                        data.WriteInt32(pinfo.X);
                        data.WriteInt32(pinfo.Y);
                        data.WriteInt32(pinfo.Z);
                        if (shiftattack == true)
                            data.WriteByte(1);
                        else
                            data.WriteByte(0);

                        validateposition.SetIndex(valposindex);
                        validateposition.WriteInt32(pinfo.X);
                        validateposition.WriteInt32(pinfo.Y);
                        validateposition.WriteInt32(pinfo.Z);
                        validateposition.WriteInt32(pinfo.Heading);
                        validateposition.WriteInt32(0);


                        NewMsgHP(data);
                        NewMsgHP(validateposition);

                    }


                }
            }
        }
        public void defendfunction()
        {
            ByteBuffer actionmsg = new ByteBuffer(18);
            actionmsg.WriteByte(0x1f);

            int actionindex = actionmsg.GetIndex();

            ByteBuffer cancelpacket = new ByteBuffer(3);
            cancelpacket.WriteByte(0x48);
            cancelpacket.WriteInt16(1);

            ByteBuffer useskillmsg = new ByteBuffer(10);
            useskillmsg.WriteByte(0x39);
            int skillindex = useskillmsg.GetIndex();
            useskillmsg.WriteUInt32(0);
            useskillmsg.WriteUInt32(1);
            int shiftindex = useskillmsg.GetIndex();
            useskillmsg.WriteByte(0x00);

            ByteBuffer validateposition = new ByteBuffer(16);
            validateposition.WriteByte(0x59);
            int valposindex = validateposition.GetIndex();
            bool doskill;// = false;


            while (true)
            {
                Thread.Sleep(250);
                if (defense == false || gs.battack == false)
                    continue;

                int count = gs.enemylist.Values.Count;
                CharInfo[] attackers = new CharInfo[count + 10];
                gs.enemylist.Values.CopyTo(attackers, 0);
                foreach (CharInfo mytarget in attackers)
                {
                    Thread.Sleep(100);
                    if (mytarget != null)
                    {
                        if (mytarget.peace == 1 || ((mytarget.AbnormalEffects & gs.medusastate) != 0)
                            || mytarget.isAlikeDead == 1)
                        {
                            mytarget.peace = 0;
                            continue;
                        }
                        actionmsg.SetIndex(actionindex);
                        actionmsg.WriteUInt32(mytarget.ID);
                        actionmsg.WriteInt32(pinfo.X);
                        actionmsg.WriteInt32(pinfo.Y);
                        actionmsg.WriteInt32(pinfo.Z);
                        actionmsg.WriteByte(1);
                        NewMessage(actionmsg);

                        if (mytarget.peace == 1 || ((mytarget.AbnormalEffects & gs.medusastate) != 0)
                            || mytarget.isAlikeDead == 1)
                        {
                            mytarget.peace = 0;
                            continue;
                        }
                        lock (dslock)
                        {
                            foreach (DefenseSkills a in dskills)
                            {
                                doskill = false;
                                switch (a.condition)
                                {
                                    case 0: //always
                                        doskill = true;
                                        break;
                                    case 1: //HP
                                        switch (a.comparison)
                                        {
                                            case 0: //==
                                                if (mytarget.Cur_HP == a.value)
                                                    doskill = true;
                                                break;
                                            case 1: //>
                                                if (mytarget.Cur_HP > a.value)
                                                    doskill = true;
                                                break;
                                            case 2: //<
                                                if (mytarget.Cur_HP < a.value)
                                                    doskill = true;
                                                break;
                                        }
                                        break;
                                    case 2: //distance
                                        double distance =
                                            System.Math.Sqrt(Math.Pow((pinfo.X - mytarget.X), 2)
                                            + Math.Pow((pinfo.Y - mytarget.Y), 2) + Math.Pow(pinfo.Z - mytarget.Z, 2));
                                        switch (a.comparison)
                                        {
                                            case 0: //==
                                                if (distance == a.value)
                                                    doskill = true;
                                                break;
                                            case 1: //>
                                                if (distance > a.value)
                                                    doskill = true;
                                                break;
                                            case 2: //<
                                                if (distance < a.value)
                                                    doskill = true;
                                                break;
                                        }
                                        break;

                                }
                                if (doskill == true && (mytarget.AbnormalEffects & a.effect) == 0 && pinfo.Cur_MP >= a.MP)
                                {
                                    useShotFunc();

                                    actionmsg.SetIndex(actionindex);
                                    actionmsg.WriteUInt32(mytarget.ID);
                                    actionmsg.WriteInt32(pinfo.X);
                                    actionmsg.WriteInt32(pinfo.Y);
                                    actionmsg.WriteInt32(pinfo.Z);
                                    actionmsg.WriteByte(1);

                                    useskillmsg.SetIndex(shiftindex);
                                    if (shiftattack)
                                        useskillmsg.WriteByte(1);
                                    else
                                        useskillmsg.WriteByte(0);

                                    useskillmsg.SetIndex(skillindex);
                                    useskillmsg.WriteUInt32(a.skillid);
                                    NewMsgHP(actionmsg);
                                    NewMsgHP(useskillmsg);

                                    validateposition.SetIndex(valposindex);
                                    validateposition.WriteInt32(pinfo.X);
                                    validateposition.WriteInt32(pinfo.Y);
                                    validateposition.WriteInt32(pinfo.Z);
                                    validateposition.WriteInt32(pinfo.Heading);
                                    validateposition.WriteInt32(0);
                                    NewMsgHP(validateposition);
                                }
                                Thread.Sleep(250);
                            }
                        }
                    }
                }
            }
        }
        public void movepawnthread()
        {
            int newx, newy;
            if (gs.leader == this)
                return;
            int condition = x.Next(100);

            while (true)
            {
                try
                {
                    Thread.Sleep(3000);
                    if (pinfo == null || gs.leader.pinfo == null)
                        continue;

                    if (gs.autofollow)
                    {
                        int fx = gs.leader.pinfo.X;
                        int fy = gs.leader.pinfo.Y;
                        int fz = gs.leader.pinfo.Z;

                        double distance = 0.0;
                        distance = System.Math.Sqrt(Math.Pow((pinfo.X - fx), 2) + Math.Pow((pinfo.Y - fy), 2) + Math.Pow(pinfo.Z - fz, 2));

                        int dx = pinfo.X - fx;
                        int dy = pinfo.Y - fy;

                        if (distance > 200 && distance < 2000)
                        {
                            double degree = convertHeadingToDegree(gs.leader.pinfo.Heading);


                            double perpendicular;
                            if (condition % 2 == 0)
                            {
                                perpendicular = degree - 90;
                            }
                            else
                            {
                                perpendicular = degree + 90;
                            }

                            int dxy = x.Next(0, 200);

                            newx = (int)(dxy * Math.Cos(perpendicular));
                            newy = (int)(dxy * Math.Sin(perpendicular));

                            newx += fx;
                            newy += fy;

                            ByteBuffer movepacket = new ByteBuffer(29);
                            movepacket.WriteByte(0x01);
                            movepacket.WriteInt32(newx);
                            movepacket.WriteInt32(newy);
                            movepacket.WriteInt32(gs.leader.pinfo.Z);
                            movepacket.WriteInt32(pinfo.X);
                            movepacket.WriteInt32(pinfo.Y);
                            movepacket.WriteInt32(pinfo.Z);
                            movepacket.WriteInt32(1);
                            this.NewMessage(movepacket);
                            //bwaiting = true;
                        }
                        //if (gs.current[1].pinfo != null && pinfo != null)
                        //{
                        //    //if its null nothing we can do
                        //    ByteBuffer autofollowpacket = new ByteBuffer(18);
                        //    autofollowpacket.WriteByte(0x04);
                        //    autofollowpacket.WriteUInt32(gs.current[1].pinfo.ObjID); 
                        //    autofollowpacket.WriteInt32(pinfo.X);
                        //    autofollowpacket.WriteInt32(pinfo.Y);
                        //    autofollowpacket.WriteInt32(pinfo.Z);
                        //    autofollowpacket.WriteByte(0);
                        //    this.NewMessage(autofollowpacket);
                        //}
                    }
                }
                catch
                {
                    Console.WriteLine("exiting move thread");
                    return;
                }
            }
        }


        private void useItem(uint itemID)
        {
            ByteBuffer requse = new ByteBuffer(9);
            requse.WriteByte(0x19);
            requse.WriteUInt32(itemID);
            requse.WriteUInt32(0);
            NewMsgHP(requse);

        }
        public void statusmonthread()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (pinfo == null)
                    continue;

                if (gs.usebsoe && bsoeid != 0 && ((Convert.ToDouble(pinfo.Cur_CP * 100)) / Convert.ToDouble(pinfo.Max_CP)) < 50)
                {
                    useItem(bsoeid);
                    bsoeid = 0;
                }

                if (pinfo.Cur_HP <= (pinfo.Max_HP - gs.qhphp))
                {
                    if (pinfo.qhp > 0 && gs.qhp)
                    {
                        oldtime = pinfo.qhptime;
                        if (oldtime.AddMilliseconds(200) <= DateTime.Now)
                        {
                            useItem(QHP);
                            pinfo.qhptime = DateTime.Now;
                        }
                    }


                }
                if (pinfo.Cur_CP <= (pinfo.Max_CP - 200))
                {
                    //use cp pot
                    if (pinfo.cppots > 0 && gs.cppots)
                    {
                        oldtime = pinfo.cppottime;
                        if (oldtime.AddMilliseconds(200) <= DateTime.Now)
                        {
                            useItem(GCP);
                            pinfo.cppottime = DateTime.Now;
                        }
                    }
                }
                if (pinfo.Cur_HP <= (pinfo.Max_HP - gs.ghphp))
                {
                    if (pinfo.ghppots > 0 && gs.ghppots)
                    {
                        oldtime = pinfo.ghppottime;
                        if (oldtime.AddSeconds(15) <= DateTime.Now)
                        {
                            useItem(GHP);
                            pinfo.ghppottime = DateTime.Now;
                        }
                    }

                }
                if (pinfo.Cur_CP <= (pinfo.Max_CP - 50))
                {
                    if (pinfo.lesscppots > 0 && gs.cppots)
                    {
                        oldtime = pinfo.smallcppottime;
                        if (oldtime.AddMilliseconds(200) <= DateTime.Now)
                        {
                            useItem(LCP);
                            pinfo.smallcppottime = DateTime.Now;
                        }
                    }
                }
                if (pinfo.Cur_CP <= (pinfo.Max_CP - gs.cpelixir))
                {
                    if (pinfo.elixirCP_A > 0 && gs.elixir && pinfo.Level >= 61 && pinfo.Level < 76)
                    {
                        oldtime = pinfo.elixirCPtime;
                        if (oldtime.AddSeconds(300) <= DateTime.Now)
                        {
                            useItem(ECP_A);
                            pinfo.elixirCPtime = DateTime.Now;
                        }
                    }
                    if (pinfo.elixirCP_S > 0 && gs.elixir && pinfo.Level >= 76)
                    {
                        oldtime = pinfo.elixirCPtime;
                        if (oldtime.AddSeconds(300) <= DateTime.Now)
                        {
                            useItem(ECP_S);
                            pinfo.elixirCPtime = DateTime.Now;
                        }
                    }
                }
                if (pinfo.Cur_HP <= (pinfo.Max_HP - gs.hpelixir))
                {
                    if (pinfo.elixirHP_A > 0 && gs.elixir && pinfo.Level >= 61 && pinfo.Level < 76)
                    {
                        oldtime = pinfo.elixirHPtime;
                        if (oldtime.AddSeconds(300) <= DateTime.Now)
                        {
                            useItem(EHP_A);
                            pinfo.elixirHPtime = DateTime.Now;
                        }
                    }
                    if (pinfo.elixirHP_S > 0 && gs.elixir && pinfo.Level >= 76)
                    {
                        oldtime = pinfo.elixirHPtime;
                        if (oldtime.AddSeconds(300) <= DateTime.Now)
                        {
                            useItem(EHP_S);
                            pinfo.elixirHPtime = DateTime.Now;
                        }
                    }

                }
            }
        }
        public void PeriodicFunction()
        {
            return;
            ByteBuffer requestaction = new ByteBuffer(10);
            requestaction.WriteByte(0x56);
            requestaction.WriteInt32(1007);
            requestaction.WriteInt32(0);
            requestaction.WriteByte(0);
            while (true)
            {
                Thread.Sleep(60000);
                if (pinfo != null && blessing == true)
                    this.NewMessage(requestaction);
            }
        }
        #endregion

    }

}