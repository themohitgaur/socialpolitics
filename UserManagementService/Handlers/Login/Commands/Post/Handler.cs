using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialPolitics.UserManagementService.Repositories.Interfaces;
using SocialPolitics.UserManagementService.Infrastructure.Data.Models;

namespace SocialPolitics.UserManagementService.Handlers.Login.Commands.Post;

internal class Handler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher) : IRequestHandler<Request, Response>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;
    async Task<Response> IRequestHandler<Request, Response>.Handle(Request request, CancellationToken cancellation)
    {
        var user = await _userRepository.GetUserByEmailId(request.EmailId, cancellation);
        if (user == null)
        {
            throw new ArgumentException("No user is registered with this email");
        }
        var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);

        if (verificationResult == PasswordVerificationResult.Failed)
        {
            throw new Exception("Wrong Password Provided");
        }
        //Auth Token Generation algorithm
        return new Response("Token");
    }
}
