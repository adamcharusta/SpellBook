using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpellBook.Backend.Domain.Constants;
using SpellBook.Backend.Domain.Repositories;
using SpellBook.Backend.Infrastructure.Data;
using SpellBook.Backend.Infrastructure.Data.Interceptors;
using SpellBook.Backend.Infrastructure.Data.Repositories;
using SpellBook.Backend.Infrastructure.Identity.Entites;
using SpellBook.Backend.Infrastructure.Identity.Services;

namespace SpellBook.Backend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, BaseEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseMySQL(connectionString);
        });

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services
            .AddIdentityCore<User>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddApiEndpoints();

        services.AddScoped<AppDbContextInitializer>();

        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();

        services.AddAuthorization(options =>
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

        services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
        return services;
    }
}
