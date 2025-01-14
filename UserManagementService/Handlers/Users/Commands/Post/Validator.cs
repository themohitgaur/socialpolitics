using FluentValidation;

namespace SocialPolitics.UserManagementService.Handlers.Users.Commands.Post
{
    public class Validator: AbstractValidator<Request>
    {
        public Validator() 
        {
            RuleFor(x=>x.UserApiModel.FullName).NotEmpty().WithMessage("Name is Required");
            RuleFor(x => x.UserApiModel.Password).NotEmpty();
        }
    }
}
