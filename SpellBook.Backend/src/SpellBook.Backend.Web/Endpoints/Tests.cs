using SpellBook.Backend.Web.Infrastructure;

namespace SpellBook.Backend.Web.Endpoints;

public class Tests : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(TestEndpoint);
    }

    private async Task<IEnumerable<string>> TestEndpoint()
    {
        return await Task.FromResult(new List<string> { "Test1", "Test2" });
    }
}
