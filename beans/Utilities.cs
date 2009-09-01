using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace beans
{
    public class Utilities
    {

        protected static string EncryptKey = "ThuTrang";

        public static string Decrypt(string text)
        {

            byte[] encodedkey;
            byte[] iv = { 0x1F, 0x2E, 0x3D, 0x4C, 0x5B, 0x6A, 0x78, 0xA7 };
            byte[] bytes;

            encodedkey = Encoding.UTF8.GetBytes(EncryptKey);
            DESCryptoServiceProvider csp = new DESCryptoServiceProvider();

            bytes = Convert.FromBase64String(text);

            MemoryStream ms = new MemoryStream();

            try
            {
                CryptoStream cs = new CryptoStream(ms, csp.CreateDecryptor(encodedkey, iv), CryptoStreamMode.Write);
                cs.Write(bytes, 0, bytes.Length);
                cs.FlushFinalBlock();
            }
            catch (Exception ex)
            {
                
            }

            return Encoding.UTF8.GetString(ms.ToArray());

        }

        public static string Encrypt(string text)
        {

            byte[] encodedkey;
            byte[] iv = { 0x1F, 0x2E, 0x3D, 0x4C, 0x5B, 0x6A, 0x78, 0xA7 };
            byte[] bytes;

            encodedkey = Encoding.UTF8.GetBytes(EncryptKey);
            DESCryptoServiceProvider csp = new DESCryptoServiceProvider();

            bytes = Encoding.UTF8.GetBytes(text);
            MemoryStream ms = new MemoryStream();

            try
            {
                CryptoStream cs = new CryptoStream(ms, csp.CreateEncryptor(encodedkey, iv), CryptoStreamMode.Write);

                cs.Write(bytes, 0, bytes.Length);
                cs.FlushFinalBlock();

            }
            catch (Exception ex)
            {
                return "";
            }

            return Convert.ToBase64String(ms.ToArray());

        }

        public static bool IsGreaterThenZero(params int[] arguments)
        {
            int sum = 0;
            foreach (int i in arguments)
            {
                if (i < 0)
                    return false;
                sum += i;
            }
            return (sum > 0);
        }
    }
}
