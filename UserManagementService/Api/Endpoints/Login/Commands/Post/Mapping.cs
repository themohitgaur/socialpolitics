using AutoMapper;
using SocialPolitics.UserManagementService.Handlers.Login.Commands.Post;
namespace SocialPolitics.UserManagementService.Api.Endpoints.Login.Commands.Post
{
    public class Mapping:Profile
    {
        public Mapping() { CreateMap<Command, Request>(); }
    }
}
