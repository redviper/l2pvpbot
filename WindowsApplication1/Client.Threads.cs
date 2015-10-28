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
        public bool isAttacking = false;
        public class htmcommand
        {
            public string s;
            public DateTime t;
            public uint currenttarget;
        }

        #region Threads

        bool skill_use = false;

        protected void useShotFunc()
        {
            if (useshot == null)
                return;
            ByteBuffer requse = new ByteBuffer(9);
            requse.WriteByte(0x19);
            requse.WriteUInt32(useshot.objid);
            requse.WriteUInt32(0);
            NewMessage(requse);
        }

        public void skillfunction()
        {
            ByteBuffer actionmsg = new ByteBuffer(18);
            actionmsg.WriteByte(0x1f);

            int actionindex = actionmsg.GetIndex();

            ByteBuffer cancelpacket = new ByteBuffer(3);
            cancelpacket.WriteByte(0x48);
            cancelpacket.WriteInt16(1);

            bool doskill;// = false;

            while (true)
            {
                try
                {
                    //isAttacking = false;
                        //Thread.Sleep(500);

                    if (gs.leader != null && gs.leader.targetid == 0)
                        Thread.Sleep(500);

                    while (startdance)
                    {
                        Thread.Sleep(100);
                    }
                    #region SelectTarget
                    if (gs.TargetterID != 0 && this == gs.leader && gs.allplayerinfo.ContainsKey(gs.TargetterID))
                    {
                        targetid = gs.allplayerinfo[gs.TargetterID].TargetID;
                    }

                    if (gs.battack == true)
                    {
                        CharInfo mytarget = gs.target;
                        if (mytarget != null && this == gs.leader)
                        {
                            if (targetid != mytarget.ID)
                            {
                                actionmsg.SetIndex(actionindex);
                                actionmsg.WriteUInt32(mytarget.ID);
                                actionmsg.WriteInt32(pinfo.X);
                                actionmsg.WriteInt32(pinfo.Y);
                                actionmsg.WriteInt32(pinfo.Z);
                                actionmsg.WriteByte(1);

                                NewMsgHP(actionmsg);
                            }
                            targetid = mytarget.ID;

                            if (mytarget.peace == 1 || ((mytarget.AbnormalEffects & gs.medusastate) != 0)
                                        || mytarget.isAlikeDead == 1)
                            {

                                //I am leader!
                                if (this == gs.leader)
                                {
                                    if (gs.targetselection.ThreadState == ThreadState.WaitSleepJoin)
                                    {
                                        //NewMsgHP(cancelpacket);
                                     //   gs.targetselection.Interrupt();
                                    }
                                    continue;
                                }
                                else
                                {
                                    isAttacking = false;
                                    continue;
                                }
                            }
                        }
                    }


                    if (skillattack != true)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                    #endregion

                    if ((gs.AssistLeader == true || gs.battack == true) && skillattack == true)
                    {
                        uint targ;
                        if (gs.leader != null)
                            targ = gs.leader.targetid;
                        else
                            continue;

                        if (targ != 0 && gs.enemylist.ContainsKey(targ))
                        {
                            //is an enemy
                            //ATTACK!
                            //if you are attacking you shouldn't be following
                            CharInfo mytarget2 = gs.enemylist[targ];
                            if (mytarget2.isAlikeDead == 1)
                            {
                                isAttacking = false;
                                NewMsgHP(cancelpacket);
                                continue;
                            }
                            isAttacking = true;

                            if (targetid != mytarget2.ID)
                            {

                                actionmsg.SetIndex(actionindex);
                                actionmsg.WriteUInt32(mytarget2.ID);
                                actionmsg.WriteInt32(pinfo.X);
                                actionmsg.WriteInt32(pinfo.Y);
                                actionmsg.WriteInt32(pinfo.Z);
                                actionmsg.WriteByte(1);

                                NewMsgHP(actionmsg);
                            }

                            lock (aslock)
                            {
                                foreach (AttackSkills a in askills)
                                {
                                    if (mytarget2.peace == 1 || ((mytarget2.AbnormalEffects & gs.medusastate) != 0)
                                           || mytarget2.isAlikeDead == 1)
                                    {

                                        //I am leader!
                                        //if (this == gs.leader)
                                        //{
                                        //    if (gs.targetselection.ThreadState == ThreadState.WaitSleepJoin)
                                        //        gs.targetselection.Interrupt();
                                        //    break;
                                        //}
                                        //else
                                        break;
                                    }
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
                                                    if (mytarget2.Cur_HP == a.value)
                                                        doskill = true;
                                                    break;
                                                case 1: //>
                                                    if (mytarget2.Cur_HP > a.value)
                                                        doskill = true;
                                                    break;
                                                case 2: //<
                                                    if (mytarget2.Cur_HP < a.value)
                                                        doskill = true;
                                                    break;
                                            }
                                            break;
                                        case 2: //distance
                                            double distance =
                                                System.Math.Sqrt(Math.Pow((pinfo.X - mytarget2.X), 2)
                                                + Math.Pow((pinfo.Y - mytarget2.Y), 2) + Math.Pow(pinfo.Z - mytarget2.Z, 2));
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
                                        case 3://once
                                            if (a.used == mytarget2.ID)
                                                doskill = false;
                                            else
                                                doskill = true;
                                            break;
                                    }
                                    if (doskill == true)
                                    {
                                        useShotFunc();

                                        launchMagic(a.useskill, mytarget2.ID, Convert.ToInt32(shiftattack));
                                        if (a.useskill.skillstate())
                                            a.used = mytarget2.ID;
                                    }
                                }
                            }
                        }
                        else if (targ != 0 && gs.moblist.ContainsKey(targ))
                        {
                            //attack the mob
                            NPC mob = gs.moblist[targ];
                            if (mob.isAlikeDead)
                            {
                                isAttacking = false;
                                NewMsgHP(cancelpacket);
                                continue;
                            }
                            isAttacking = true;

                            if (targetid != mob.objid)
                            {

                                actionmsg.SetIndex(actionindex);
                                actionmsg.WriteUInt32(mob.objid);
                                actionmsg.WriteInt32(pinfo.X);
                                actionmsg.WriteInt32(pinfo.Y);
                                actionmsg.WriteInt32(pinfo.Z);
                                actionmsg.WriteByte(1);

                                NewMsgHP(actionmsg);
                            }

                            lock (aslock)
                            {
                                foreach (AttackSkills a in askills)
                                {
                                    if (mob.isAlikeDead == true)
                                    {

                                        //I am leader!
                                        //if (this == gs.leader)
                                        //{
                                        //    if (gs.targetselection.ThreadState == ThreadState.WaitSleepJoin)
                                        //        gs.targetselection.Interrupt();
                                        //    break;
                                        //}
                                        //else
                                        isAttacking = false;
                                        NewMsgHP(cancelpacket);
                                        break;
                                    }
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
                                                    if (mob.Cur_HP == a.value)
                                                        doskill = true;
                                                    break;
                                                case 1: //>
                                                    if (mob.Cur_HP > a.value)
                                                        doskill = true;
                                                    break;
                                                case 2: //<
                                                    if (mob.Cur_HP < a.value)
                                                        doskill = true;
                                                    break;
                                            }
                                            break;
                                        case 2: //distance
                                            double distance =
                                                System.Math.Sqrt(Math.Pow((pinfo.X - mob.posX), 2)
                                                + Math.Pow((pinfo.Y - mob.posY), 2) + Math.Pow(pinfo.Z - mob.posZ, 2));
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
                                        case 3://once
                                            if (a.used == mob.objid)
                                                doskill = false;
                                            else
                                                doskill = true;
                                            break;
                                    }
                                    if (doskill == true)
                                    {
                                        skill_use = true;
                                        useShotFunc();
                                        launchMagic(a.useskill, mob.objid, Convert.ToInt32(shiftattack));
                                        if (a.useskill.skillstate())
                                        {
                                            Console.WriteLine("Used skill {0}", a.useskill.name);
                                            a.used = mob.objid;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Couldn't use skill {0}", a.useskill.name);
                                        }

                                        skill_use = false;

                                    }
                                }
                            }
                        }
                        else
                        {
                            isAttacking = false;
                        }

                    }

                }
                catch (ThreadAbortException e)
                {
                    return;
                }
                catch
                {
                    //Console.WriteLine("Thread interrupted");

                }
            }
        }

        ManualResetEvent attack_mre = new ManualResetEvent(false);
        ManualResetEvent skill_mre = new ManualResetEvent(false);

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

            ByteBuffer validateposition = new ByteBuffer(21);
            validateposition.WriteByte(0x59);
            int valposindex = validateposition.GetIndex();

            ByteBuffer data = new ByteBuffer(0x12);
            data.WriteByte(0x01);
            //data.WriteUInt32(target.ID);
            int index = data.GetIndex();


            useshot = null;

            while (true)
            {
                //    isAttacking = false;

                try
                {
                    while (skill_use)
                        Thread.Sleep(500);

                    Thread.Sleep(500);

                    if (gs.leader != null && gs.leader.targetid == 0)
                        Thread.Sleep(500);


                    while (startdance)
                    {
                        Thread.Sleep(100);
                    }
                    if (gs.TargetterID != 0 && this == gs.leader && gs.allplayerinfo.ContainsKey(gs.TargetterID))
                    {
                        targetid = gs.allplayerinfo[gs.TargetterID].TargetID;
                    }

                    if (gs.battack == true)
                    {
                        CharInfo mytarget = gs.target;
                        if (mytarget != null && this == gs.leader)
                        {
                            if (targetid != mytarget.ID)
                            {
                                actionmsg.SetIndex(actionindex);
                                actionmsg.WriteUInt32(mytarget.ID);
                                actionmsg.WriteInt32(pinfo.X);
                                actionmsg.WriteInt32(pinfo.Y);
                                actionmsg.WriteInt32(pinfo.Z);
                                actionmsg.WriteByte(1);

                                NewMessage(actionmsg);
                            }
                            targetid = mytarget.ID;
                        }
                        if (mytarget != null)
                        {
                            if (mytarget.peace == 1 || ((mytarget.AbnormalEffects & gs.medusastate) != 0)
                                        || mytarget.isAlikeDead == 1)
                            {

                                //I am leader!
                                if (this == gs.leader)
                                {
                                    NewMessage(cancelpacket);
                                    //if (gs.targetselection.ThreadState == ThreadState.WaitSleepJoin)
                                    //    gs.targetselection.Interrupt();
                                    continue;
                                }
                                else
                                {
                                    NewMessage(cancelpacket);
                                    isAttacking = false;
                                    continue;
                                }
                            }
                        }
                    }

                    if (battack != true)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    if (gs.leader != null && (gs.AssistLeader == true || gs.battack == true) && battack == true)
                    {
                        
                        uint targ = gs.leader.targetid;


                        if (targ != 0 && gs.enemylist.ContainsKey(targ))
                        {
                            //is an enemy
                            //ATTACK!
                            //if you are attacking you shouldn't be following
                            CharInfo mytarget2 = gs.enemylist[targ];


                            if (mytarget2.isAlikeDead == 1)
                            {
                                NewMessage(cancelpacket);
                                isAttacking = false;
                                attacking = 0;
                                continue;
                            }

                            if (isAttacking && attacking == targ)
                            {
                                //auto attacking
                                attacking = 0;
                                Thread.Sleep(1000);
                            }


                            isAttacking = true;

                            if (targetid != pinfo.ObjID)
                            {
                                actionmsg.SetIndex(actionindex);
                                actionmsg.WriteUInt32(targ);
                                actionmsg.WriteInt32(pinfo.X);
                                actionmsg.WriteInt32(pinfo.Y);
                                actionmsg.WriteInt32(pinfo.Z);
                                actionmsg.WriteByte(1);
                                NewMessage(actionmsg);
                            }
                            data.SetIndex(index);
                            double distance = 0.0;
                            distance = System.Math.Sqrt(Math.Pow((pinfo.X - mytarget2.X), 2) + Math.Pow((pinfo.Y - mytarget2.Y), 2) + Math.Pow(pinfo.Z - mytarget2.Z, 2));
                            if (distance <= (adist + 25))
                            {
                                useShotFunc();

                                data.WriteUInt32(mytarget2.ID);
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
                                validateposition.WriteInt32(pinfo.Airship);
                                validateposition.WriteInt32(0);


                                NewMessage(data);
                                attacking = targ;
                            }

                        }
                        else if (targ != 0 && gs.moblist.ContainsKey(targ))
                        {
                            //attack the mob
                            NPC mob = gs.moblist[targ];
                            if (mob.isAlikeDead)
                            {
                                NewMessage(cancelpacket);
                                isAttacking = false;
                                attacking = 0;
                                continue;
                            }
                            if(isAttacking && attacking == targ)
                            {
                                //auto attacking
                                attacking = 0;
                                Thread.Sleep(1000);
                            }
                           
                            isAttacking = true;
                            if (targetid != mob.objid)
                            {
                                actionmsg.SetIndex(actionindex);
                                actionmsg.WriteUInt32(targ);
                                actionmsg.WriteInt32(pinfo.X);
                                actionmsg.WriteInt32(pinfo.Y);
                                actionmsg.WriteInt32(pinfo.Z);
                                actionmsg.WriteByte(1);
                                NewMessage(actionmsg);
                            }
                            data.SetIndex(index);
                            double distance = 0.0;
                            distance = System.Math.Sqrt(Math.Pow((pinfo.X - mob.posX), 2) + Math.Pow((pinfo.Y - mob.posY), 2) + Math.Pow(pinfo.Z - mob.posZ, 2));
                            if (distance <= (adist + 25))
                            {
                                useShotFunc();

                                data.WriteUInt32(targ);
                                data.WriteInt32(pinfo.X);
                                data.WriteInt32(pinfo.Y);
                                data.WriteInt32(pinfo.Z);
                                if (shiftattack == true)
                                    data.WriteByte(1);
                                else
                                    data.WriteByte(0);
                                NewMessage(data);
                                attacking = targ;
                            }
                        }
                        else
                        {
                            isAttacking = false;
                        }

                    }
                    else
                    {
                        isAttacking = false;
                    }

                }
                catch (ThreadAbortException e)
                {
                    return;
                }
                catch
                {
                    //Console.WriteLine("Exception but ignoring");

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

            ByteBuffer validateposition = new ByteBuffer(21);
            validateposition.WriteByte(0x59);
            int valposindex = validateposition.GetIndex();
            bool doskill;// = false;


            while (true)
            {
                Thread.Sleep(1000);
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
                                    useskillmsg.WriteUInt32(a.useskill.id);
                                    NewMessage(actionmsg);
                                    NewMessage(useskillmsg);

                                    validateposition.SetIndex(valposindex);
                                    validateposition.WriteInt32(pinfo.X);
                                    validateposition.WriteInt32(pinfo.Y);
                                    validateposition.WriteInt32(pinfo.Z);
                                    validateposition.WriteInt32(pinfo.Airship);
                                    validateposition.WriteInt32(0);
                                    NewMessage(validateposition);
                                }
                                Thread.Sleep(250);
                            }
                        }
                    }
                }
            }
        }
        public bool autofollow;
        public bool autotalk;
        public int followdistance;
        public int talktime;

        public Object commandlock;

        public void movepawnthread()
        {
            int newx, newy;

            int condition = x.Next(50);
            List<htmcommand> discard = new List<htmcommand>();
            while (true)
            {
                try
                {
                    Thread.Sleep(500);
                    if (gs.leader == null || pinfo == null || gs.leader.pinfo == null)
                        continue;
                    while (gs.leader == this)
                        Thread.Sleep(10000);

                    if (autofollow && !isAttacking)
                    {
                        int fx = gs.leader.pinfo.X;
                        int fy = gs.leader.pinfo.Y;
                        int fz = gs.leader.pinfo.Z;
                        int ox = pinfo.X;
                        int oy = pinfo.Y;
                        int oz = pinfo.Z;

                        double distance = 0.0;
                        distance = System.Math.Sqrt(Math.Pow((pinfo.X - fx), 2) + Math.Pow((pinfo.Y - fy), 2) + Math.Pow(pinfo.Z - fz, 2));

                        int dx = pinfo.X - fx;
                        int dy = pinfo.Y - fy;

                        if (distance > (followdistance * 2) && distance < 2000)
                        {
                            double degree = convertHeadingToDegree(gs.leader.pinfo.Airship);


                            double perpendicular;
                            if (condition % 2 == 0)
                            {
                                perpendicular = degree - 90;
                            }
                            else
                            {
                                perpendicular = degree + 90;
                            }

                            int dxy = x.Next(0, followdistance);

                            newx = (int)(dxy * Math.Cos(perpendicular));
                            newy = (int)(dxy * Math.Sin(perpendicular));

                            newx += fx;
                            newy += fy;

                            ByteBuffer mpacket = new ByteBuffer(29);
                            mpacket.WriteByte(0x0f);
                            mpacket.WriteInt32(newx);
                            mpacket.WriteInt32(newy);
                            mpacket.WriteInt32(fz);

                            mpacket.WriteInt32(ox);
                            mpacket.WriteInt32(oy);
                            mpacket.WriteInt32(oz);
                            mpacket.WriteInt32(1);
                            this.NewMessage(mpacket);
                            //ByteBuffer movepacket = new ByteBuffer(29);
                            //movepacket.WriteByte(0x01);
                            //movepacket.WriteInt32(newx);
                            //movepacket.WriteInt32(newy);
                            //movepacket.WriteInt32(gs.leader.pinfo.Z);
                            //movepacket.WriteInt32(pinfo.X);
                            //movepacket.WriteInt32(pinfo.Y);
                            //movepacket.WriteInt32(pinfo.Z);
                            //movepacket.WriteInt32(1);
                            //this.NewMessage(movepacket);
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
                    if (autotalk && !isAttacking)
                    {
                        if (commandlist.Count > 0)
                        {
                            //command list has items
                            try
                            {
                                lock (commandlock)
                                {

                                    foreach (htmcommand h in commandlist)
                                    {
                                        try
                                        {
                                            DateTime n = DateTime.Now;
                                            double fudgefactor = x.NextDouble();
                                            if (n >= h.t.AddSeconds(talktime + fudgefactor))
                                            {
                                                ByteBuffer action = new ByteBuffer();
                                                action.WriteByte(0x1f);
                                                action.WriteUInt32(h.currenttarget);
                                                action.WriteInt32(pinfo.X);
                                                action.WriteInt32(pinfo.Y);
                                                action.WriteInt32(pinfo.Z);
                                                action.WriteByte(0);

                                                this.NewMessage(action);
                                                this.NewMessage(action);

                                                ByteBuffer htmlCommand = new ByteBuffer();
                                                htmlCommand.WriteByte(0x23);
                                                htmlCommand.WriteString(h.s);
                                                this.NewMessage(htmlCommand);
                                                discard.Add(h);
                                            }
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    try
                                    {
                                        foreach (htmcommand d in discard)
                                        {
                                            commandlist.Remove(d);
                                        }
                                        discard.Clear();
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.ToString());
                                    }

                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        commandlist.Clear();
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
            NewMessage(requse);

        }
        public void statusmonthread()
        {
            int sleeptime = 100;
            int cpspamtime = 200;
            DateTime cpelixirtime;
            DateTime hpelixirtime;
            DateTime qhptime;
            DateTime gcptime;
            DateTime cptime;
            DateTime ghptime;
            pinfo.qhptime = DateTime.Now.AddMinutes(-60);
            pinfo.ghppottime = DateTime.Now.AddMinutes(-60);
            pinfo.cppottime = DateTime.Now.AddMinutes(-60);
            pinfo.smallcppottime = DateTime.Now.AddMinutes(-60);
            pinfo.elixirCPtime = DateTime.Now.AddMinutes(-60);
            pinfo.elixirHPtime = DateTime.Now.AddMinutes(-60);

            while (true)
            {
                try
                {
                    if (sleeptime < 0)
                        sleeptime = 10;
                    Thread.Sleep(sleeptime);
                    //Thread.Sleep(10);
                    sleeptime = 50;
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
                            if (oldtime.AddMilliseconds(cpspamtime) <= DateTime.Now)
                            {
                                useItem(QHP);
                                pinfo.qhptime = DateTime.Now;
                            }
                            else
                            {
                                //not soon enough to use pot
                                sleeptime = (oldtime.AddMilliseconds(cpspamtime) - DateTime.Now).Milliseconds;
                                if (sleeptime > 100)
                                    sleeptime = 100;
                            }
                        }
                    }
                    if (gs.bPercentRecover)
                    {
                        //recover to the given percentage by spamming both small and big CP together
                        if (pinfo.Cur_CP <= (gs.PercentRecover / 100.0) * pinfo.Max_CP)
                        {
                            if (pinfo.lesscppots > 0 && gs.cppots)
                            {
                                oldtime = pinfo.smallcppottime;
                                if (oldtime.AddMilliseconds(cpspamtime) <= DateTime.Now)
                                {
                                    useItem(LCP);
                                    pinfo.smallcppottime = DateTime.Now;
                                }
                                else
                                {
                                    //not soon enough to use pot
                                    sleeptime = (oldtime.AddMilliseconds(cpspamtime) - DateTime.Now).Milliseconds;
                                    if (sleeptime > 100)
                                        sleeptime = 100;
                                }

                            }
                            if (pinfo.cppots > 0 && gs.cppots)
                            {
                                oldtime = pinfo.cppottime;
                                if (oldtime.AddMilliseconds(cpspamtime) <= DateTime.Now)
                                {
                                    useItem(GCP);
                                    pinfo.cppottime = DateTime.Now;
                                }
                                else
                                {
                                    //not soon enough to use pot
                                    sleeptime = (oldtime.AddMilliseconds(cpspamtime) - DateTime.Now).Milliseconds;
                                    if (sleeptime > 100)
                                        sleeptime = 100;
                                }

                            }
                        }
                    }
                    if (!gs.bPercentRecover && pinfo.Cur_CP <= (pinfo.Max_CP - 50))
                    {
                        if (pinfo.lesscppots > 0 && gs.cppots)
                        {
                            oldtime = pinfo.smallcppottime;
                            if (oldtime.AddMilliseconds(cpspamtime) <= DateTime.Now)
                            {
                                useItem(LCP);
                                pinfo.smallcppottime = DateTime.Now;
                            }
                            else
                            {
                                //not soon enough to use pot
                                sleeptime = (oldtime.AddMilliseconds(cpspamtime) - DateTime.Now).Milliseconds;
                                if (sleeptime > 100)
                                    sleeptime = 100;
                            }

                        }
                    }
                    if (!gs.bPercentRecover && pinfo.Cur_CP <= (pinfo.Max_CP - 200))
                    {
                        //use cp pot
                        if (pinfo.cppots > 0 && gs.cppots)
                        {
                            oldtime = pinfo.cppottime;
                            if (oldtime.AddMilliseconds(cpspamtime) <= DateTime.Now)
                            {
                                useItem(GCP);
                                pinfo.cppottime = DateTime.Now;
                            }
                            else
                            {
                                //not soon enough to use pot
                                sleeptime = (oldtime.AddMilliseconds(cpspamtime) - DateTime.Now).Milliseconds;
                                if (sleeptime > 100)
                                    sleeptime = 100;
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

                    if (pinfo.Cur_CP <= (pinfo.Max_CP - gs.cpelixir))
                    {
                        if (pinfo.elixirCP_A > 0 && gs.elixir && pinfo.Level >= 61 && pinfo.Level < 76)
                        {
                            oldtime = pinfo.elixirCPtime;
                            if (oldtime.AddSeconds(301) <= DateTime.Now)
                            {
                                useItem(ECP_A);
                                pinfo.elixirCPtime = DateTime.Now;
                            }
                        }
                        if (pinfo.elixirCP_S > 0 && gs.elixir && pinfo.Level >= 76)
                        {
                            oldtime = pinfo.elixirCPtime;
                            if (oldtime.AddSeconds(301) <= DateTime.Now)
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
                            if (oldtime.AddSeconds(301) <= DateTime.Now)
                            {
                                useItem(EHP_A);
                                pinfo.elixirHPtime = DateTime.Now;
                            }
                        }
                        if (pinfo.elixirHP_S > 0 && gs.elixir && pinfo.Level >= 76)
                        {
                            oldtime = pinfo.elixirHPtime;
                            if (oldtime.AddSeconds(301) <= DateTime.Now)
                            {
                                useItem(EHP_S);
                                pinfo.elixirHPtime = DateTime.Now;
                            }
                        }

                    }
                }
                catch (ThreadAbortException e)
                {
                    return;
                }
                catch (Exception e)
                {

                }
            }
        }
        public void PeriodicFunction()
        {
            //return;
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

        public Queue<PlayerBuffs> rebuffqueue;
        public object rebufflock;

        public void singlebufffunction()
        {

            PlayerBuffs currentbuff = null;
            ByteBuffer useskillmsg = new ByteBuffer(10);
            useskillmsg.WriteByte(0x39);
            int skillindex = useskillmsg.GetIndex();
            useskillmsg.WriteUInt32(0);
            useskillmsg.WriteUInt32(1);
            int shiftindex = useskillmsg.GetIndex();
            useskillmsg.WriteByte(0x00);
            sbuff_mre.Reset();

            while (true)
            {
                while (rebuffqueue.Count == 0)
                    sbuff_mre.WaitOne(1000, true);
                sbuff_mre.Reset();
                lock (rebufflock)
                {
                    currentbuff = rebuffqueue.Dequeue();
                    if (currentbuff == null)
                        continue;
                }
                doBuff(useskillmsg, skillindex, currentbuff);
            }

        }

        public void bufffunction()
        {
            ByteBuffer useskillmsg = new ByteBuffer(10);
            useskillmsg.WriteByte(0x39);
            int skillindex = useskillmsg.GetIndex();
            useskillmsg.WriteUInt32(0);
            useskillmsg.WriteUInt32(1);
            int shiftindex = useskillmsg.GetIndex();
            useskillmsg.WriteByte(0x00);

            while (true)
            {
                //wait until this is signaled
                try
                {
                    buff_mre.WaitOne();
                    lock (bufflock)
                    {
                        foreach (PlayerBuffs p in bufflist)
                        {
                            doBuff(useskillmsg, skillindex, p);

                        }
                    }
                    buff_mre.Reset();
                }
                catch (ThreadAbortException e)
                {
                    return;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
            }
        }

        private void doBuff(ByteBuffer useskillmsg, int skillindex, PlayerBuffs p)
        {
            if (p.objid == 0 && p.self != true)
            {
                //we haven't found the player yet
                //search in allplayerinfo
                CharInfo[] cinfos = new CharInfo[gs.allplayerinfo.Count];
                gs.allplayerinfo.Values.CopyTo(cinfos, 0);
                foreach (CharInfo cinfo in cinfos)
                {
                    if (p.player == cinfo.Name)
                    {
                        p.objid = cinfo.ID;
                    }
                }

            }

            if (p.objid != 0)
            {
                //target the guy
                //execute the list of skills on him
                ByteBuffer action = new ByteBuffer();
                action.WriteByte(0x1f);
                action.WriteUInt32(p.objid);
                action.WriteInt32(pinfo.X);
                action.WriteInt32(pinfo.Y);
                action.WriteInt32(pinfo.Z);
                action.WriteByte(0);

                NewMessage(action);
                p.lastuse = DateTime.Now;
                foreach (skill s in p.bufflist.Values)
                {
                    if (s.lastuse.AddMilliseconds(s.reuseDelay) > DateTime.Now)
                    {
                        ReSkill r = new ReSkill(s, p.objid);
                        lock (redolistlock)
                        {
                            redolist.Enqueue(r);
                        }
                        continue;
                    }
                    useskillmsg.SetIndex(skillindex);
                    useskillmsg.WriteUInt32(s.id);
                    NewMessage(useskillmsg);
                    s.mre.WaitOne(10000);
                    s.mre.Reset();
                    if (s.skillstate())
                    {
                        System.Threading.Thread.Sleep((int)s.hitTime);
                    }
                    else
                    {
                        ReSkill r = new ReSkill(s, p.objid);
                        lock (redolistlock)
                        {
                            redolist.Enqueue(r);
                        }
                    }
                    //wait for response
                    //s.lastuse = DateTime.Now;

                }

            }
            else if (p.self)
            {
                p.lastuse = DateTime.Now;
                foreach (skill s in p.bufflist.Values)
                {
                    if (s.lastuse.AddMilliseconds(s.reuseDelay) > DateTime.Now)
                    {
                        ReSkill r = new ReSkill(s, p.objid);
                        lock (redolistlock)
                        {
                            redolist.Enqueue(r);
                        }
                        continue;
                    }
                    useskillmsg.SetIndex(skillindex);
                    useskillmsg.WriteUInt32(s.id);
                    NewMessage(useskillmsg);
                    s.mre.WaitOne(10000);
                    s.mre.Reset();
                    if (s.skillstate())
                    {
                        System.Threading.Thread.Sleep((int)s.hitTime);
                    }
                    else
                    {
                        ReSkill r = new ReSkill(s, p.objid);
                        lock (redolistlock)
                        {
                            redolist.Enqueue(r);
                        }
                    }
                    //wait for response
                    //s.lastuse = DateTime.Now;

                }

            }
        }

        private void launchBuff(skill s, uint objectid, int shift)
        {
            if (s.lastuse.AddMilliseconds(s.reuseDelay) > DateTime.Now)
            {
                ReSkill r = new ReSkill(s, objectid);
                lock (redolistlock)
                {
                    redolist.Enqueue(r);
                }

                return;
            }
            s.setstate(false);
            s.mre.Reset();
            useSkill(s.id, objectid, shift);
            s.mre.WaitOne(2000);
            s.mre.Reset();
            if (s.skillstate())
            {
                //wait for response
                s.lastuse = DateTime.Now;
                System.Threading.Thread.Sleep((int)s.hitTime);
            }
            else
            {
                //System.Console.WriteLine("skill failed");
                ReSkill r = new ReSkill(s, objectid);
                lock (redolistlock)
                {
                    redolist.Enqueue(r);
                }
            }
        }

        private void launchMagic(skill s, uint objectid, int shift)
        {


            if (s.lastuse.AddMilliseconds(s.reuseDelay) > DateTime.Now)
            {
                return;
            }
            s.setstate(false);
            s.mre.Reset();
            useSkill(s.id, objectid, shift);
            s.mre.WaitOne(5000);
            s.mre.Reset();
            if (s.skillstate())
            {
                //wait for response               
                System.Threading.Thread.Sleep((int)s.hitTime);
            }
            else
            {
                //System.Console.WriteLine("skill failed");

            }
        }

        private void useSkill(uint skillid,
                uint objectid, int shift)
        {

            if (targetid != objectid && objectid != 0)
            {
                ByteBuffer action = new ByteBuffer();
                action.WriteByte(0x1f);
                action.WriteUInt32(objectid);
                action.WriteInt32(pinfo.X);
                action.WriteInt32(pinfo.Y);
                action.WriteInt32(pinfo.Z);
                action.WriteByte(1);

                NewMessage(action);
            }

            ByteBuffer useskillmsg = new ByteBuffer(10);
            useskillmsg.WriteByte(0x39);
            useskillmsg.WriteUInt32(skillid);
            useskillmsg.WriteUInt32(1);
            int shiftindex = useskillmsg.GetIndex();
            if (shift == 1)
                useskillmsg.WriteByte(1);
            else
                useskillmsg.WriteByte(0);

            NewMessage(useskillmsg);

            ByteBuffer validateposition = new ByteBuffer(21);
            validateposition.WriteByte(0x59);
            validateposition.WriteInt32(pinfo.X);
            validateposition.WriteInt32(pinfo.Y);
            validateposition.WriteInt32(pinfo.Z);
            validateposition.WriteInt32(pinfo.Airship);
            validateposition.WriteInt32(0);
            NewMessage(validateposition);
        }

        public void PartyMonitorFunction()
        {

        }

        public void fightbufffunction()
        {
            ByteBuffer useskillmsg = new ByteBuffer(10);
            useskillmsg.WriteByte(0x39);
            int skillindex = useskillmsg.GetIndex();
            useskillmsg.WriteUInt32(0);
            useskillmsg.WriteUInt32(1);
            int shiftindex = useskillmsg.GetIndex();
            useskillmsg.WriteByte(0x00);

            while (true)
            {
                //wait until this is signaled
                try
                {
                    fightbuff_mre.WaitOne();
                    foreach (PlayerBuffs p in fightbufflist)
                    {
                        doBuff(useskillmsg, skillindex, p);

                    }

                    fightbuff_mre.Reset();
                }
                catch (ThreadAbortException e)
                {
                    return;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
            }
        }
        public ManualResetEvent item_mre;

        public void itemfunction()
        {
            while (true)
            {
                item_mre.WaitOne();
                item_mre.Reset();
                foreach (ClientItems i in useItems)
                {
                    useItem(i.inventory.ObjID);
                }
            }
        }

        System.Collections.Queue danceq;
        System.Threading.ManualResetEvent dancemre;
        bool startdance = false;
        public void dancefunction()
        {
            danceq = new Queue();
            dancemre = new ManualResetEvent(false);
            evtSkill s;

            while (true)
            {
                dancemre.WaitOne();

                if (gs.buffs == false)
                {
                    lock (dancelock)
                    {
                        danceq.Clear();

                    }
                }

                while (danceq.Count > 0)
                {
                    startdance = true;
                    lock (dancelock)
                    {
                        if (danceq.Count == 0)
                            continue;

                        s = (evtSkill)danceq.Dequeue();
                    }
                    //System.Console.WriteLine("launching skill {0} - event {1}", s.act.name, s.evt.name);
                    s.succeed = false;

                    launchMagic(s.act, 0, 0);
                    //bool ret = s.mre.WaitOne(3000);
                    //s.mre.Reset();
                    if (s.succeed || s.act.skillstate())
                    {

                        ////skill succeeded
                        //probably do nothing?
                        //Console.WriteLine("skill {0} succeeded", s.act.name);
                        s.act.setstate(false);

                    }
                    else
                    {
                        //skill failed .. requeue
                        //                        Console.WriteLine("skill {0} failed", s.act.name);
                        lock (dancelock)
                        {
                            ReSkill r = new ReSkill(s.act, 0);
                            redolist.Enqueue(r);
                        }
                    }
                }
                startdance = false;
                dancemre.Reset();
            }
        }

        Queue<ReSkill> redolist;
        object redolistlock;
        void timebufffunction()
        {
            ByteBuffer useskillmsg = new ByteBuffer(10);
            useskillmsg.WriteByte(0x39);
            int skillindex = useskillmsg.GetIndex();
            useskillmsg.WriteUInt32(0);
            useskillmsg.WriteUInt32(1);
            int shiftindex = useskillmsg.GetIndex();
            useskillmsg.WriteByte(0x00);
            ReSkill redoskill = null;


            while (true)
            {
                
                Thread.Sleep(1000);
                lock (bufflock)
                {
                    if (gs.buffs == false)
                    {
                        lock (redolistlock)
                        {
                            redolist.Clear();
                        }
                        continue;
                    }

                    foreach (PlayerBuffs p in bufflist)
                    {
                        if (p.lastuse.AddMinutes(p.bufftimer) <= DateTime.Now)
                        {
                            doBuff(useskillmsg, skillindex, p);
                        }
                    }
                    int count = redolist.Count;
                    for (int i = 0; i < count; i++)
                    {
                        lock (redolistlock)
                        {
                            redoskill = redolist.Dequeue();
                        }
                        launchBuff(redoskill.s, redoskill.objid, 0);
                    }

                }

            }
        }

        #endregion

    }

    class ReSkill
    {
        public uint objid;
        public skill s;

        public ReSkill(skill _s, uint _oid)
        {
            objid = _oid;
            s = _s;
        }
    }
}