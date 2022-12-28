using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class HashExtensions
    {
        public static string HashString(string givenText)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(givenText));
            string hashText = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

            return hashText;
        }
    }
}
