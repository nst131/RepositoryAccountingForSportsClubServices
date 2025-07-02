using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingDA.Interfaces;

namespace ServiceAccountingBL.Models.CommonBL
{
    public interface ICommonFetchers
    {
        Task<int?> GetIdByEmail<TEntity>(string email, CancellationToken token = default)
            where TEntity: class, IEmail;

        Task<string> GetEmailById<TEntity>(int id, CancellationToken token = default)
            where TEntity : class, IEmail;
    }
}