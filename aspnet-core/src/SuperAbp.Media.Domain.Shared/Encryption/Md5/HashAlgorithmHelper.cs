using System;
using System.Security.Cryptography;
using System.Text;
using Lzez.Tendering.Util.Encryption.Md5;

namespace SuperAbp.Media.Encryption.Md5
{
    public static class HashAlgorithmHelper
    {
        private static readonly char[] Digitals = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

        private static string ToString(byte[] bytes)
        {
            const int byte_len = 2; // 表示一个 byte 的字符长度。

            var chars = new char[byte_len * bytes.Length];

            var index = 0;

            foreach (var item in bytes)
            {
                chars[index] = Digitals[item >> 4/* byte high */]; ++index;
                chars[index] = Digitals[item & 15/* byte low  */]; ++index;
            }

            return new string(chars);
        }

        public static string ComputeHash<THashAlgorithm>(string input) where THashAlgorithm : HashAlgorithm
        {
            var bytes = Encoding.UTF8.GetBytes(input);

            return ToString(THashAlgorithmInstances<THashAlgorithm>.Instance.ComputeHash(bytes));
        }

        public static string ComputeBase64Hash<THashAlgorithm>(string input) where THashAlgorithm : HashAlgorithm
        {
            var bytes = Encoding.UTF8.GetBytes(input);

            return Convert.ToBase64String(THashAlgorithmInstances<THashAlgorithm>.Instance.ComputeHash(bytes));
        }
    }
}