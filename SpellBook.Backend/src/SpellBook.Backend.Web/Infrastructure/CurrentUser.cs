using System.Security.Claims;
using SpellBook.Backend.Infrastructure.Data.Common;

namespace SpellBook.Backend.Web.Infrastructure;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
{
    public string? Id => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}
