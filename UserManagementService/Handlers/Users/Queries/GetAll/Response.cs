using SocialPolitics.UserManagementService.Api.ApiModels;

namespace SocialPolitics.UserManagementService.Handlers.Users.Queries.GetAll;
public record Response(IEnumerable<UserApiModel> UserDetails);
