using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Dispatcher
{
    public static class ValidatorTokenJwt
    {
        public static bool Validate(string token, string keyPublic) 
        {
            byte[] data = Convert.FromBase64String(keyPublic);
            string decodedJson = Encoding.UTF8.GetString(data);

            var key = new JsonWebKey(decodedJson);

            var tokenHandler = new JsonWebTokenHandler();

            var validationResult = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "http://localhost:8080/realms/demo",
                ValidAudience = "registration-service",
                IssuerSigningKey = key
            });

            return validationResult.IsValid;
        }
    }
}
