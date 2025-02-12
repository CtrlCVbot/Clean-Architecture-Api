
using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Infrastructure.Authentication;
using Infrastructure.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services
            , IConfiguration configuration)

        {
            return services
                .AddDatabaseMember(configuration)
                .AddAuthenticationInternal(configuration);
        }
        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("Database");


            // MSSQL 데이터베이스 등록
            services.AddDbContext<ApplicationDbContext>(
                options => options
                    .UseSqlServer(connectionString));   

            services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

            return services;
        }

        private static IServiceCollection AddDatabaseMember(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("MemberDbConnectionString");

            

            // MSSQL 데이터베이스 등록
            services.AddDbContext<ApplicationDbContext>(
                options => options
                    .UseSqlServer(connectionString));

            services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

            return services;
        }
        private static IServiceCollection AddAuthenticationInternal(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(o =>
            //    {
            //        o.RequireHttpsMetadata = false;
            //        o.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!)),
            //            ValidIssuer = configuration["Jwt:Issuer"],
            //            ValidAudience = configuration["Jwt:Audience"],
            //            ClockSkew = TimeSpan.Zero
            //        };
            //    });

            services.AddHttpContextAccessor();
            services.AddScoped<IUserContext, UserContext>();
            //services.AddSingleton<IPasswordHasher, PasswordHasher>();
            //services.AddSingleton<ITokenProvider, TokenProvider>();

            return services;
        }
    }
}
