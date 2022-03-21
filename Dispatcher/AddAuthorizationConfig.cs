using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dispatcher
{
    public static class AddAuthorizationConfig
    {
        public static IServiceCollection AddAuthoriza(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("mellon-adapter", policy => policy.RequireRole("mellon-adapter"));
                options.AddPolicy("matera-adapter", policy => policy.RequireRole("matera-adapter"));

            });

            return services;
        }
    }
}
