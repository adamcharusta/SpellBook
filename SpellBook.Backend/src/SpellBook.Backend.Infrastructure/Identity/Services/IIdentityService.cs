using SpellBook.Backend.Infrastructure.Identity.Entites;
using SpellBook.Backend.Infrastructure.Identity.Models;

namespace SpellBook.Backend.Infrastructure.Identity.Services;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);
    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
    Task<bool> IsInRoleAsync(string userId, string role);
    Task<bool> AuthorizeAsync(string userId, string policyName);
    Task<Result> DeleteUserAsync(string userId);
    Task<Result> DeleteUserAsync(User user);
}
