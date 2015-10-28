using System;
using System.Collections.Generic;
using System.Text;

namespace l2pvp
{
    class LoginCryptServer
    {
        private static byte[] STATIC_BLOWFISH_KEY = 
	{ 
		(byte) 0x6b, (byte) 0x60, (byte) 0xcb, (byte) 0x5b,
		(byte) 0x82, (byte) 0xce, (byte) 0x90, (byte) 0xb1,
		(byte) 0xcc, (byte) 0x2b, (byte) 0x6c, (byte) 0x55,
		(byte) 0x6c, (byte) 0x6c, (byte) 0x6c, (byte) 0x6c
	};

        private NewCrypt _staticCrypt = new NewCrypt(STATIC_BLOWFISH_KEY);
        private NewCrypt _crypt;
        public Boolean _static = true;
        protected int _key;
        Random x;



        public void setKey(byte[] key)
        {
            _crypt = new NewCrypt(key);
            x = new Random();
            _key = x.Next();
        }

        public Boolean decrypt(byte[] raw, int offset, int size)
        {
            _crypt.decrypt(raw, offset, size);
            return NewCrypt.verifyChecksum(raw, offset, size);
        }

        public int encrypt(byte[] raw, int offset, int size)
        {
            // reserve checksum
            size += 4;


            if (_static)
            {
                // reserve for XOR "key"
                size += 4;

                // padding
                size += 8 - size % 8;
                NewCrypt.encXORPass(raw, offset, size, _key);
                _staticCrypt.crypt(raw, offset, size);

                _static = false;
            }
            else
            {
                // padding
                size += 8 - size % 8;
                NewCrypt.appendChecksum(raw, offset, size);
                _crypt.crypt(raw, offset, size);
            }
            return size;
        }
    }

    class LoginCryptClient
    {
        private static byte[] STATIC_BLOWFISH_KEY = 
	    { 
	    	(byte) 0x6b, (byte) 0x60, (byte) 0xcb, (byte) 0x5b,
    		(byte) 0x82, (byte) 0xce, (byte) 0x90, (byte) 0xb1,
		    (byte) 0xcc, (byte) 0x2b, (byte) 0x6c, (byte) 0x55,
		    (byte) 0x6c, (byte) 0x6c, (byte) 0x6c, (byte) 0x6c
    	};

        private NewCrypt _staticCrypt = new NewCrypt(STATIC_BLOWFISH_KEY);
        private NewCrypt _crypt;
        private Boolean _static = true;

        public void setKey(byte[] key)
        {
            _crypt = new NewCrypt(key);
        }

        public Boolean decrypt(byte[] raw, int offset, int size)
        {
            if (_static)
            {
                _staticCrypt.decrypt(raw, offset, size);
                NewCrypt.decXORPass(raw, offset, size);
                _static = false;
                return true;
            }
            else
            {
                _crypt.decrypt(raw, offset, size);
                return NewCrypt.verifyChecksum(raw, offset, size);
            }
        }

        public int encrypt(byte[] raw, int offset, int size)
        {
            NewCrypt.appendChecksum(raw, offset, size);
            _crypt.crypt(raw, offset, size);
            return size;

        }
    }

    public class NewCrypt
    {
        BlowfishEngine _crypt;
        BlowfishEngine _decrypt;

        /**
         * @param blowfishKey
         */
        public NewCrypt(byte[] blowfishKey)
        {
            _crypt = new BlowfishEngine();
            _crypt.init(true, blowfishKey);
            _decrypt = new BlowfishEngine();
            _decrypt.init(false, blowfishKey);
        }

        //public NewCrypt(String key)
        //{
        //    this(key.getBytes());
        //}

        public static Boolean verifyChecksum(byte[] raw)
        {
            return NewCrypt.verifyChecksum(raw, 0, raw.Length);
        }

        public static Boolean verifyChecksum(byte[] raw, int offset, int size)
        {
            // check if size is multiple of 4 and if there is more then only the checksum
            if ((size & 3) != 0 || size <= 4)
            {
                return false;
            }

            long chksum = 0;
            int count = size - 4;
            long check = -1;
            int i;

            for (i = offset; i < count; i += 4)
            {
                check = raw[i] & 0xff;
                check |= raw[i + 1] << 8 & 0xff00;
                check |= raw[i + 2] << 0x10 & 0xff0000;
                check |= raw[i + 3] << 0x18 & 0xff000000;

                chksum ^= check;
            }

            check = raw[i] & 0xff;
            check |= raw[i + 1] << 8 & 0xff00;
            check |= raw[i + 2] << 0x10 & 0xff0000;
            check |= raw[i + 3] << 0x18 & 0xff000000;

            return check == chksum;
        }

        public static void appendChecksum(byte[] raw)
        {
            NewCrypt.appendChecksum(raw, 0, raw.Length);
        }

        public static void appendChecksum(byte[] raw, int offset, int size)
        {
            long chksum = 0;
            int count = size - 4;
            long ecx;
            int i;

            for (i = offset; i < count; i += 4)
            {
                ecx = raw[i] & 0xff;
                ecx |= raw[i + 1] << 8 & 0xff00;
                ecx |= raw[i + 2] << 0x10 & 0xff0000;
                ecx |= raw[i + 3] << 0x18 & 0xff000000;

                chksum ^= ecx;
            }

            ecx = raw[i] & 0xff;
            ecx |= raw[i + 1] << 8 & 0xff00;
            ecx |= raw[i + 2] << 0x10 & 0xff0000;
            ecx |= raw[i + 3] << 0x18 & 0xff000000;

            raw[i] = (byte)(chksum & 0xff);
            raw[i + 1] = (byte)(chksum >> 0x08 & 0xff);
            raw[i + 2] = (byte)(chksum >> 0x10 & 0xff);
            raw[i + 3] = (byte)(chksum >> 0x18 & 0xff);
        }

        /**
         * Packet is first XOR encoded with <code>key</code>
         * Then, the last 4 bytes are overwritten with the the XOR "key".
         * Thus this assume that there is enough room for the key to fit without overwriting data.
         * @param raw The raw bytes to be encrypted
         * @param key The 4 bytes (int) XOR key
         */
        public static void encXORPass(byte[] raw, int key)
        {
            NewCrypt.encXORPass(raw, 0, raw.Length, key);
        }

        public static void decXORPass(byte[] raw, int offset, int size)
        {
            int keystart = size - 8;
            int edx;
            int ecx = raw[keystart] & 0xFF;
            ecx |= (raw[keystart + 1] & 0xFF) << 8;
            ecx |= (raw[keystart + 2] & 0xFF) << 16;
            ecx |= (raw[keystart + 3] & 0xFF) << 24;


            int pos = keystart;
            while (pos > 4 + offset)
            {
                edx = raw[pos - 4] & 0xFF;
                edx |= (raw[pos - 3] & 0xFF) << 8;
                edx |= (raw[pos - 2] & 0xFF) << 16;
                edx |= (raw[pos - 1] & 0xFF) << 24;

                edx ^= ecx;

                ecx -= edx;

                raw[pos - 4] = (byte)(edx & 0xFF);
                raw[pos - 3] = (byte)(edx >> 8 & 0xFF);
                raw[pos - 2] = (byte)(edx >> 16 & 0xFF);
                raw[pos - 1] = (byte)(edx >> 24 & 0xFF);

                pos -= 4;
            }

        }
        /**
         * Packet is first XOR encoded with <code>key</code>
         * Then, the last 4 bytes are overwritten with the the XOR "key".
         * Thus this assume that there is enough room for the key to fit without overwriting data.
         * @param raw The raw bytes to be encrypted
         * @param offset The begining of the data to be encrypted
         * @param size Length of the data to be encrypted
         * @param key The 4 bytes (int) XOR key
         */
        public static void encXORPass(byte[] raw, int offset, int size, int key)
        {
            int stop = size - 8;
            int pos = 4 + offset;
            int edx;
            int ecx = key; // Initial xor key

            while (pos < stop)
            {
                edx = (raw[pos] & 0xFF);
                edx |= (raw[pos + 1] & 0xFF) << 8;
                edx |= (raw[pos + 2] & 0xFF) << 16;
                edx |= (raw[pos + 3] & 0xFF) << 24;

                ecx += edx;

                edx ^= ecx;

                raw[pos++] = (byte)(edx & 0xFF);
                raw[pos++] = (byte)(edx >> 8 & 0xFF);
                raw[pos++] = (byte)(edx >> 16 & 0xFF);
                raw[pos++] = (byte)(edx >> 24 & 0xFF);
            }

            raw[pos++] = (byte)(ecx & 0xFF);
            raw[pos++] = (byte)(ecx >> 8 & 0xFF);
            raw[pos++] = (byte)(ecx >> 16 & 0xFF);
            raw[pos++] = (byte)(ecx >> 24 & 0xFF);
        }


        public byte[] decrypt(byte[] raw)
        {
            byte[] result = new byte[raw.Length];
            uint count = (uint)raw.Length / 8;

            for (uint i = 0; i < count; i++)
            {
                _decrypt.processBlock(raw, i * 8, result, i * 8);
            }

            return result;
        }

        public void decrypt(byte[] raw, int offset, int size)
        {
            byte[] result = new byte[size];
            uint count = (uint)size / 8;

            for (uint i = 0; i < count; i++)
            {
                _decrypt.processBlock(raw, (uint)offset + i * 8, result, i * 8);
            }
            // TODO can the crypt and decrypt go direct to the array
            Array.Copy(result, 0, raw, offset, size);
        }

        public byte[] crypt(byte[] raw)
        {
            uint count = (uint)raw.Length / 8;
            byte[] result = new byte[raw.Length];

            for (uint i = 0; i < count; i++)
            {
                _crypt.processBlock(raw, i * 8, result, i * 8);
            }

            return result;
        }

        public void crypt(byte[] raw, int offset, int size)
        {
            uint count = (uint)size / 8;
            byte[] result = new byte[size];

            for (uint i = 0; i < count; i++)
            {
                _crypt.processBlock(raw, (uint)offset + i * 8, result, i * 8);
            }
            // TODO can the crypt and decrypt go direct to the array
            Array.Copy(result, 0, raw, offset, size);
        }
    }
}
