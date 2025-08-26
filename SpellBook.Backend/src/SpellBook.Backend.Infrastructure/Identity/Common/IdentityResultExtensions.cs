using Microsoft.AspNetCore.Identity;
using SpellBook.Backend.Infrastructure.Identity.Models;

namespace SpellBook.Backend.Infrastructure.Identity.Common;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}
