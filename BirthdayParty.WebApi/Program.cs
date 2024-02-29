using BirthdayParty.Domain.DbContexts;
using BirthdayParty.Services.Extensions;
using BirthdayParty.WebApi.Constants;
using BirthdayParty.WebApi.Converter;
using BirthdayParty.WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pos_System.API.Extensions;
using System.Text;
using System.Text.Json.Serialization;

//var logger = NLog.LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config")).GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    /*builder.Logging.ClearProviders();
    builder.Host.UseNLog()*/;

    // Add services to the container.
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: CorsConstant.PolicyName,
            policy => { policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod(); });
    });
    builder.Services.AddControllers().AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        x.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
    });
    builder.Services.AddUnitOfWork();
    builder.Services.AddServices(builder.Configuration);
    builder.Services.AddAccessor();
    //builder.Services.AddJwtValidation();
    //Jwt configuration starts here
    var jwtIssuer = builder.Configuration.GetSection("Jwt:JWT_ISSUER").Get<string>();
    var jwtKey = builder.Configuration.GetSection("Jwt:JWT_SECRET_KEY").Get<string>();

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(options =>
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,
             ValidIssuer = jwtIssuer,
             ValidAudience = jwtIssuer,
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
         };
     });
    //Jwt configuration ends here
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddConfigSwagger();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddleware<ExceptionHandlingMiddleware>();

    //app.UseHttpsRedirection();
    app.UseCors(CorsConstant.PolicyName);
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    //logger.Error(exception, "Stop program because of exception");
    Console.WriteLine(exception.ToString());
}
finally
{
    //NLog.LogManager.Shutdown();
}
