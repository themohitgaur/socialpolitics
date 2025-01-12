using SocialPolitics.UserManagementService.Infrastructure.Data.Models;

namespace SocialPolitics.UserManagementService.Repositories.Interfaces;

internal interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUserAsync(CancellationToken ct = default);
}
