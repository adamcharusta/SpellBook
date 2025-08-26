using Microsoft.AspNetCore.Mvc;
using SpellBook.Backend.Infrastructure.Data;
using SpellBook.Backend.Infrastructure.Data.Common;
using SpellBook.Backend.Web.Infrastructure;

namespace SpellBook.Backend.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddScoped<IUser, CurrentUser>();
        services.AddHttpContextAccessor();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddHealthChecks()
            .AddDbContextCheck<AppDbContext>();

        services.AddExceptionHandler<ExceptionHandler>();

        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        return services;
    }

    public static async Task<WebApplication> UseWebServicesAsync(this WebApplication app)
    {
        await app.InitialiseDatabaseAsync();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHealthChecks("/health");
        app.UseHttpsRedirection();
        app.UseExceptionHandler(options => { });
        app.UseAuthorization();
        app.MapEndpoints();

        return app;
    }
}
