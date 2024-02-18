using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Pos_System.API.Extensions;

using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Domain.DbContexts;
using BirthdayParty.Infrastructure.Repository.Common;
using Microsoft.EntityFrameworkCore;

public static class DependencyServices
{
    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork<PartyDbContext>, UnitOfWork<PartyDbContext>>();
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
    {
        return services;
    }

    /*public static IServiceCollection AddJwtValidation(this IServiceCollection services)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables(EnvironmentVariableConstant.Prefix).Build();
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = configuration.GetValue<string>(JwtConstant.Issuer),
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration.GetValue<string>(JwtConstant.SecretKey)))
            };
        });
        return services;
    }*/

    public static IServiceCollection AddConfigSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo() {Title = "Birthday Party", Version = "v1"});
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
            options.MapType<TimeOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "time",
                Example = OpenApiAnyFactory.CreateFromJson("\"13:45:42.0000000\"")
            });
        });
        return services;
    }
}