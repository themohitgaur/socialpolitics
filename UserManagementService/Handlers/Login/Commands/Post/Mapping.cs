using AutoMapper;
using SocialPolitics.UserManagementService.Api.ApiModels;
using SocialPolitics.UserManagementService.Infrastructure.Data.Models;

namespace SocialPolitics.UserManagementService.Handlers.Login.Commands.Post;
public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserApiModel>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id)) // Convert string Id to Guid
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password)); // Map Password to PasswordHash
    }
}