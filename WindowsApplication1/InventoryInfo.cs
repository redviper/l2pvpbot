using System;
using System.Collections.Generic;
using System.Text;

namespace l2pvp
{
    public class InventoryInfo
    {

        private readonly object CountLock;
        private readonly object EnchantLock;
        private readonly object isEquippedLock;
        private readonly object ItemIDLock;
        private readonly object ObjIDLock;
        private readonly object SlotLock;
        private readonly object Type2Lock;
        private readonly object Type3Lock;
        private readonly object Type4Lock;
        private readonly object TypeLock;

        private uint _Count;
        private ushort _Enchant;
        private ushort _isEquipped;
        private uint _ItemID;
        private uint _ObjID;
        private uint _Slot;
        private ushort _Type;
        private ushort _Type2;
        private ushort _Type3;
        private ushort _Type4;


        public uint Count
        {
            get
            {
                uint ui;

                lock (CountLock)
                {
                    ui = _Count;
                }
                return ui;
            }
            set
            {
                lock (CountLock)
                {
                    _Count = value;
                }
            }
        }

        public ushort Enchant
        {
            get
            {
                ushort ush;

                lock (EnchantLock)
                {
                    ush = _Enchant;
                }
                return ush;
            }
            set
            {
                lock (EnchantLock)
                {
                    _Enchant = value;
                }
            }
        }

        public ushort isEquipped
        {
            get
            {
                ushort ush;

                lock (isEquippedLock)
                {
                    ush = _isEquipped;
                }
                return ush;
            }
            set
            {
                lock (isEquippedLock)
                {
                    _isEquipped = value;
                }
            }
        }

        public uint ItemID
        {
            get
            {
                uint ui;

                lock (ItemIDLock)
                {
                    ui = _ItemID;
                }
                return ui;
            }
            set
            {
                lock (ItemIDLock)
                {
                    _ItemID = value;
                }
            }
        }

        public uint ObjID
        {
            get
            {
                uint ui;

                lock (ObjIDLock)
                {
                    ui = _ObjID;
                }
                return ui;
            }
            set
            {
                lock (ObjIDLock)
                {
                    _ObjID = value;
                }
            }
        }

        public uint Slot
        {
            get
            {
                uint ui;

                lock (SlotLock)
                {
                    ui = _Slot;
                }
                return ui;
            }
            set
            {
                lock (SlotLock)
                {
                    _Slot = value;
                }
            }
        }

        public ushort Type
        {
            get
            {
                ushort ush;

                lock (TypeLock)
                {
                    ush = _Type;
                }
                return ush;
            }
            set
            {
                lock (TypeLock)
                {
                    _Type = value;
                }
            }
        }

        public ushort Type2
        {
            get
            {
                ushort ush;

                lock (Type2Lock)
                {
                    ush = _Type2;
                }
                return ush;
            }
            set
            {
                lock (Type2Lock)
                {
                    _Type2 = value;
                }
            }
        }

        public ushort Type3
        {
            get
            {
                ushort ush;

                lock (Type3Lock)
                {
                    ush = _Type3;
                }
                return ush;
            }
            set
            {
                lock (Type3Lock)
                {
                    _Type3 = value;
                }
            }
        }

        public ushort Type4
        {
            get
            {
                ushort ush;

                lock (Type4Lock)
                {
                    ush = _Type4;
                }
                return ush;
            }
            set
            {
                lock (Type4Lock)
                {
                    _Type4 = value;
                }
            }
        }

        public uint Augment;

        public InventoryInfo()
        {
            Type4Lock = new Object();
            EnchantLock = new Object();
            SlotLock = new Object();
            isEquippedLock = new Object();
            Type3Lock = new Object();
            Type2Lock = new Object();
            CountLock = new Object();
            ItemIDLock = new Object();
            ObjIDLock = new Object();
            TypeLock = new Object();
        }

        public void Load(ByteBuffer buff)
        {
            Type = buff.ReadUInt16();
            ObjID = buff.ReadUInt32();
            ItemID = buff.ReadUInt32();
            buff.ReadUInt32(); //location slot
            Count = buff.ReadUInt32();
            Type2 = buff.ReadUInt16();
            Type3 = buff.ReadUInt16();
            isEquipped = buff.ReadUInt16();
            Slot = buff.ReadUInt32();
            Enchant = buff.ReadUInt16();
            Type4 = buff.ReadUInt16();
            Augment = buff.ReadUInt32();
            buff.ReadUInt32();

            buff.ReadUInt32();
            buff.ReadUInt32();
            buff.ReadUInt32();
            buff.ReadUInt32();
            buff.ReadUInt32();
            buff.ReadUInt32();
            buff.ReadUInt32();
            buff.ReadUInt32();
        }

    } // class InventoryInfo

}
