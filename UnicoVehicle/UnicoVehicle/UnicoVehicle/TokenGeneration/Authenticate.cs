using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UnicoVehicle.DTO;

namespace UnicoVehicle
{
    public static class Authenticate
    {
        public static string GenerateJSONWebToken(LoginUser login)
        {
            string key = GetMd5Hash(login);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(login.FirstName + " " + login.LastName, login.UserTypeId.ToString()),
            };

            var token = new JwtSecurityToken(
                "https://localhost:5001",
                "https://localhost:5001",
                claims,
                DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMonths(2),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string GetMd5Hash(LoginUser login)
        {
            using MD5 md5Hash = MD5.Create();
            string input = login.FirstName + login.LastName + login.UserTypeId;
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
