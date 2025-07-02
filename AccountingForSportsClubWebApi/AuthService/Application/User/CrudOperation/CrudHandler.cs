using System.Net;
using System.Threading.Tasks;
using Application.Exceptions;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Application.User.CrudOperation
{
    public class CrudHandler : ICrudHandler
    {
        private readonly UserManager<AppUser> userManager;

        public CrudHandler(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<bool> DeleteUser(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new RestException(HttpStatusCode.Conflict, $"Accepted parameter {nameof(email)} is null");

            var user = await userManager.FindByEmailAsync(email);

            if (user is null)
                throw new RestException(HttpStatusCode.Conflict, $"{nameof(AppUser)} is not found in database");

            var result = await userManager.DeleteAsync(user);

            if (!result.Succeeded)
                throw new RestException(HttpStatusCode.Conflict, $"Can not delete {nameof(AppUser)}");
            
            return true;
        }
    }
}
