using System;
using System.Configuration;
using System.Security.Claims;

using Microsoft.IdentityModel.Tokens;

using ProductManager.Core.DTOs.Authentication;

namespace ProductManager.Api.Modules
{
    internal static class TokenGenerator
    {
        public static string GenerateTokenJwt(AuthenticationDTO Auth)
        {
            // appsetting for Token JWT
            var secretKey = ConfigurationManager.AppSettings["JwtSecretKey"];
            var audienceToken = ConfigurationManager.AppSettings["JwtAudience"];
            var issuerToken = ConfigurationManager.AppSettings["JwtIssuer"];
            var expireTime = ConfigurationManager.AppSettings["JwtExpire"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Role, Auth.Rol) });

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}