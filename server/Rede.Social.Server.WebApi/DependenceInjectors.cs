using Microsoft.EntityFrameworkCore;
using Rede.Social.Server.Infra.Data;
using Rede.Social.Server.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Rede.Social.Server.Aplication;

namespace Rede.Social.Server.WebApi;

public static class DependenceInjectors
{
    public static void DataBaseInjectors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("WebApiDatabase")));
    }
    public static void ServicesInjector(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
    }
    public static void RepositoryInjector(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
    public static void JWTInjectorService(this IServiceCollection services, IConfiguration configuration)
    {
        var issuer = configuration["JwtSettings:Issuer"];
        var secret = configuration["JwtSettings:Secret"];

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
                };
            });
    }
}
