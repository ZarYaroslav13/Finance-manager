using System.Net;
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
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.UnitOfWork;
using FinanceManager.ServiceDefaults.Routing;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

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

        services.AddIdentity<FinanceManagerUser, FinanceManagerRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        services.AddHangfire(x => x.UseSqlServerStorage(configuration.GetConnectionString("DbConnection")));
        services.AddHangfireServer();

        services.AddHttpContextAccessor();
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

        services.AddAuthentication(authentication =>
        {
            authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = authOptions.ISSUER,
                ValidAudience = authOptions.AUDIENCE,

                RoleClaimType = ClaimTypes.Role,

                IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
            };

            options.Events = new()
            {
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception is SecurityTokenExpiredException)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(Result.Fail("The Token is expired."));
                        return context.Response.WriteAsync(result);
                    }

#if DEBUG
                    context.NoResult();
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "text/plain";
                    return context.Response.WriteAsync(context.Exception.ToString());
#else
                                c.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                c.Response.ContentType = "application/json";
                                var result = JsonConvert.SerializeObject(Result.Fail("An unhandled error has occurred."));
                                return c.Response.WriteAsync(result);
#endif
                },
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    if (!context.Response.HasStarted)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(Result.Fail("You are not Authorized."));
                        return context.Response.WriteAsync(result);
                    }

                    return Task.CompletedTask;
                },
                OnForbidden = context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                    context.Response.ContentType = "application/json";
                    var result = JsonConvert.SerializeObject(Result.Fail("You are not authorized to access this resource."));
                    return context.Response.WriteAsync(result);
                }
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

        builder.Services.Configure<MailConfiguration>
            (builder.Configuration.GetSection(MailConfiguration.Section));

        return builder;
    }
}
