using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using TiElStats.Database;
using TiElStats.Models.EntityModels;
using TiElStats.Models.ViewModels;
using TiElStats.Models.ViewModels.User;
using TiElStats.Services.Security;

namespace TiElStats.Controllers
{
    [Authorize]
    [Route("api/users")]
    public class UsersController : Controller
    {
        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public void Register([FromBody] RegisterViewModel registerViewModel)
        { 
            var usersColletion = DatabaseContext.Users();
            var user = usersColletion.Find(u=>u.Email == registerViewModel.Email).FirstOrDefault();

            if (registerViewModel.Password == registerViewModel.PasswordRepeated && user == null)
            {
                StringBuilder Sb = new StringBuilder();

                using (var hash = SHA256.Create())
                {
                    Encoding enc = Encoding.UTF8;
                    Byte[] result = hash.ComputeHash(enc.GetBytes(registerViewModel.Password));
                    foreach (Byte b in result)
                    {
                        Sb.Append(b.ToString("x2"));

                    }
                }

                var userToInsert = new User()
                {
                    Email = registerViewModel.Email,
                    Password = Sb.ToString(),
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    IsDeleted = false,
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                };
                usersColletion.InsertOne(userToInsert);
            }
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public string Login([FromBody] RegisterViewModel loginViewModel)
        {
            var users = DatabaseContext.Users();
            var userPasswordHash = users
                .Find(new BsonDocument { { "email", loginViewModel.Email } })
                .FirstOrDefault()
                .Password;

            var userValidator = new UserValidator(loginViewModel.Password, userPasswordHash);

            if (userValidator.ValidateUser())
            {
                var tokenGenerator = new TokenGenerator(loginViewModel.Email);
                string token = tokenGenerator.Generate();
                return token;
            }

            else
            {
                return HttpStatusCode.BadRequest.ToString();
            }
        }
    }
}