using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// HmacMD5加密
/// </summary>

public class HmacMD5
{
    private uint[] count;
    private uint[] state;
    private byte[] buffer;
    private byte[] Digest;

    public HmacMD5()
    {
        count = new uint[2];
        state = new uint[4];
        buffer = new byte[64];
        Digest = new byte[16];
        init();
    }

    public void init()
    {
        count[0] = 0;
        count[1] = 0;
        state[0] = 0x67452301;
        state[1] = 0xefcdab89;
        state[2] = 0x98badcfe;
        state[3] = 0x10325476;
    }

    public void update(byte[] data, uint length)
    {
        uint left = length;
        uint offset = (count[0] >> 3) & 0x3F;
        uint bit_length = (uint)(length << 3);
        uint index = 0;

        if (length <= 0)
            return;

        count[0] += bit_length;
        count[1] += (length >> 29);
        if (count[0] < bit_length)
            count[1]++;

        if (offset > 0)
        {
            uint space = 64 - offset;
            uint copy = (offset + length > 64 ? 64 - offset : length);
            Buffer.BlockCopy(data, 0, buffer, (int)offset, (int)copy);

            if (offset + copy < 64)
                return;

            transform(buffer);
            index += copy;
            left -= copy;
        }

        for (; left >= 64; index += 64, left -= 64)
        {
            Buffer.BlockCopy(data, (int)index, buffer, 0, 64);
            transform(buffer);
        }

        if (left > 0)
            Buffer.BlockCopy(data, (int)index, buffer, 0, (int)left);

    }

    private static byte[] pad = new byte[64] {
                                                     0x80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                     0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                     0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                     0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
    public byte[] finalize()
    {
        byte[] bits = new byte[8];
        encode(ref bits, count, 8);
        uint index = (uint)((count[0] >> 3) & 0x3f);
        uint padLen = (index < 56) ? (56 - index) : (120 - index);
        update(pad, padLen);
        update(bits, 8);
        encode(ref Digest, state, 16);

        for (int i = 0; i < 64; i++)
            buffer[i] = 0;

        return Digest;
    }

    public string md5String()
    {
        string s = "";

        for (int i = 0; i < Digest.Length; i++)
            s += Digest[i].ToString("x2");

        return s;
    }

    #region Constants for MD5Transform routine.

    private const uint S11 = 7;
    private const uint S12 = 12;
    private const uint S13 = 17;
    private const uint S14 = 22;
    private const uint S21 = 5;
    private const uint S22 = 9;
    private const uint S23 = 14;
    private const uint S24 = 20;
    private const uint S31 = 4;
    private const uint S32 = 11;
    private const uint S33 = 16;
    private const uint S34 = 23;
    private const uint S41 = 6;
    private const uint S42 = 10;
    private const uint S43 = 15;
    private const uint S44 = 21;
    #endregion

    private void transform(byte[] data)
    {
        uint a = state[0];
        uint b = state[1];
        uint c = state[2];
        uint d = state[3];
        uint[] x = new uint[16];

        decode(ref x, data, 64);

        // Round 1
        FF(ref a, b, c, d, x[0], S11, 0xd76aa478); /* 1 */
        FF(ref d, a, b, c, x[1], S12, 0xe8c7b756); /* 2 */
        FF(ref c, d, a, b, x[2], S13, 0x242070db); /* 3 */
        FF(ref b, c, d, a, x[3], S14, 0xc1bdceee); /* 4 */
        FF(ref a, b, c, d, x[4], S11, 0xf57c0faf); /* 5 */
        FF(ref d, a, b, c, x[5], S12, 0x4787c62a); /* 6 */
        FF(ref c, d, a, b, x[6], S13, 0xa8304613); /* 7 */
        FF(ref b, c, d, a, x[7], S14, 0xfd469501); /* 8 */
        FF(ref a, b, c, d, x[8], S11, 0x698098d8); /* 9 */
        FF(ref d, a, b, c, x[9], S12, 0x8b44f7af); /* 10 */
        FF(ref c, d, a, b, x[10], S13, 0xffff5bb1); /* 11 */
        FF(ref b, c, d, a, x[11], S14, 0x895cd7be); /* 12 */
        FF(ref a, b, c, d, x[12], S11, 0x6b901122); /* 13 */
        FF(ref d, a, b, c, x[13], S12, 0xfd987193); /* 14 */
        FF(ref c, d, a, b, x[14], S13, 0xa679438e); /* 15 */
        FF(ref b, c, d, a, x[15], S14, 0x49b40821); /* 16 */

        // Round 2 
        GG(ref a, b, c, d, x[1], S21, 0xf61e2562); /* 17 */
        GG(ref d, a, b, c, x[6], S22, 0xc040b340); /* 18 */
        GG(ref c, d, a, b, x[11], S23, 0x265e5a51); /* 19 */
        GG(ref b, c, d, a, x[0], S24, 0xe9b6c7aa); /* 20 */
        GG(ref a, b, c, d, x[5], S21, 0xd62f105d); /* 21 */
        GG(ref d, a, b, c, x[10], S22, 0x2441453); /* 22 */
        GG(ref c, d, a, b, x[15], S23, 0xd8a1e681); /* 23 */
        GG(ref b, c, d, a, x[4], S24, 0xe7d3fbc8); /* 24 */
        GG(ref a, b, c, d, x[9], S21, 0x21e1cde6); /* 25 */
        GG(ref d, a, b, c, x[14], S22, 0xc33707d6); /* 26 */
        GG(ref c, d, a, b, x[3], S23, 0xf4d50d87); /* 27 */
        GG(ref b, c, d, a, x[8], S24, 0x455a14ed); /* 28 */
        GG(ref a, b, c, d, x[13], S21, 0xa9e3e905); /* 29 */
        GG(ref d, a, b, c, x[2], S22, 0xfcefa3f8); /* 30 */
        GG(ref c, d, a, b, x[7], S23, 0x676f02d9); /* 31 */
        GG(ref b, c, d, a, x[12], S24, 0x8d2a4c8a); /* 32 */

        // Round 3
        HH(ref a, b, c, d, x[5], S31, 0xfffa3942); /* 33 */
        HH(ref d, a, b, c, x[8], S32, 0x8771f681); /* 34 */
        HH(ref c, d, a, b, x[11], S33, 0x6d9d6122); /* 35 */
        HH(ref b, c, d, a, x[14], S34, 0xfde5380c); /* 36 */
        HH(ref a, b, c, d, x[1], S31, 0xa4beea44); /* 37 */
        HH(ref d, a, b, c, x[4], S32, 0x4bdecfa9); /* 38 */
        HH(ref c, d, a, b, x[7], S33, 0xf6bb4b60); /* 39 */
        HH(ref b, c, d, a, x[10], S34, 0xbebfbc70); /* 40 */
        HH(ref a, b, c, d, x[13], S31, 0x289b7ec6); /* 41 */
        HH(ref d, a, b, c, x[0], S32, 0xeaa127fa); /* 42 */
        HH(ref c, d, a, b, x[3], S33, 0xd4ef3085); /* 43 */
        HH(ref b, c, d, a, x[6], S34, 0x4881d05); /* 44 */
        HH(ref a, b, c, d, x[9], S31, 0xd9d4d039); /* 45 */
        HH(ref d, a, b, c, x[12], S32, 0xe6db99e5); /* 46 */
        HH(ref c, d, a, b, x[15], S33, 0x1fa27cf8); /* 47 */
        HH(ref b, c, d, a, x[2], S34, 0xc4ac5665); /* 48 */

        // Round 4
        II(ref a, b, c, d, x[0], S41, 0xf4292244); /* 49 */
        II(ref d, a, b, c, x[7], S42, 0x432aff97); /* 50 */
        II(ref c, d, a, b, x[14], S43, 0xab9423a7); /* 51 */
        II(ref b, c, d, a, x[5], S44, 0xfc93a039); /* 52 */
        II(ref a, b, c, d, x[12], S41, 0x655b59c3); /* 53 */
        II(ref d, a, b, c, x[3], S42, 0x8f0ccc92); /* 54 */
        II(ref c, d, a, b, x[10], S43, 0xffeff47d); /* 55 */
        II(ref b, c, d, a, x[1], S44, 0x85845dd1); /* 56 */
        II(ref a, b, c, d, x[8], S41, 0x6fa87e4f); /* 57 */
        II(ref d, a, b, c, x[15], S42, 0xfe2ce6e0); /* 58 */
        II(ref c, d, a, b, x[6], S43, 0xa3014314); /* 59 */
        II(ref b, c, d, a, x[13], S44, 0x4e0811a1); /* 60 */
        II(ref a, b, c, d, x[4], S41, 0xf7537e82); /* 61 */
        II(ref d, a, b, c, x[11], S42, 0xbd3af235); /* 62 */
        II(ref c, d, a, b, x[2], S43, 0x2ad7d2bb); /* 63 */
        II(ref b, c, d, a, x[9], S44, 0xeb86d391); /* 64 */

        state[0] += a;
        state[1] += b;
        state[2] += c;
        state[3] += d;

        for (int i = 0; i < 16; i++)
            x[i] = 0;
    }

    #region encode - decode
    private void encode(ref byte[] output, uint[] input, uint len)
    {
        uint i, j;
        if (System.BitConverter.IsLittleEndian)
        {
            for (i = 0, j = 0; j < len; i++, j += 4)
            {
                output[j] = (byte)(input[i] & 0xff);
                output[j + 1] = (byte)((input[i] >> 8) & 0xff);
                output[j + 2] = (byte)((input[i] >> 16) & 0xff);
                output[j + 3] = (byte)((input[i] >> 24) & 0xff);
            }
        }
        else
        {
            for (i = 0, j = 0; j < len; i++, j += 4)
            {
                output[j + 3] = (byte)(input[i] & 0xff);
                output[j + 2] = (byte)((input[i] >> 8) & 0xff);
                output[j + 1] = (byte)((input[i] >> 16) & 0xff);
                output[j] = (byte)((input[i] >> 24) & 0xff);
            }
        }
    }

    private void decode(ref uint[] output, byte[] input, uint len)
    {
        uint i, j;
        if (System.BitConverter.IsLittleEndian)
        {
            for (i = 0, j = 0; j < len; i++, j += 4)
                output[i] = ((uint)input[j]) | (((uint)input[j + 1]) << 8) |
                    (((uint)input[j + 2]) << 16) | (((uint)input[j + 3]) << 24);
        }
        else
        {
            for (i = 0, j = 0; j < len; i++, j += 4)
                output[i] = ((uint)input[j + 3]) | (((uint)input[j + 2]) << 8) |
                    (((uint)input[j + 1]) << 16) | (((uint)input[j]) << 24);
        }
    }
    #endregion

    private uint rotate_left(uint x, uint n)
    {
        return (x << (int)n) | (x >> (int)(32 - n));
    }

    #region F, G, H and I are basic MD5 functions.
    private uint F(uint x, uint y, uint z)
    {
        return (x & y) | (~x & z);
    }

    private uint G(uint x, uint y, uint z)
    {
        return (x & z) | (y & ~z);
    }

    private uint H(uint x, uint y, uint z)
    {
        return x ^ y ^ z;
    }

    private uint I(uint x, uint y, uint z)
    {
        return y ^ (x | ~z);
    }
    #endregion

    #region  FF, GG, HH, and II transformations for rounds 1, 2, 3, and 4.
    private void FF(ref uint a, uint b, uint c, uint d, uint x, uint s, uint ac)
    {
        a += F(b, c, d) + x + ac;
        a = rotate_left(a, s) + b;
    }

    private void GG(ref uint a, uint b, uint c, uint d, uint x, uint s, uint ac)
    {
        a += G(b, c, d) + x + ac;
        a = rotate_left(a, s) + b;
    }

    private void HH(ref uint a, uint b, uint c, uint d, uint x, uint s, uint ac)
    {
        a += H(b, c, d) + x + ac;
        a = rotate_left(a, s) + b;
    }

    private void II(ref uint a, uint b, uint c, uint d, uint x, uint s, uint ac)
    {
        a += I(b, c, d) + x + ac;
        a = rotate_left(a, s) + b;
    }
    #endregion
}


