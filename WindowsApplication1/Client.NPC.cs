using System;

namespace l2pvp
{

    public partial class Client
    {

        public class NPC
        {
            public uint objid;
            public bool isAttackable;
            public string name;
            public int posX, posY, posZ;
            public int heading;
            public string title;
            public uint Max_HP;
            public uint Cur_HP;
            public bool islikedead;

            public NPC()
            {
                objid = 0;
                isAttackable = false;
                name = " ";
                posX = 0;
                posY = 0;
                posZ = 0;
                islikedead = false;

            }

            public void Update(ByteBuffer buff)
            {

                uint num1 = buff.ReadUInt32();
                uint num2 = buff.ReadUInt32();
                switch (num1)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 13:
                    case 14:
                    case 15:
                    case 0x10:
                    case 0x11:
                    case 0x13:
                    case 20:
                    case 0x15:
                    case 0x16:
                    case 0x17:
                    case 0x19:
                    case 0x1c:
                    case 0x1d:
                    case 30:
                    case 0x1f:
                    case 0x20:
                        return;

                    case 9:
                        this.Cur_HP = num2;
                        if (this.Cur_HP > 1)
                        {
                            isAlikeDead = false;
                        }
                        if (this.Cur_HP < 1)
                        {
                            isAlikeDead = true;
                        }
                        return;

                    case 10:
                        this.Max_HP = num2;
                        return;

                    //case 11:
                    //    this.Cur_MP = num2;
                    //    return;

                    //case 12:
                    //    this.Max_MP = num2;
                    //    return;

                    //case 0x12:
                    //    this.PatkSpeed = num2;
                    //    return;

                    //case 0x18:
                    //    this.MatkSpeed = num2;
                    //    return;

                    //case 0x1a:
                    //    this.PvPFlag = num2;
                    //    return;

                    //case 0x1b:
                    //    this.Karma = num2;
                    //    return;

                    //case 0x21:
                    //    this.Cur_CP = num2;
                    //    return;

                    //case 0x22:
                    //    this.Max_CP = num2;
                    //    return;
                }
            }
            public bool isAlikeDead;
            public void Load_2(ByteBuffer data)
            {
                objid = data.ReadUInt32();
                data.ReadUInt32();
                uint at = data.ReadUInt32();
                if (at == 0)
                    isAttackable = false;
                else
                    isAttackable = true;
                posX = data.ReadInt32();
                posY = data.ReadInt32();
                posZ = data.ReadInt32();
                heading = data.ReadInt32();
                for (int i = 0; i < 11; i++)
                {
                    data.ReadInt32();
                }
                for (int j = 0; j < 4; j++)
                {
                    data.ReadDouble();
                }
                for (int i = 0; i < 3; i++)
                {
                    data.ReadInt32();
                }
                data.ReadByte();
                data.ReadByte();
                data.ReadByte();
                at = data.ReadByte();
                if (at == 0)
                    isAlikeDead = false;
                else
                    isAlikeDead = true;

            }
        }

    }
}