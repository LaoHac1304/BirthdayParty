using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Application.Service;
using BirthdayParty.Services.Constants;
using BirthdayParty.Services.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Services.Extensions
{
    public static class DependencyServices
    {

        public static IServiceCollection AddJwtValidation(this IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder().Build();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = configuration.GetSection("Jwt:JWT_ISSUER").Get<string>(),
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:JWT_SECRET_KEY").Get<string>()))
                };
            });
            return services;
        }


    }
}
