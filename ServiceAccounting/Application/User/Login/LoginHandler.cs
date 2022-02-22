using Application.Exceptions;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Application.User.Login
{
    public class LoginHandler : ILoginHandler
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IJwtGenerator jwtGenerator;

        public LoginHandler(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtGenerator = jwtGenerator;
            this.roleManager = roleManager;
        }

        public async Task<User> Login(LoginQuery request)
        {
            var loginQueryValidation = new LoginQueryValidation(roleManager);
            var resultLoginQueryValidation = await loginQueryValidation.ValidateAsync(request);

            if (!resultLoginQueryValidation.IsValid)
                throw new RestException(HttpStatusCode.Unauthorized,
                    resultLoginQueryValidation.Errors.ToList().FirstOrDefault()?.ErrorMessage);

            var user = await userManager.FindByEmailAsync(request.Email);

            if (user is null)
                throw new RestException(HttpStatusCode.Unauthorized, $"{nameof(User)} is not exist");

            var passwordVerification = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);

            if (!passwordVerification.Succeeded)
                throw new RestException(HttpStatusCode.Unauthorized, $"{nameof(User)} is not pass verification of password");

            var roleVerification = await userManager.IsInRoleAsync(user, request.Role);

            if (roleVerification)
            {
                return new User
                {
                    Token = await jwtGenerator.CreateToken(user),
                    Email = request.Email,
                    Role = request.Role
                };
            }

            throw new RestException(HttpStatusCode.Unauthorized, $"{nameof(User)} is not pass verification of role");
        }
    }
}
