using MediatR;

namespace SocialPolitics.UserManagementService.Handlers.Login.Commands.Post;

public record Request(String EmailId, String Password) : IRequest<Response>;


