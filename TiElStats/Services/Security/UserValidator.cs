using System;
using System.Security.Cryptography;
using System.Text;

namespace TiElStats.Services.Security
{
    public class UserValidator
    {
        private readonly string _loginPassword;
        private readonly string _userPasswordHash;

        public UserValidator(string loginPassword, string userPasswordHash)
        {
            this._loginPassword = loginPassword;
            this._userPasswordHash = userPasswordHash;
        }

        public bool ValidateUser()
        {
            var loginPasswordHash = new PasswordEncrypter(_loginPassword).Encrypt();

            return loginPasswordHash == _userPasswordHash;
        }
    }
}
