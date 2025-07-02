using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.BaseModels;

namespace ServiceAccountingBL.Models.TrainingBLL.Validation
{
    public interface ICheckClientCardNecessaryServiceValidation
    {
        Task<ICollection<ClientsHasExpiredDto>> GetClientsHasExpired(ICollection<int> clientsId, int necessaryServicId, CancellationToken token);
    }
}