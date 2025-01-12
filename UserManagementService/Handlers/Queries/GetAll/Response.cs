using SocialPolitics.UserManagementService.Api.ApiModels;

namespace SocialPolitics.UserManagementService.Handlers.Queries.GetAll;
public record Response(IEnumerable<UserApiModel> UserDetails);
