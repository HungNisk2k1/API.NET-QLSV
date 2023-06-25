using System;
using System.Security.Cryptography;
using System.Text;

namespace NHCH.ULT
{
    public static class Cryptor
    {
        /// <summary>
        /// Encrypt password to insert into database 
        /// </summary>
        /// <param name="UserName">UserName is a salt</param>
        /// <param name="Password">Password</param>
        /// <returns></returns>
        public static string EncryptPasswordUser(string UserName, string Password)
        {

            using (MD5 md5Hash = MD5.Create())
            {
                string t = GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, Password + UserName.ToLower()) + UserName.ToLower());
                return GetMd5Hash(md5Hash, GetMd5Hash(md5Hash, Password + UserName.ToLower()) + UserName.ToLower());
            }

        }


        /// <summary>
        /// mã hóa đơn giản, 1 mức
        /// </summary>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static string EncryptPasswordUser(string Password)
        {

            using (MD5 md5Hash = MD5.Create())
            {
                return GetMd5Hash(md5Hash, Password);
            }
        }


        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
