using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TiElStats.Services.Security
{
    public class PasswordEncrypter
    {
        private readonly string _input;

        public PasswordEncrypter(string input)
        {
            this._input = input;
        }

        public string Encrypt()
        {
            StringBuilder loginPasswordHash = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(_input));
                foreach (Byte b in result)
                {
                    loginPasswordHash.Append(b.ToString("x2"));

                }
            }
   
            return loginPasswordHash.ToString();
        }
    }
}
