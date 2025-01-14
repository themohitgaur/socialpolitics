using SocialPolitics.UserManagementService.Infrastructure.Data.Models;
using MediatR;
using FastEndpoints;
using System.Net.Mime;
using SocialPolitics.UserManagementService.Handlers.Users.Commands.Post;

namespace SocialPolitics.UserManagementService.Api.Endpoints.Users.Commands.Post;

public class Endpoint(IMediator _mediator) : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post(Users.Routes.Users);
        Description(builder => builder.Produces<IEnumerable<User>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json));
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        var result = await _mediator.Send(req, ct); // Pass the incoming request (req) to the handler
        await SendAsync((Response)result, StatusCodes.Status200OK, ct);
    }
}
