namespace SocialPolitics.UserManagementService.Repositories.Interfaces
{
    internal interface ITokenService
    {
        string GenerateToken(String userId, String role);
    }
}
