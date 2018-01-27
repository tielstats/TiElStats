using System;
using System.Security.Cryptography;
using System.Text;

namespace TiElStats.Services.Security
{
    public class UserValidator
    {
        private readonly string _email;
        private readonly string _password;

        public UserValidator(string email, string password)
        {
            this._email = email;
            this._password = password;
        }

        public bool ValidateUser()
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(_password));
                foreach (Byte b in result)
                {
                    Sb.Append(b.ToString("x2"));

                }
            }
            return _email == "Tisho" && _password == "123456";
        }

        public bool ValidatePassword()
        {
            return true;
        }
    }
}
