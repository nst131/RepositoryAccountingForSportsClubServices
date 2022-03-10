using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Application.User.Fetchers
{
    public class Fetchers : IFetchers
    {
        private readonly UserManager<AppUser> userManager;

        public Fetchers(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IList<string>> GetRoleByEmail(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            var roles = await userManager.GetRolesAsync(user);
            return roles;
        }
    }
}
