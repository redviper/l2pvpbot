using System;
using System.Collections.Generic;
using System.Text;

namespace l2pvp
{
    public class GameT15Crypter
    {
        private l2pvp.OpcodeObfuscator.OpcodeTable _table;

        /**
         * 
         */
        public GameT15Crypter()
        {

        }
        public void encrypt(byte[] raw)
        {
            try
            {
                raw[0] = _table.getObfuscatedOpcode(raw[0]);
            }
            catch
            {
                System.Console.WriteLine("Exception in encrypting --- " + raw.ToString());
            }
        }
        public void decrypt(byte[] raw)
        {

            //            bool decrypt = super.decrypt(raw, dir);

            // Crypt Key (once) or CharacterSelected (multiple possible)
            // search after decryption due to CharacterSelected
            //if (dir == packetDirection.serverPacket)
            //{
            //    this.searchObfuscationKey(raw, dir);
            //}
            //else if (dir == packetDirection.clientPacket && _table != null)
            //{
            //byte old = raw[0];
            try
            {
                raw[0] = _table.getOriginalOpcode(raw[0]);
                if ((raw[0] & 0xFF) == 0xd0)
                {
                    short exOpcode = _table.getExOpcode(raw[1] + (raw[2] << 8));
                    raw[1] = (byte)(exOpcode & 0xFF);
                    raw[2] = (byte)((exOpcode >> 8) & 0xFF);
                }
                //byte newop = _table.getObfuscatedOpcode(raw[0]);
                //System.Console.WriteLine("Opcodes = {0} -- {1} -- {2}", old, raw[0], newop);
                return;
            }
            catch
            {
                System.Console.WriteLine("Exception in decrypting --- " + raw.ToString());
            }
        }

        //    private boolean searchObfuscationKey(byte[] raw, packetDirection dir)
        //{
        //    byte[] temp = new byte[raw.length];
        //    System.arraycopy(raw, 0, temp, 0, raw.length);
        //    DataPacket packet = new DataPacket(temp, dir, 0, this.getProtocol());
        //    if (dir ==  packetDirection.serverPacket && ("Crypt Key".equals(packet.getName()) || "CharacterSelected".equals(packet.getName())))
        //    {
        //        ValuePart part = (ValuePart) packet.getRootNode().getPartByName("obfuscation key");
        //        if(part == null)
        //        {
        //            System.out.printf("Check your protocol there is no part called 'obfuscation key' which is required in packet 0x00 of the GS protocol.");
        //            return false;
        //        }
        //        if (part instanceof IntValuePart)
        //        {
        //            int key = ((IntValuePart)part).getIntValue();
        //            System.out.printf("Obfuscation Key is: "+key+" -> %08X\n",key);
        //            this.generateOpcodeTable(key);
        //        }
        //        else
        //        {
        //            System.out.printf("On the GS protocol 'Obfuscation Key' should be of type 'd'.");
        //            return false;
        //        }
        //        return true;
        //    }
        //    //System.out.println("No key found...");
        //    return false;
        //}


        public void generateOpcodeTable(int key)
        {
            if (key == 0)
            {
                byte[] opcodes = new byte[0xd1]; // d0 + 1
                for (int i = 0; i < opcodes.Length; i++)
                {
                    opcodes[i] = (byte)i;
                }
                short[] exOpcodes = new short[0x4e];
                for (int i = 0; i < exOpcodes.Length; i++)
                {
                    exOpcodes[i] = (byte)i;
                }
            }
            else
            {
                _table = OpcodeObfuscator.getObfuscatedTable(key);
            }
        }
    }

    public class OpcodeObfuscator
    {
        // static usage
        private OpcodeObfuscator()
        {

        }

        private static short[] shuffleEx(int key)
        {
            //System.err.printf("EX KEY: %08X\n" , key);
            short[] array = new short[0x4e];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (byte)i;
            }

            int edx = 0;
            int ecx = 2;

            short tmp2;
            short opcode;
            int edi = 1;

            int subKey;
            int j = 0;
            do
            {
                //MOVZX EAX,AX
                key = rotateKey(key);
                subKey = key >> 16;
                subKey &= 0x7FFF;

                //System.err.printf("SubKey1: %04X\n" , subKey);

                // CDQ
                edx = 0;

                // IDIV ECX
                //edxeax = (edx << 32) + eax;
                //eax = (int) (edxeax / ecx);
                edx = subKey % ecx++;
                //System.err.printf("SubKey2: %04X - EDX: %04X\n" , subKey, edx);

                // INC EDI
                edi++;

                // SKIPPED: DEC EBX

                // SKIPPED: MOVZX EDX,DL

                // MOV CL,BYTE PTR DS:[EDX+ESI+4174]
                opcode = array[edx];

                // MOV DL,BYTE PTR DS:[EDI-1]
                tmp2 = array[edi - 1];

                // MOV BYTE PTR DS:[EAX],DL
                array[edx] = (byte)tmp2;

                // MOV BYTE PTR DS:[EDI-1],CL
                array[edi - 1] = (byte)opcode;
            }
            while (++j < 0x4d);

            /*for (int i = 0; i < array.length; i++)
            {
                System.err.printf("array[%04X] = %04X\n", i, array[i]);
            }*/

            return array;
        }

        //private static int STORED_KEY = 0x73BD7EF4;//0x63E790F1;

        private static int rotateKey(int key)
        {
            key *= 0x343FD;
            key += 0x269EC3;
            return key;
        }

        public static OpcodeTable getObfuscatedTable(int key)
        {
            byte[] array = new byte[0xd1];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (byte)i;
            }

            byte tmp;
            byte opcode;

            int edx = 0;
            int ecx = 2;
            int edi = 1;

            int subKey;
            int j = 0;
            do
            {
                //MOVZX EAX,AX
                key = rotateKey(key);

                subKey = key >> 16;
                subKey &= 0x7FFF;

                //System.err.printf("SubKey1: %04X\n" , eax);
                // CDQ
                edx = 0;

                // IDIV ECX
                //edxeax = (edx << 32) + eax;
                //eax = (int) (edxeax / ecx);
                edx = subKey % ecx++;
                //System.err.printf("SubKey2: %04X - EDX: %04X\n" , eax, edx);

                // INC EDI
                edi++;

                // SKIPPED: DEC EBX (ZF enabler)

                // SKIPPED: MOVZX EDX,DL

                // MOV CL,BYTE PTR DS:[EDX+ESI+4174]
                opcode = array[edx];

                // MOV DL,BYTE PTR DS:[EDI-1]
                tmp = array[edi - 1];

                // MOV BYTE PTR DS:[EAX],DL
                array[edx] = tmp;

                // MOV BYTE PTR DS:[EDI-1],CL
                array[edi - 1] = opcode;
            }
            while (++j < 0xd0);

            OpcodeObfuscator.revertOpcodeToOriginal(array, (byte)0x12);
            OpcodeObfuscator.revertOpcodeToOriginal(array, (byte)0xb1);

            /*for (int i = 0; i < array.length; i++)
            {
                System.err.printf("array[%02X] = %02X\n", i, array[i]);
            }*/

            short[] exOpcodes = OpcodeObfuscator.shuffleEx(key);

            return new OpcodeTable(array, exOpcodes);
        }

        private static void revertOpcodeToOriginal(byte[] array, byte opcode)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == opcode)
                {
                    array[i] = array[opcode & 0xFF];
                    array[opcode & 0xFF] = opcode;
                    return;
                }
            }
        }

        public class OpcodeTable
        {
            private byte[] _opcodeTable;
            private short[] _exOpcodeTable;
            private byte[] _reverselookup;
            //private short[] _reverseEx;

            public OpcodeTable(byte[] opcodeTable, short[] exOpcodeTable)
            {
                _opcodeTable = opcodeTable;
                /*for (int i = 0; i < opcodeTable.length; i++)
                {
                    System.out.printf("[%02X] = %02X \n", i, (opcodeTable[i] & 0xff));
                }*/
                _exOpcodeTable = exOpcodeTable;
                /*for (int i = 0; i < exOpcodeTable.length; i++)
                {
                    System.out.printf("[%04X] = %04X \n", i, (exOpcodeTable[i] & 0xff));
                }*/
                _reverselookup = new byte[opcodeTable.Length];
                for (int i = 0; i < opcodeTable.Length; i++)
                {
                    _reverselookup[opcodeTable[i & 0xFF]] = (byte)(i & 0xff);
                }
            }

            public byte getOriginalOpcode(int obfuscatedOpcode)
            {
                return _opcodeTable[obfuscatedOpcode & 0xFF];
            }

            public short getExOpcode(int obfuscatedOpcode)
            {
                return _exOpcodeTable[obfuscatedOpcode & 0xFFFF];
            }

            public byte getObfuscatedOpcode(int opcode)
            {
                return _reverselookup[opcode & 0xFF];
            }
        }
    }

    public class OldCrypt
    {
        // Fields
        private byte[] _key;
        private bool enabled;

        public OldCrypt()
        {
            this._key = new byte[8];
        }


        public void decrypt(byte[] raw)
        {
            if (this.enabled)
            {
                uint num1 = 0;
                for (int num2 = 0; num2 < raw.Length; num2++)
                {
                    uint num3 = (uint)(raw[num2] & 0xff);
                    raw[num2] = (byte)((num3 ^ (this._key[num2 & 7] & 0xff)) ^ num1);
                    num1 = num3;
                }
                ulong num4 = (ulong)(this._key[0] & 0xff);
                num4 |= (ulong)(this._key[1] << 8) & 0xff00;
                num4 |= (ulong)(this._key[2] << 0x10) & 0xff0000;
                num4 |= (ulong)(this._key[3] << 0x18) & 0xff000000;
                num4 += (ulong)raw.Length;
                this._key[0] = (byte)(num4 & 0xff);
                this._key[1] = (byte)((num4 >> 8) & 0xff);
                this._key[2] = (byte)((num4 >> 0x10) & 0xff);
                this._key[3] = (byte)((num4 >> 0x18) & 0xff);
            }
        }

        public void decrypt(byte[] raw, ulong size)
        {
            if (this.enabled)
            {
                uint num1 = 0;
                for (uint num2 = 0; num2 < size; num2 += 1)
                {
                    uint num3 = (uint)(raw[(int)((IntPtr)num2)] & 0xff);
                    raw[(int)((IntPtr)num2)] = (byte)((num3 ^ (this._key[(int)((IntPtr)(num2 & 7))] & 0xff)) ^ num1);
                    num1 = num3;
                }
                ulong num4 = (ulong)(this._key[0] & 0xff);
                num4 |= (ulong)(this._key[1] << 8) & 0xff00;
                num4 |= (ulong)(this._key[2] << 0x10) & 0xff0000;
                num4 |= (ulong)(this._key[3] << 0x18) & 0xff000000;
                num4 += (ulong)size;
                this._key[0] = (byte)(num4 & 0xff);
                this._key[1] = (byte)((num4 >> 8) & 0xff);
                this._key[2] = (byte)((num4 >> 0x10) & 0xff);
                this._key[3] = (byte)((num4 >> 0x18) & 0xff);
                this.Write_Key();
            }
        }

        public void encrypt(byte[] raw)
        {
            if (this.enabled)
            {
                uint num1 = 0;
                for (int num2 = 0; num2 < raw.Length; num2++)
                {
                    uint num3 = (uint)(raw[num2] & 0xff);
                    raw[num2] = (byte)((num3 ^ (this._key[num2 & 7] & 0xff)) ^ num1);
                    num1 = raw[num2];
                }
                ulong num4 = (ulong)(this._key[0] & 0xff);
                num4 |= (ulong)(this._key[1] << 8) & 0xff00;
                num4 |= (ulong)(this._key[2] << 0x10) & 0xff0000;
                num4 |= (ulong)(this._key[3] << 0x18) & 0xff000000;
                num4 += (ulong)raw.Length;
                this._key[0] = (byte)(num4 & 0xff);
                this._key[1] = (byte)((num4 >> 8) & 0xff);
                this._key[2] = (byte)((num4 >> 0x10) & 0xff);
                this._key[3] = (byte)((num4 >> 0x18) & 0xff);
            }
        }


        public void encrypt(byte[] raw, ulong size)
        {
            if (this.enabled)
            {
                uint num1 = 0;
                for (uint num2 = 0; num2 < size; num2 += 1)
                {
                    uint num3 = (uint)(raw[(int)((IntPtr)num2)] & 0xff);
                    raw[(int)((IntPtr)num2)] = (byte)((num3 ^ (this._key[(int)((IntPtr)(num2 & 7))] & 0xff)) ^ num1);
                    num1 = raw[(int)((IntPtr)num2)];
                }
                ulong num4 = (ulong)(this._key[0] & 0xff);
                num4 |= (ulong)(this._key[1] << 8) & 0xff00;
                num4 |= (ulong)(this._key[2] << 0x10) & 0xff0000;
                num4 |= (ulong)(this._key[3] << 0x18) & 0xff000000;
                num4 += (ulong)size;
                this._key[0] = (byte)(num4 & 0xff);
                this._key[1] = (byte)((num4 >> 8) & 0xff);
                this._key[2] = (byte)((num4 >> 0x10) & 0xff);
                this._key[3] = (byte)((num4 >> 0x18) & 0xff);
            }
        }


        public void setKey(byte[] key)
        {
            this._key[0] = key[0];
            this._key[1] = key[1];
            this._key[2] = key[2];
            this._key[3] = key[3];
            this._key[4] = key[4];
            this._key[5] = key[5];
            this._key[6] = key[6];
            this._key[7] = key[7];
            this.enabled = true;
        }


        private void Write_Key()
        {
        }
    }

    public class Crypt
    {
        private byte[] _inKey;
        private byte[] _outKey;
        //byte[] _idTable = null;
        //short[] _exIdTable = null;

        public Crypt()
        {
            _inKey = new byte[16];
            _outKey = new byte[16];
            //_idTable = new byte[208];
            //_exIdTable = new short[76];
            //for (int i = 0; i < _idTable.Length; i++)
            //    _idTable[i] = Convert.ToByte(i);

            //for (int i = 0; i < _exIdTable.Length; i++)
            //    _exIdTable[i] = Convert.ToInt16(i);

        }

        public void setKey(byte[] key)
        {
            Array.Copy(key, 0, _inKey, 0, 16);
            Array.Copy(key, 0, _outKey, 0, 16);
        }

        public void decrypt(byte[] raw)
        {
            decrypt(raw, 0, raw.Length);
        }

        public void decrypt(byte[] raw, int offset, int size)
        {
            int temp = 0;
            for (int i = 0; i < size; i++)
            {
                int temp2 = raw[offset + i] & 0xFF;
                raw[offset + i] = (byte)(temp2 ^ _inKey[i & 15] ^ temp);
                temp = temp2;
            }

            ulong old = (ulong)_inKey[8] & 0xff;
            old |= (ulong)_inKey[9] << 8 & 0xff00;
            old |= (ulong)_inKey[10] << 0x10 & 0xff0000;
            old |= (ulong)_inKey[11] << 0x18 & 0xff000000;

            old += (ulong)size;

            _inKey[8] = (byte)(old & 0xff);
            _inKey[9] = (byte)(old >> 0x08 & 0xff);
            _inKey[10] = (byte)(old >> 0x10 & 0xff);
            _inKey[11] = (byte)(old >> 0x18 & 0xff);
        }

        public void encrypt(byte[] raw)
        {
            encrypt(raw, 0, raw.Length);
        }

        public void encrypt(byte[] raw, int offset, int size)
        {
            int temp = 0;
            for (int i = 0; i < size; i++)
            {
                int temp2 = raw[offset + i] & 0xFF;
                temp = temp2 ^ _outKey[i & 15] ^ temp;
                raw[offset + i] = (byte)temp;
            }

            ulong old = (ulong)_outKey[8] & 0xff;
            old |= (ulong)_outKey[9] << 8 & 0xff00;
            old |= (ulong)_outKey[10] << 0x10 & 0xff0000;
            old |= (ulong)_outKey[11] << 0x18 & 0xff000000;

            old += (ulong)size;

            _outKey[8] = (byte)(old & 0xff);
            _outKey[9] = (byte)(old >> 0x08 & 0xff);
            _outKey[10] = (byte)(old >> 0x10 & 0xff);
            _outKey[11] = (byte)(old >> 0x18 & 0xff);
        }
    }
}
