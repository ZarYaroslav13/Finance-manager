using System.Security.Claims;
using FinanceManager.Application.UseCases.Commons.Behaviours;
using FinanceManager.Domain.Authorization;
using FinanceManager.Domain.Configurations;
using FinanceManager.Domain.Services.Accounts;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Email;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Services.Roles;
using FinanceManager.Domain.Services.Token;
using FinanceManager.Domain.Services.Users;
using FinanceManager.Domain.Services.Wallets;
using FinanceManager.Infrastructure;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.UnitOfWork;
using FinanceManager.ServiceDefaults.Routing;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FinanceManager.ApiService.HostBuilder;

public static class AddServicesConfigurationHostBuilderExtensions
{
    public static IHostApplicationBuilder AddServices(this IHostApplicationBuilder builder)
    {
        var services = builder.Services;
        var configuration = builder.Configuration as IConfiguration;

        builder.AddOptions();

        services.AddMediator();


        services.AddDbConnection(configuration);

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IFinanceReportCreator, FinanceReportCreator>();
        services.AddScoped<IEmailService, SMTPEmailService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IWalletService, WalletService>();
        services.AddScoped<IFinanceService, FinanceService>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddJwtAuthentication(configuration);

        services.AddPoliticalAuthorization();

        services.AddIdentity<FinanceManagerUser, FinanceManagerRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

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
        AuthConfiguration authOptions = configuration.GetSection(AuthConfiguration.Section).Get<AuthConfiguration>();

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
            opt.AddPolicy(PolicyManager.AdminPolicy, policy =>
            {
                policy.RequireClaim(ClaimTypes.Role, PolicyManager.AdminRole);
            });
        });

        return services;
    }

    private static IHostApplicationBuilder AddOptions(this IHostApplicationBuilder builder)
    {
        builder.Services.Configure<AuthConfiguration>(
            builder.Configuration.GetSection(AuthConfiguration.Section));

        return builder;
    }
}
