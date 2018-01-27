using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TiElStats.Services.Security
{
    public class TokenGenerator
    {
        private readonly string _email;

        public TokenGenerator(string email)
        {
            this._email = email;
        }

        public string Generate()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a very long secret used in this marvellous app"));
            
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Email, this._email),
            };
            
            var token = new JwtSecurityToken(
                issuer: "your app",
                audience: "the client of your app",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(28),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
