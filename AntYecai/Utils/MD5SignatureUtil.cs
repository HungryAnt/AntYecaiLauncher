using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AntYecai.Utils
{
    public static class MD5SignatureUtil
    {
        public static String GetSignAsHex(String rowText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] md5Bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(rowText));
            StringBuilder hexStringBuilder = new StringBuilder();
            foreach (var md5Byte in md5Bytes)
            {
                hexStringBuilder.Append(md5Byte.ToString("x2"));
            }
            return hexStringBuilder.ToString();
        }
    }
}
