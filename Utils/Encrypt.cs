﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonWebToken_API.Utils
{
    public static class Encrypt
    {
        public static string MD5(string text)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
            
            //using (var provider = System.Security.Cryptography.MD5.Create())
            //{
            //    StringBuilder builder = new StringBuilder();

            //    foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(text)))
            //        builder.Append(b.ToString("x2").ToLower());

            //    return builder.ToString();
            //}
        }
    }
}
