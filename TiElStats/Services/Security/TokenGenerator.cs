using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TiElStats.Utilities;

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
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SystemConstants.TokenSecret));
            
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Email, this._email),
            };
            
            var token = new JwtSecurityToken(
                issuer: SystemConstants.TokenIssuer,
                audience: SystemConstants.TokenAudience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(90),
                signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
            );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
