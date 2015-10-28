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
        private void packetStatusUpdate(ByteBuffer data)
        {
            uint objid = data.ReadUInt32();
            if (pinfo.ObjID == objid)
            {
                uint size = data.ReadUInt32();
                for (int i = 0; i < size; i++)
                {
                    pinfo.Update(data);
                }
            }
            else
            {
                if (gs.leader == this)
                {
                    //main toon - update non player objects also
                    uint size = data.ReadUInt32();
                    CharInfo c = null;
                    if (gs.allplayerinfo.ContainsKey(objid))
                    {
                        c = gs.allplayerinfo[objid];
                        for (int i = 0; i < size; i++)
                        {
                            c.Update(data);
                        }
                        if (gs.enemylist.ContainsKey(objid))
                        {
                            gs.enemylist[objid] = c;
                        }
                        if (gs.playerlist.ContainsKey(objid))
                        {
                            gs.playerlist[objid] = c;
                        }
                        if (gs.target != null)
                        {
                            if (objid == gs.target.ID)
                            {
                                gs.target = c;

                            }
                        }
                    }
                }
            }
        }

        private void packetInventoryUpdate(ByteBuffer data)
        {
            ushort itemcount = data.ReadUInt16();
            for (ushort i = 0; i < itemcount; i++)
            {
                ushort changetype = data.ReadUInt16();
                InventoryInfo inv = new InventoryInfo();
                inv.Load(data);
                if (inv.ItemID == 5592)
                {
                    //cp pots
                    pinfo.cppots = inv.Count;
                    GCP = inv.ObjID;
                }
                else if (inv.ItemID == 5591)
                {
                    pinfo.lesscppots = inv.Count;
                    LCP = inv.ObjID;
                }
                else if (inv.ItemID == 1540)
                {
                    pinfo.qhp = inv.Count;
                    QHP = inv.ObjID;
                }
                else if (inv.ItemID == 1539)
                {
                    pinfo.ghppots = inv.Count;
                    GHP = inv.ObjID;
                }
                else if (inv.ItemID == 5858)
                {
                    //clan hall bsoe
                    bsoeid = inv.ObjID;
                }
                else
                {
                    foreach (shots s in gs.shotlist)
                    {
                        if (s.id == inv.ItemID)
                        {
                            s.objid = inv.ObjID;
                        }
                    }
                }
                if (pinfo.Level >= 61)
                {
                    //can use a grade
                    if (pinfo.Level >= 76)
                    {
                        // can use s grade
                        if (inv.ItemID == 8627)
                        {
                            pinfo.elixirHP_S = inv.Count;
                            EHP_S = inv.ObjID;
                        }
                        if (inv.ItemID == 8639)
                        {
                            pinfo.elixirCP_S = inv.Count;
                            ECP_S = inv.ObjID;
                        }
                    }
                    else
                    {
                        if (inv.ItemID == 8638)
                        {
                            pinfo.elixirCP_A = inv.Count;
                            ECP_A = inv.ObjID;
                        }
                        if (inv.ItemID == 8626)
                        {
                            pinfo.elixirHP_A = inv.Count;
                            EHP_A = inv.ObjID;
                        }

                    }
                }
            }
        }

        private void packetItemList(ByteBuffer data)
        {
            ushort showindow = data.ReadUInt16();
            ushort itemcount = data.ReadUInt16();
            for (ushort i = 0; i < itemcount; i++)
            {
                InventoryInfo inv = new InventoryInfo();
                inv.Load(data);
                if (inv.ItemID == 5592)
                {
                    //cp pots
                    pinfo.cppots = inv.Count;
                    GCP = inv.ObjID;
                }
                else if (inv.ItemID == 5591)
                {
                    pinfo.lesscppots = inv.Count;
                    LCP = inv.ObjID;
                }
                else if (inv.ItemID == 1540)
                {
                    pinfo.qhp = inv.Count;
                    QHP = inv.ObjID;
                }
                else if (inv.ItemID == 1539)
                {
                    pinfo.ghppots = inv.Count;
                    GHP = inv.ObjID;
                }
                else if (inv.ItemID == 5858)
                {
                    //clan hall bsoe
                    bsoeid = inv.ObjID;
                }
                else
                {
                    foreach (shots s in gs.shotlist)
                    {
                        if (s.id == inv.ItemID)
                        {
                            s.objid = inv.ObjID;
                        }
                    }
                }
                if (pinfo != null)
                {
                    if (pinfo.Level >= 61)
                    {
                        //can use a grade
                        if (pinfo.Level >= 76)
                        {
                            // can use s grade
                            if (inv.ItemID == 8627)
                            {
                                pinfo.elixirHP_S = inv.Count;
                                EHP_S = inv.ObjID;
                            }
                            if (inv.ItemID == 8639)
                            {
                                pinfo.elixirCP_S = inv.Count;
                                ECP_S = inv.ObjID;
                            }
                        }
                        else
                        {
                            if (inv.ItemID == 8638)
                            {
                                pinfo.elixirCP_A = inv.Count;
                                ECP_A = inv.ObjID;
                            }
                            if (inv.ItemID == 8626)
                            {
                                pinfo.elixirHP_A = inv.Count;
                                EHP_A = inv.ObjID;
                            }

                        }
                    }
                }
            }
        }

        private void packetPCInfo(ByteBuffer data)
        {
            pinfo.Load_User(data);
        }

        private static void packetNpcInfo(ByteBuffer data)
        {

        }

        private void packetMoveToLocation(ByteBuffer data)
        {
            //first check if this is a move to for me
            uint oid = data.ReadUInt32();
            int xd = data.ReadInt32();
            int yd = data.ReadInt32();
            int zd = data.ReadInt32();
            int x = data.ReadInt32();
            int y = data.ReadInt32();
            int z = data.ReadInt32();

            if (pinfo != null && (pinfo.ObjID == oid))
            {
                pinfo.X = xd;
                pinfo.Y = yd;
                pinfo.Z = zd;
            }
        }
        private void packetStopMove(ByteBuffer data)
        {
            //first check if this is a move to for me
            uint oid = data.ReadUInt32();
            int xd = data.ReadInt32();
            int yd = data.ReadInt32();
            int zd = data.ReadInt32();

            if (pinfo != null)
            {

                if (oid == pinfo.ObjID)
                {
                    pinfo.X = xd;
                    pinfo.Y = yd;
                    pinfo.Z = zd;
                }
            }
        }
        private void LeaderPacket_DeleteObject(ByteBuffer data)
        {
            //delete object packet .. we have to set it so that if a player is deleted 
            //(returns to town) the target will switch
            uint objid = data.ReadUInt32();
            gs.deleteObject(objid);
            //now delete from all the other places
            if (gs.allplayerinfo.ContainsKey(objid))
            {
                gs.allplayerinfo.Remove(objid);
            }
            if (gs.playerlist.ContainsKey(objid))
            {
                lock (gs.bwindow.listlock)
                {
                    if (gs.bwindow.newplayers.Contains(objid))
                    {
                        gs.bwindow.newplayers.Remove(objid);
                    }
                    if (!gs.bwindow.deletedplayer.Contains(objid))
                    {
                        gs.bwindow.deletedplayer.Remove(objid);
                    }
                }
                gs.playerlist.Remove(objid);
            }
            //we don't remove from enemy list instead we mark it as gone
            if (gs.enemylist.ContainsKey(objid))
            {
                gs.deletedenemies.Add(objid);
                gs.enemylist.Remove(objid);
            }
            if (gs.attacklist.ContainsKey(objid))
            {
                gs.deletedenemies.Add(objid);
                gs.attacklist.Remove(objid);
            }

            lock (gs.bwindow.listlock)
            {
                gs.bwindow.deletedplayer.Add(objid);
            }
        }
        private void LeaderPacket_PledgeInfo(ByteBuffer data)
        {
            uint oid = data.ReadUInt32();
            if (!gs.clanlist.ContainsKey(oid))
            {
                //add to clan list
                Clans c = new Clans();
                c.name = data.ReadString();
                c.ally = data.ReadString();
                c.id = oid;
                gs.clanlist.Add(oid, c);
                if (c.name == "Purgatory")
                {
                    gs.PurgId = c.id;
                }
                if (gs.enemynames.Contains(c.name))
                {
                    gs.enemyclans.Add(c.id, c);
                    if (c.name == "Purgatory")
                    {
                        MessageBox.Show("Purgatory is your friend!");
                        c.enemy = false;
                    }
                    else
                    {
                        int allplayercount = gs.allplayerinfo.Count;
                        foreach (CharInfo _cinfo in gs.allplayerinfo.Values)
                        {
                            if (_cinfo.ClanID == c.id)
                            {
                                //enemy player!
                                if (!gs.enemylist.ContainsKey(_cinfo.ID) && !gs.attacklist.ContainsKey(_cinfo.ID))
                                    gs.enemylist.Add(_cinfo.ID, _cinfo);
                            }
                        }
                        c.enemy = true;
                    }
                }
                else
                {
                    c.enemy = false;
                }
                //set clan in display
            }
        }

        private void LeaderPacket_StopMove(ByteBuffer data)
        {
            //first check if this is a move to for me
            uint oid = data.ReadUInt32();
            int xd = data.ReadInt32();
            int yd = data.ReadInt32();
            int zd = data.ReadInt32();

            updateDist(oid, xd, yd, zd);
        }
        private void updateDist(uint oid, int xd, int yd, int zd)
        {
            if (pinfo != null)
            {

                if (oid == pinfo.ObjID && gs.distanceupdates)
                {
                    //my player I have to go through all player list and update the distance
                    pinfo.X = xd;
                    pinfo.Y = yd;
                    pinfo.Z = zd;
                    foreach (CharInfo cinfo in gs.allplayerinfo.Values)
                    {
                        double distance = 0.0;

                        distance = System.Math.Sqrt(Math.Pow((xd - cinfo.X), 2) + Math.Pow((yd - cinfo.Y), 2) + Math.Pow(zd - cinfo.Z, 2));
                        cinfo.distance = distance;

                        if (distance < listdis)
                        {
                            //3000 is a good range imo
                            if (gs.playerlist.ContainsKey(cinfo.ID))
                            {
                                //already in the list .. just change the distance
                                gs.playerlist[cinfo.ID] = cinfo;
                            }
                            else
                            {
                                gs.playerlist.Add(cinfo.ID, cinfo);
                                lock (gs.bwindow.listlock)
                                {
                                    gs.bwindow.newplayers.Add(cinfo.ID);
                                }
                            }
                        }
                        else
                        {
                            //too far
                            if (gs.playerlist.ContainsKey(cinfo.ID))
                            {
                                gs.playerlist.Remove(cinfo.ID);
                            }
                            lock (gs.bwindow.listlock)
                            {
                                gs.bwindow.deletedplayer.Add(cinfo.ID);
                            }
                        }
                    }
                }
                else
                {
                    //not my player just need to update one distance
                    if (gs.playerlist.ContainsKey(oid))
                    {
                        //in the list -- don't worry about those not in the list for now
                        CharInfo cinfo = gs.playerlist[oid];
                        double distance = 0.0;
                        distance = System.Math.Sqrt(Math.Pow((pinfo.X - xd), 2) + Math.Pow((pinfo.Y - yd), 2) + Math.Pow(pinfo.Z - zd, 2));
                        cinfo.X = xd;
                        cinfo.Y = yd;
                        cinfo.Z = zd;

                        if (distance < listdis)
                        {
                            cinfo.distance = distance;
                            gs.playerlist[oid] = cinfo;
                        }
                        else
                        {
                            gs.playerlist.Remove(oid);
                            lock (gs.bwindow.listlock)
                            {
                                gs.bwindow.deletedplayer.Add(cinfo.ID);
                            }
                        }

                    }
                    else if (gs.allplayerinfo.ContainsKey(oid))
                    {
                        //not in player list but it is in allplayerlist
                        CharInfo cinfo = gs.allplayerinfo[oid];
                        double distance = 0.0;
                        distance = System.Math.Sqrt(Math.Pow((pinfo.X - xd), 2) + Math.Pow((pinfo.Y - yd), 2) + Math.Pow(pinfo.Z - zd, 2));
                        cinfo.X = xd;
                        cinfo.Y = yd;
                        cinfo.Z = zd;
                        cinfo.distance = distance;

                        if (distance < listdis)
                        {
                            gs.playerlist.Add(oid, cinfo);
                            lock (gs.bwindow.listlock)
                            {
                                gs.bwindow.newplayers.Add(cinfo.ID);
                            }
                        }

                    }
                }
            }
        }
        private void LeaderPacket_MoveToPawn(ByteBuffer data)
        {
            //first check if this is a move to for me
            uint oid = data.ReadUInt32();
            uint tid = data.ReadUInt32();
            int movedist = data.ReadInt32();
            int xd = data.ReadInt32();
            int yd = data.ReadInt32();
            int zd = data.ReadInt32();
            int x = 0, y = 0, z = 0;

            if (gs.allplayerinfo.ContainsKey(tid))
            {
                x = gs.allplayerinfo[tid].X;
                y = gs.allplayerinfo[tid].Y;
                z = gs.allplayerinfo[tid].Z;
            }
            else if (pinfo.ObjID == tid)
            {
                x = pinfo.X;
                y = pinfo.Y;
                z = pinfo.Z;

            }
            else
            {
                return;
            }
            updateDist(oid, xd, yd, zd);
        }
        private void LeaderPacket_MoveToLocation(ByteBuffer data)
        {
            //first check if this is a move to for me
            uint oid = data.ReadUInt32();
            int xd = data.ReadInt32();
            int yd = data.ReadInt32();
            int zd = data.ReadInt32();
            int x = data.ReadInt32();
            int y = data.ReadInt32();
            int z = data.ReadInt32();

            updateDist(oid, xd, yd, zd);
        }
        private void LeaderPacket_CharInfo(ByteBuffer data)
        {
            CharInfo cinfo = new CharInfo();
            cinfo.Load(data);
            gs.UpdateTarget(cinfo);
            //check if it is in allplayerlist
            if (!gs.allplayerinfo.ContainsKey(cinfo.ID))
            {
                //not in list so add to list
                gs.allplayerinfo.Add(cinfo.ID, cinfo);
                if (gs.deletedenemies.Contains(cinfo.ID))
                {
                    gs.deletedenemies.Remove(cinfo.ID);
                    gs.enemylist.Add(cinfo.ID, cinfo);
                }
            }

            //check if player is in enemy clan

            if (gs.enemyclans.ContainsKey(cinfo.ClanID))
            {
                //in enemy clan - list him as an enemy
                if (!gs.enemylist.ContainsKey(cinfo.ID))
                {
                    gs.enemylist.Add(cinfo.ID, cinfo);
                }
            }

            if (pinfo != null)
            {
                double distance = 0.0;
                distance = System.Math.Sqrt(Math.Pow((pinfo.X - cinfo.X), 2) + Math.Pow((pinfo.Y - cinfo.Y), 2) + Math.Pow(pinfo.Z - cinfo.Z, 2));
                cinfo.distance = distance;
                if (distance < listdis)
                {
                    //3000 is a good range imo
                    if (gs.playerlist.ContainsKey(cinfo.ID))
                    {
                        //already in the list .. just change the distance
                        gs.playerlist[cinfo.ID] = cinfo;
                    }
                    else
                    {
                        gs.playerlist.Add(cinfo.ID, cinfo);
                        lock (gs.bwindow.listlock)
                        {
                            gs.bwindow.newplayers.Add(cinfo.ID);
                        }
                    }
                }
                else
                {
                    //too far
                    if (gs.playerlist.ContainsKey(cinfo.ID))
                    {
                        gs.playerlist.Remove(cinfo.ID);
                        lock (gs.bwindow.listlock)
                        {
                            gs.bwindow.deletedplayer.Add(cinfo.ID);
                        }
                    }
                }
            }

            //update in all 3 lists
            if (gs.allplayerinfo.ContainsKey(cinfo.ID))
                gs.allplayerinfo[cinfo.ID] = cinfo;
            if (gs.playerlist.ContainsKey(cinfo.ID))
                gs.playerlist[cinfo.ID] = cinfo;
            if (gs.enemylist.ContainsKey(cinfo.ID))
                gs.enemylist[cinfo.ID] = cinfo;
        }

        private void LeaderPacket_SystemMessage(ByteBuffer data)
        {
            //system message - check if it is a target in peace zone message
            uint msgid = data.ReadUInt32();
            if (msgid == 85 || msgid == 84)
            {
                //target in peace zone
                //change target in peace value to 1 so we break out of target loop
                if (gs.target != null)
                    gs.target.peace = 1;

                gs.targetselection.Interrupt();
            }
            if (msgid == 0xb5)
            {
                if (gs.target != null)
                    gs.target.peace = 1;
                gs.targetselection.Interrupt();
            }
            if (msgid == 144)
            {
                if (gs.target != null)
                    gs.target.peace = 1;
                gs.targetselection.Interrupt();
            }
        }

        private void LeaderPacket_TargetSelected(ByteBuffer data)
        {
            uint charid = data.ReadUInt32();
            uint tarid = data.ReadUInt32();
        }
        private void packetSystemMessage(ByteBuffer data)
        {
            //system message - check if it is a target in peace zone message
            uint msgid = data.ReadUInt32();
            if (msgid == 92)
            {
                //after
                uint size = data.ReadUInt32();
                for (int i = 0; i < size; i++)
                {
                    uint type = data.ReadUInt32();
                    uint skillid = data.ReadUInt32();
                    if (doafterskill.ContainsKey(skillid))
                    {
                        uint doafterskillid = doafterskill[skillid];
                        ByteBuffer useskillmsg = new ByteBuffer(10);
                        useskillmsg.WriteByte(0x39);
                        useskillmsg.WriteUInt32(doafterskillid);
                        useskillmsg.WriteUInt32(0);
                        useskillmsg.WriteByte(0x00);
                        NewMsgHP(useskillmsg);
                    }
                }

            }
            if (msgid == 110)
            {
                //on
                uint size = data.ReadUInt32();
                for (int i = 0; i < size; i++)
                {
                    uint type = data.ReadUInt32();
                    uint skillid = data.ReadUInt32();
                    if (doonskill.ContainsKey(skillid))
                    {
                        uint doskillid = doonskill[skillid];
                        ByteBuffer useskillmsg = new ByteBuffer(10);
                        useskillmsg.WriteByte(0x39);
                        useskillmsg.WriteUInt32(doskillid);
                        useskillmsg.WriteUInt32(0);
                        useskillmsg.WriteByte(0x00);
                        NewMsgHP(useskillmsg);
                    }
                }
            }
        }

        private void packet04(ByteBuffer data)
        {
            pinfo.Load_User(data);
        }

        private void packetShortBuffStautsUpdate(ByteBuffer data)
        {
            short esize = data.ReadInt16();
            short i = 0;

            for (i = 0; i < esize; i++)
            {
                int id = data.ReadInt32();
                short level = data.ReadInt16();
                int duration = data.ReadInt32();
            }
        }
        private void packetSkillList(ByteBuffer data)
        {
            //skill list
            skilllist.Clear();
            uint size = data.ReadUInt32();
            uint passive, level, id;
            for (int i = 0; i < size; i++)
            {
                passive = data.ReadUInt32();
                level = data.ReadUInt32();
                id = data.ReadUInt32();
                if (passive == 0)
                {
                    skilllist.Add(id);
                }
                data.ReadByte();
            }
            buffform.populateskilllist_d(skilllist);
            asform.populateskilllist_d(skilllist);
            dsform.populateskilllist_d(skilllist);
        }

        private void LeaderPacket_PartyWindowAll(ByteBuffer data)
        {
            //0x4e
            //all party members
            uint leaderid = data.ReadUInt32();
            uint lootdistrib = data.ReadUInt32();

            uint partysize = data.ReadUInt32();

            for (int i = 0; i < partysize; i++)
            {
                uint objid = data.ReadUInt32();
                string name = data.ReadString();

                uint cur_cp = data.ReadUInt32();
                uint max_cp = data.ReadUInt32();

                uint cur_hp = data.ReadUInt32();
                uint max_hp = data.ReadUInt32();

                uint cur_mp = data.ReadUInt32();
                uint max_mp = data.ReadUInt32();

                uint level = data.ReadUInt32();
                uint class_id = data.ReadUInt32();

                data.ReadUInt32();
                data.ReadUInt32();
                data.ReadUInt32();
            }

        }

        private void LeaderPacket_PartyWindowAdd(ByteBuffer data)
        {
            data.ReadUInt32();
            data.ReadUInt32();

            uint objid = data.ReadUInt32();
            string name = data.ReadString();

            uint cur_cp = data.ReadUInt32();
            uint max_cp = data.ReadUInt32();

            uint cur_hp = data.ReadUInt32();
            uint max_hp = data.ReadUInt32();

            uint cur_mp = data.ReadUInt32();
            uint max_mp = data.ReadUInt32();

            uint level = data.ReadUInt32();
            uint class_id = data.ReadUInt32();

            data.ReadUInt32();
            data.ReadUInt32();
            data.ReadUInt32();
        }
    }
}