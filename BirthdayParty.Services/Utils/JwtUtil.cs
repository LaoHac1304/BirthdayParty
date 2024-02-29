using BirthdayParty.Domain.Models;
using BirthdayParty.Services.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Services.Utils
{
    public record DecodedToken(string KeyId,
        string Issuer,
        List<string> Audience,
        List<(string Type, string Value)> Claims,
        DateTime Expiration,
        string SigningAlgorithm,
        string RawData,
        string Subject,
        DateTime ValidFrom,
        string Header,
        string Payload);
    public class JwtUtil
    {
        private JwtUtil() { }
        public static JwtSecurityToken ConvertJwtStringToJwtSecurityToken(string? jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);

            return token;
        }

        public static DecodedToken DecodeJwt(JwtSecurityToken token)
        {
            var keyId = token.Header.Kid;
            var audience = token.Audiences.ToList();
            var claims = token.Claims.Select(claim => (claim.Type, claim.Value)).ToList();

            return new DecodedToken(
                keyId,
                token.Issuer,
                audience,
                claims,
                token.ValidTo,
                token.SignatureAlgorithm,
                token.RawData,
                token.Subject,
                token.ValidFrom,
                token.EncodedHeader,
                token.EncodedPayload
            );
        }

        public static string GenerateJwtToken(Account account, Tuple<string, Guid> guidClaim)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var jwtIssuer = configuration.GetSection("Jwt:JWT_ISSUER").Get<string>();
            var jwtKey = configuration.GetSection("Jwt:JWT_SECRET_KEY").Get<string>();

            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
            SymmetricSecurityKey secrectKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(secrectKey, SecurityAlgorithms.HmacSha256Signature);
            string issuer = jwtIssuer;
            List<Claim> claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, account.Id),
            new Claim(JwtRegisteredClaimNames.Email, account.Email),
            new Claim(ClaimTypes.Role, account.Role),
        };
            if (guidClaim != null) claims.Add(new Claim(guidClaim.Item1, guidClaim.Item2.ToString()));
            var expires = DateTime.Now.AddDays(30);
            var token = new JwtSecurityToken(issuer, null, claims, notBefore: DateTime.Now, expires, credentials);
            return jwtHandler.WriteToken(token);
        }
    }
}
