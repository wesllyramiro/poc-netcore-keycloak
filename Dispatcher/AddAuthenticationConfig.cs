using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dispatcher
{
    public static class AddAuthenticationConfig
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, AuthSection section) 
        {
            services
                  .AddAuthentication(x =>
                  {
                      x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                      x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                  })
                  .AddJwtBearer(options =>
                  {
                      byte[] data = Convert.FromBase64String(section.KeyPublic);
                      string decodedJson = Encoding.UTF8.GetString(data);

                      var key = new JsonWebKey(decodedJson);

                      options.RequireHttpsMetadata = false;
                      options.SaveToken = true;
                      options.TokenValidationParameters = new TokenValidationParameters
                      {
                          ValidateIssuer = true,
                          ValidateAudience = true,
                          ValidateIssuerSigningKey = true,
                          ValidIssuer = section.Issuer,
                          ValidAudience = section.Audience,
                          IssuerSigningKey = key
                      };
                  });

            return services;
        }
    }
}
