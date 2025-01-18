namespace SocialPolitics.UserManagementService.Api.Endpoints.Users;

public class Routes
{
    public const String Users = $"{nameof(Api)}/{nameof(Users)}/allUsers";
    public const String RegisterUsers = $"{nameof(Api)}/{nameof(Users)}/auth/register";
}
