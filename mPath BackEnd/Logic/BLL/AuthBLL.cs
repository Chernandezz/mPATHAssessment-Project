using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Common.ViewModels;
using Data.DAL;
using Microsoft.IdentityModel.Tokens;

namespace Logic.BLL
{
    public class AuthBLL
    {
        private const string JwtSecretKey = "L9wJr7@4nCq2zZx8*Kgk5!pYB1#Am8RfTQWt&dUvExGhPjNVoX6LC@5Mz7RfYH";

        public static AuthVMR Login(string email, string passwordHash)
        {
            var user = AuthDAL.Login(email, passwordHash);
            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(JwtSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Expiration = tokenDescriptor.Expires.Value;

            return user;
        }

        public static bool Register(string email, string password, string role)
        {
            return AuthDAL.Register(email, password, role);
        }
    }
}
