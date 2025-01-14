using SocialPolitics.UserManagementService.Infrastructure.Data.Models;
using MediatR;
using FastEndpoints;
using System.Net.Mime;
using SocialPolitics.UserManagementService.Handlers.Users.Queries.GetAll;

namespace SocialPolitics.UserManagementService.Api.Endpoints.Users.Queries.GetAll;

public class Endpoint(IMediator _mediator) : EndpointWithoutRequest<Response>
{
    public override void Configure()
    {
        Get(Users.Routes.Users);
        Description(builder => builder.Produces<IEnumerable<User>>(StatusCodes.Status200OK, MediaTypeNames.Application.Json));
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await _mediator.Send(new Request(), ct);
        await SendAsync((Response)result, StatusCodes.Status200OK, ct);
    }
}
