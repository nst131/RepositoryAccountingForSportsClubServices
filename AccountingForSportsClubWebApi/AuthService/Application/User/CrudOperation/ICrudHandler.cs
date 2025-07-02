using System.Threading.Tasks;

namespace Application.User.CrudOperation
{
    public interface ICrudHandler
    {
        Task<bool> DeleteUser(string email);
    }
}