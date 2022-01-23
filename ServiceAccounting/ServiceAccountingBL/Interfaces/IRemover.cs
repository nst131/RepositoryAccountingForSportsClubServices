using System.Threading.Tasks;

namespace ServiceAccountingBL.Interfaces
{
    public interface IRemover<Entity> 
        where Entity : class
    {
        Task Remove(int id);
    }
}