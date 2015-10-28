using System;
using System.Collections.Generic;
using System.Text;

namespace l2pvp
{
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
        private byte[] _inKey = new byte[16];
        private byte[] _outKey = new byte[16];

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
