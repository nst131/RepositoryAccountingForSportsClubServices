using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Application.User.Login
{
    public class LoginQueryValidation : AbstractValidator<LoginQuery>
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public LoginQueryValidation(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;

            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage($"{nameof(LoginQuery.Email)} is not correct");
            RuleFor(x => x.Password).NotEmpty().WithMessage($"{nameof(LoginQuery.Password)} is not correct");
            RuleFor(x => x.Role).MustAsync(ExistRole).WithMessage($"{nameof(LoginQuery.Role)} is not exist");
        }

        private async Task<bool> ExistRole(string role, CancellationToken token = default)
        {
            return await roleManager.RoleExistsAsync(role);
        }
    }
}
