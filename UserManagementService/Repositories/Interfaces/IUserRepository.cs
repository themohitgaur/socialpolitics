using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using SocialPolitics.UserManagementService.Api.ApiModels;
using SocialPolitics.UserManagementService.Infrastructure.Data.Models;

namespace SocialPolitics.UserManagementService.Repositories.Interfaces;

internal interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUserAsync(CancellationToken ct = default);
    Task<Boolean> RegisterUserAsync(User userDataModel, CancellationToken ct = default);

    Task<User> GetUserByEmailId(String emailId, CancellationToken ct = default);
    //Task<Boolean> ValidatePassword(String userName, String password);
}
