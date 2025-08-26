using SpellBook.Backend.Infrastructure.Identity.Entites;
using SpellBook.Backend.Web.Infrastructure;

namespace SpellBook.Backend.Web.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapIdentityApi<User>();
    }
}
