using AutoMapper;
using SocialPolitics.UserManagementService.Api.ApiModels;
using SocialPolitics.UserManagementService.Infrastructure.Data.Models;

namespace SocialPolitics.UserManagementService.Handlers.Users.Commands.Post;
public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserApiModel, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId)); // Convert string Id to Guid
            
    }
}