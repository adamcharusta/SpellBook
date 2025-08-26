using Serilog;
using SpellBook.Backend.Application;
using SpellBook.Backend.Infrastructure;
using SpellBook.Backend.Web;

await using var log = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services
        .AddInfrastructureServices(builder.Configuration)
        .AddApplicationServices()
        .AddWebServices();

    var app = builder.Build();

    await app.UseWebServicesAsync();
    app.Run();
}
catch (Exception ex)
{
    log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program;
