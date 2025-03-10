using FinanceManager.Application.Security;
using FinanceManager.Application.Security.Jwt;
using FinanceManager.Application.UseCases.Commons.Behaviours;
using FinanceManager.Domain.Services.Accounts;
using FinanceManager.Domain.Services.Admins;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Services.Wallets;
using FinanceManager.ServiceDefaults.Routing;
using Infrastructure;
using Infrastructure.Security;
using Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace FinanceManager.ApiService.HostBuilder;

public static class AddServicesConfigurationHostBuilderExtensions
{
    public static IHostApplicationBuilder AddServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration as IConfiguration;

        builder.AddOptions();

        services.AddMediator();

        services.AddSingleton<IPasswordCoder, PasswordCoder>();

        services.AddDbConnection(configuration);

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<IFinanceReportCreator, FinanceReportCreator>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IWalletService, WalletService>();
        services.AddScoped<IFinanceService, FinanceService>();
        services.AddScoped<ITokenManager, TokenManager>();

        services.AddJwtAuthentication(configuration);

        services.AddPoliticalAuthorization();

        services.AddControllers(options =>
            options.Conventions
                .Add(new RouteTokenTransformerConvention(
                        new SlugifyParameterTransformer())));

        return builder;
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

        return services;
    }

    private static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
    {
        const string connectionString = "DbConnection";

        services.AddDbContext<AppDbContext>(option =>
            option.
                UseSqlServer(
                    configuration.
                        GetConnectionString(connectionString)));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        AuthOptions authOptions = configuration.GetSection(AuthOptions.Auth).Get<AuthOptions>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.SaveToken = true;

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer = authOptions.ISSUER,
                            ValidAudience = authOptions.AUDIENCE,

                            IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                        };
                    });

        return services;
    }

    private static IServiceCollection AddPoliticalAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(opt =>
        {
            opt.AddPolicy(AdminService.AdminPolicy, policy =>
            {
                policy.RequireClaim(ClaimTypes.Role, AdminService.AdminRole);
            });
        });

        return services;
    }

    private static IHostApplicationBuilder AddOptions(this IHostApplicationBuilder builder)
    {
        builder.Services.Configure<AuthOptions>(
            builder.Configuration.GetSection(AuthOptions.Auth));

        return builder;
    }
}
