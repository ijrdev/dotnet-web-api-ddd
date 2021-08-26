using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Domain.Enums;

namespace CrossCutting
{
    public static class Token
    {
        private static readonly byte[] Key = Encoding.ASCII.GetBytes("DotnetWebApiDDD0123456789");

        public static string GenerateToken(Clients client)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(CustomClaimsType.Id.ToString(), client.Id.ToString(), ClaimValueTypes.Integer64),
                    new Claim(CustomClaimsType.Document.ToString(), client.Document.ToString(), ClaimValueTypes.String),
                    new Claim(CustomClaimsType.Email.ToString(), client.Email, ClaimValueTypes.String)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
