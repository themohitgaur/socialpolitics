using AutoMapper;
using MediatR;
using SocialPolitics.UserManagementService.Api.ApiModels;
using SocialPolitics.UserManagementService.Repositories.Interfaces;

namespace SocialPolitics.UserManagementService.Handlers.Users.Queries.GetAll;

internal class Handler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<Request, Response>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;
    async Task<Response> IRequestHandler<Request, Response>.Handle(Request request, CancellationToken cancellation)
    {
        var users = await _userRepository.GetAllUserAsync(cancellation);
        // Mapping a list using AutoMapper
        List<UserApiModel> userApiModels = _mapper.Map<List<UserApiModel>>(users);

        return new Response(userApiModels);
    }
}
