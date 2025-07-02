using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Interfaces
{
    public interface IRemover<Entity> 
        where Entity : class
    {
        Task<int> Remove(int id, CancellationToken token = default);
    }
}