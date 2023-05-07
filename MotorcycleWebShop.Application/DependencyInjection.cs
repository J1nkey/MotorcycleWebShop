using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MotorcycleWebShop.Application.Common.Behaviours;
using MotorcycleWebShop.Application.Options.JwtOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleWebShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration, IServiceProvider provider)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.ConfigureOptions<JwtOptionsSetup>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    //JwtOptions jwtOptions = provider.GetService<IOptions<JwtOptions>>()!.Value;
                    JwtOptions jwtOptions = new JwtOptions();
                    configuration.GetSection("JwtConfiguration").Bind(jwtOptions);

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtOptions.ValidIssuer,
                        ValidAudience = jwtOptions.ValidAudience,
                        ValidateIssuer = jwtOptions.ValidateIssuer,
                        ValidateAudience = jwtOptions.ValidateAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecurityKey)),
                        ValidateIssuerSigningKey = jwtOptions.ValidateIssuerSigningKey,
                        ValidateLifetime = jwtOptions.ValidateLifetime
                    };
                });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }
    }
}
