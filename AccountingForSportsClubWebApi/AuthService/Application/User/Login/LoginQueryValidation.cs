using FluentValidation;

namespace Application.User.Login
{
    public class LoginQueryValidation : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidation()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage($"{nameof(LoginQuery.Email)} is not correct");
            RuleFor(x => x.Password).NotEmpty().WithMessage($"{nameof(LoginQuery.Password)} is not correct");
        }
    }
}
