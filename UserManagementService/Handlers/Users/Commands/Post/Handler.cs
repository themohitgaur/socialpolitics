using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialPolitics.UserManagementService.Infrastructure.Data.Models;
using SocialPolitics.UserManagementService.Repositories.Interfaces;

namespace SocialPolitics.UserManagementService.Handlers.Users.Commands.Post;

internal class Handler(IUserRepository userRepository, IMapper mapper, IPasswordHasher<User> passwordHasher) : IRequestHandler<Request, Response>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMapper _mapper = mapper;
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;
    async Task<Response> IRequestHandler<Request, Response>.Handle(Request request, CancellationToken cancellation)
    {
        var user = _mapper.Map<User>(request.UserApiModel);
        user.Id = null;
        user.Password = _passwordHasher.HashPassword(user, request.UserApiModel.Password!);
        user.CreatedOn = DateTime.Now.ToString("dd-MM-yyyy");
        user.CreatedBy = "Session User";
        if(await _userRepository.RegisterUserAsync(user, cancellation))
        {
            return new Response("User Added Succesfully");
        }
        throw new Exception("Unable to add User");
    }
}
