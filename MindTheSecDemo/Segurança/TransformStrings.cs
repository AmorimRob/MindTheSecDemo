using System;
using System.Text;

namespace MindTheSecDemo.Segurança
{
    public static class TransformStrings
    {
        public static string Decode(this string text)
        {
            var fromBase64 = Convert.FromBase64String(text);
            var unescaped = System.Text.RegularExpressions.Regex.Unescape(Encoding.UTF8.GetString(fromBase64));

            var flipped = Flip(unescaped);
            return Encoding.UTF8.GetString(flipped, 0, flipped.Length);
        }

        public static string Transform(this string text)
        {
            var flipped = Flip(text);
            return Convert.ToBase64String(flipped);
        }

        private static byte[] Flip(string text)
        {
            var buffer = Encoding.UTF8.GetBytes(text);
            var key = 0xd34db33f;
            var k1 = key & 0xff;
            var k2 = (key >> 8) & 0xff;
            var k3 = (key >> 16) & 0xff;
            var k4 = (key >> 24) & 0xff;
            var flipped = new byte[buffer.Length];
            for (var i = 0; i < buffer.Length; i++)
            {
                var c = buffer[i];
                var temp = c ^ k1;
                temp ^= k2;
                temp ^= k3;
                temp ^= k4;
                flipped[i] = (byte)temp;
            }
            return flipped;
        }
    }
}
