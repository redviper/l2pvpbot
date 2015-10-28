using System;
using System.Collections.Generic;
using System.Text;

namespace l2pvp
{
    public class ByteBuffer
    {
        //// Methods
        // Fields
        private byte[] _data;
        private int _index;
        private int _length;
        private int _maxlength;
        private const int MAX_LENGTH = 0x400;

        public ByteBuffer()
        {
            this._maxlength = 0x400;
            this._data = new byte[this._maxlength];
            this._length = this._maxlength;
            this._index = 0;
        }

        public ByteBuffer(int len)
        {
            if (len > this._maxlength)
            {
                this._maxlength = len;
            }
            this._data = new byte[this._maxlength];
            this._length = len;
            this._index = 0;
        }

        public ByteBuffer(byte[] buff)
        {
            this._length = buff.Length;
            if (this._length > this._maxlength)
            {
                this._maxlength = this._length;
            }
            this._data = new byte[this._maxlength];
            this._index = 0;
            buff.CopyTo(this._data, 0);
        }

        public void ClearData()
        {
            for (int num1 = 0; num1 < this._maxlength; num1++)
            {
                this._data[num1] = 0;
            }
        }


        public byte[] Get_ByteArray()
        {
            byte[] buffer1 = new byte[this._length];
            for (int num1 = 0; num1 < this._length; num1++)
            {
                buffer1[num1] = this._data[num1];
            }
            return buffer1;
        }

        public byte GetByte(int ind)
        {
            if (this._length >= ind)
            {
                return this._data[ind];
            }
            return 0;
        }

        public int GetIndex()
        {
            return this._index;
        }

        public byte ReadByte()
        {
            if (this._length >= (this._index + 1))
            {
                byte num1 = this._data[this._index];
                this._index++;
                return num1;
            }
            return 0;
        }

        public char ReadChar()
        {
            if (this._length >= (this._index + 1))
            {
                char ch1 = BitConverter.ToChar(this._data, this._index);
                this._index++;
                return ch1;
            }
            return '\0';
        }


        public double ReadDouble()
        {
            if (this._length >= (this._index + 8))
            {
                double num1 = BitConverter.ToDouble(this._data, this._index);
                this._index += 8;
                return num1;
            }
            return 0;
        }

        public short ReadInt16()
        {
            if (this._length >= (this._index + 2))
            {
                short num1 = BitConverter.ToInt16(this._data, this._index);
                this._index += 2;
                return num1;
            }
            return 0;
        }


        public int ReadInt32()
        {
            if (this._length >= (this._index + 4))
            {
                int num1 = BitConverter.ToInt32(this._data, this._index);
                this._index += 4;
                return num1;
            }
            return 0;
        }

        public long ReadInt64()
        {
            if (this._length >= (this._index + 8))
            {
                long num1 = BitConverter.ToInt64(this._data, this._index);
                this._index += 8;
                return num1;
            }
            return (long)0;
        }

        public string ReadString()
        {
            try
            {
                string text1 = "";
                for (char ch1 = (char)this._data[this._index]; ch1 != '\0'; ch1 = (char)this._data[this._index])
                {
                    text1 = text1 + ch1;
                    this._index += 2;
                }
                this._index += 2;
                return text1;
            }
            catch
            {
                return "";
            }
        }

        public ushort ReadUInt16()
        {
            if (this._length >= (this._index + 2))
            {
                ushort num1 = BitConverter.ToUInt16(this._data, this._index);
                this._index += 2;
                return num1;
            }
            return 0;
        }

        public uint ReadUInt32()
        {
            if (this._length >= (this._index + 4))
            {
                uint num1 = BitConverter.ToUInt32(this._data, this._index);
                this._index += 4;
                return num1;
            }
            return 0;
        }

        public ulong ReadUInt64()
        {
            if (this._length >= (this._index + 8))
            {
                ulong num1 = BitConverter.ToUInt64(this._data, this._index);
                this._index += 8;
                return num1;
            }
            return 0;
        }

        public void ResetIndex()
        {
            this._index = 0;
        }


        public void Resize(int len)
        {
            if (len <= this._maxlength)
            {
                this._length = len;
            }
            if (len > this._maxlength)
            {
                byte[] buffer1 = new byte[this._length];
                this._data.CopyTo(buffer1, this._length);
                this._maxlength = len;
                this._data = new byte[this._maxlength];
                buffer1.CopyTo(this._data, this._length);
                this._length = this._maxlength;
            }
        }


        public void SetByte(byte b)
        {
            if (this._length >= (this._index + 1))
            {
                this._index++;
                this._data[this._index] = b;
            }
        }



        public void SetByte(byte b, int ind)
        {
            if (this._length >= ind)
            {
                this._data[ind] = b;
            }
        }

        public void SetIndex(int ind)
        {
            this._index = ind;
        }


        public void WriteByte(byte val)
        {
            if (this._length >= (this._index + 1))
            {
                this._data[this._index] = val;
                this._index++;
            }
        }


        public void WriteDouble(double val)
        {
            if (this._length >= (this._index + 8))
            {
                byte[] buffer1 = new byte[8];
                buffer1 = BitConverter.GetBytes(val);
                this._data[this._index] = buffer1[0];
                this._data[this._index + 1] = buffer1[1];
                this._data[this._index + 2] = buffer1[2];
                this._data[this._index + 3] = buffer1[3];
                this._data[this._index + 4] = buffer1[4];
                this._data[this._index + 5] = buffer1[5];
                this._data[this._index + 6] = buffer1[6];
                this._data[this._index + 7] = buffer1[7];
                this._index += 8;
            }
        }

        public void WriteInt16(short val)
        {
            if (this._length >= (this._index + 2))
            {
                byte[] buffer1 = new byte[2];
                buffer1 = BitConverter.GetBytes(val);
                this._data[this._index] = buffer1[0];
                this._data[this._index + 1] = buffer1[1];
                this._index += 2;
            }
        }

        public void WriteInt32(int val)
        {
            if (this._length >= (this._index + 4))
            {
                byte[] buffer1 = new byte[4];
                buffer1 = BitConverter.GetBytes(val);
                this._data[this._index] = buffer1[0];
                this._data[this._index + 1] = buffer1[1];
                this._data[this._index + 2] = buffer1[2];
                this._data[this._index + 3] = buffer1[3];
                this._index += 4;
            }
        }


        public void WriteInt64(long val)
        {
            if (this._length >= (this._index + 8))
            {
                byte[] buffer1 = new byte[8];
                buffer1 = BitConverter.GetBytes(val);
                this._data[this._index] = buffer1[0];
                this._data[this._index + 1] = buffer1[1];
                this._data[this._index + 2] = buffer1[2];
                this._data[this._index + 3] = buffer1[3];
                this._data[this._index + 4] = buffer1[4];
                this._data[this._index + 5] = buffer1[5];
                this._data[this._index + 6] = buffer1[6];
                this._data[this._index + 7] = buffer1[7];
                this._index += 8;
            }
        }


        public void WriteString(string text)
        {
            if (this._length >= ((this._index + (text.Length * 2)) + 2))
            {
                for (int num1 = 0; num1 < text.Length; num1++)
                {
                    this.WriteByte(Convert.ToByte(text[num1]));
                    this.WriteByte(0);
                }
                this.WriteByte(0);
                this.WriteByte(0);
            }
        }

        public void WriteUInt16(ushort val)
        {
            if (this._length >= (this._index + 2))
            {
                byte[] buffer1 = new byte[2];
                buffer1 = BitConverter.GetBytes(val);
                this._data[this._index] = buffer1[0];
                this._data[this._index + 1] = buffer1[1];
                this._index += 2;
            }
        }

        public void WriteUInt32(uint val)
        {
            if (this._length >= (this._index + 4))
            {
                byte[] buffer1 = new byte[4];
                buffer1 = BitConverter.GetBytes(val);
                this._data[this._index] = buffer1[0];
                this._data[this._index + 1] = buffer1[1];
                this._data[this._index + 2] = buffer1[2];
                this._data[this._index + 3] = buffer1[3];
                this._index += 4;
            }
        }


        public void WriteUInt64(ulong val)
        {
            if (this._length >= (this._index + 8))
            {
                byte[] buffer1 = new byte[8];
                buffer1 = BitConverter.GetBytes(val);
                this._data[this._index] = buffer1[0];
                this._data[this._index + 1] = buffer1[1];
                this._data[this._index + 2] = buffer1[2];
                this._data[this._index + 3] = buffer1[3];
                this._data[this._index + 4] = buffer1[4];
                this._data[this._index + 5] = buffer1[5];
                this._data[this._index + 6] = buffer1[6];
                this._data[this._index + 7] = buffer1[7];
                this._index += 8;
            }
        }

    }

}
