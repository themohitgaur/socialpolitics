using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using SocialPolitics.UserManagementService.Infrastructure.Data.Context;
using SocialPolitics.UserManagementService.Infrastructure.Data.Models;
using SocialPolitics.UserManagementService.Repositories.Interfaces;

namespace SocialPolitics.UserManagementService.Repositories
{
    internal class UserRepository(UserManagementContext userManagementContext) : IUserRepository
    {
        private readonly UserManagementContext _context = userManagementContext;

        async Task<Boolean> IUserRepository.RegisterUserAsync(User userDataModel, CancellationToken ct = default)
        {
            bool result = true;
            try
            {
                await _context.Users.InsertOneAsync(userDataModel, null, ct);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        async Task<IEnumerable<User>> IUserRepository.GetAllUserAsync(CancellationToken ct)
        {
            var temp = await _context.Users.Find(_ => true).ToListAsync(ct);
            return temp;
        }

        //public Task<bool> ValidatePassword(string userName, string password)
        //{
            
        //}

        async Task<User> IUserRepository.GetUserByEmailId(string emailId, CancellationToken ct = default)
        {
            var temp = await _context.Users.Find(x=>x.Email == emailId).FirstOrDefaultAsync(ct);
            return temp;
        }
    }
}
