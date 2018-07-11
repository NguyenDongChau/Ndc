using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ndc.Library.EncryptDecrypt
{
    public class Md5Encryption
    {
        public static string EncryptMd5(string plainText)
        {
            var strMd5 = string.Empty;

            //TODO encrypt plain text to md5 string
            var md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(Encoding.ASCII.GetBytes(plainText));

            //get hash result after compute it
            var result = md5.Hash;

            var strBuilder = new StringBuilder();
            foreach (var t in result)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(t.ToString("x2"));
            }
            return strBuilder.ToString();
        }

        public static bool CompareMd5(string plainText, string strMd5)
        {
            var encrypted = EncryptMd5(plainText);
            return encrypted.Equals(strMd5);
        }
    }
}
