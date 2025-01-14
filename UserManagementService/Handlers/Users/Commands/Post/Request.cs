using MediatR;
using SocialPolitics.UserManagementService.Api.ApiModels;

namespace SocialPolitics.UserManagementService.Handlers.Users.Commands.Post;

public record Request(UserApiModel UserApiModel) : IRequest<Response>;


