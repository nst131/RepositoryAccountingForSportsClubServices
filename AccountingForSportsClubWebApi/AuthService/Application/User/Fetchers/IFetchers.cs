using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.User.Fetchers
{
    internal interface IFetchers
    {
        Task<IList<string>> GetRoleByEmail(string email);
    }
}