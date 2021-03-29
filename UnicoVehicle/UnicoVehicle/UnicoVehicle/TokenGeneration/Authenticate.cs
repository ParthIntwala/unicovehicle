using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using UnicoVehicle.DTO;

namespace UnicoVehicle
{
    public static class Authenticate
    {
        public static string GenerateJSONWebToken(RegisterUser login)
        {
            //string key = GetMd5Hash(login);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("35bccf91b9bf7f00677f7d1fcedf0a31"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(login.FirstName + " " + login.LastName + " " + login.UserId.ToString(), login.UserTypeId.ToString()),
            };

            var token = new JwtSecurityToken(
                "https://localhost:5001",
                "https://localhost:5001",
                claims,
                DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(60),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //private static string GetMd5Hash(RegisterUser login)
        //{
        //    using MD5 md5Hash = MD5.Create();
        //    string input = login.FirstName + login.LastName + login.UserTypeId;
        //    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        //    StringBuilder sBuilder = new StringBuilder();

        //    for (int i = 0; i < data.Length; i++)
        //    {
        //        sBuilder.Append(data[i].ToString("x2"));
        //    }
        //    return sBuilder.ToString();
        //}

        internal static TokenValidationParameters tokenValidationParameters;

        public static void ConfigureJWTAuthentication(this IServiceCollection services)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("35bccf91b9bf7f00677f7d1fcedf0a31"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidIssuer = "https://localhost:5001",
                ValidAudience = "https://localhost:5001",
                ValidateAudience = true,
                ValidateLifetime = true,
                RequireSignedTokens = true,
                IssuerSigningKey = credentials.Key,
                ClockSkew = TimeSpan.FromDays(60)
            };

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = tokenValidationParameters;

#if PROD || UAT
                    options.IncludeErrorDetails = false;
#elif DEBUG
                    options.RequireHttpsMetadata = false;
#endif
                });
        }
    }
}
