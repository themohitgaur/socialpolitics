using SocialPolitics.UserManagementService.Infrastructure.Data.Models;
using MediatR;
using FastEndpoints;
using System.Net.Mime;
using SocialPolitics.UserManagementService.Handlers.Login.Commands.Post;

namespace SocialPolitics.UserManagementService.Api.Endpoints.Login.Commands.Post;

public class Endpoint(IMediator _mediator, AutoMapper.IMapper _mapper) : Endpoint<Command, Response>
{
    public override void Configure()
    {
        Post(Login.Routes.Login);
        Description(builder => builder.Produces<String>(StatusCodes.Status200OK, MediaTypeNames.Application.Json));
        AllowAnonymous();
    }

    public override async Task HandleAsync(Command req, CancellationToken ct)
    {
        var request = _mapper.Map<Request>(req);
        var result = await _mediator.Send(request, ct); // Pass the incoming request (req) to the handler
        await SendAsync(result, StatusCodes.Status200OK, ct);
    }
}
