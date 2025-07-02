using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.TrainerBLL.Dto;

namespace ServiceAccountingBL.Models.TrainerBLL.Fetchers
{
    public interface ITrainerFetchersBL
    {
        Task<ICollection<ResponseGetTrainerDtoBL>> GetTrainerAll(CancellationToken token = default);
        Task<ResponseGetServiceByTrainerIdDtoBL> GetServiceByTrainerId(int trainerId, CancellationToken token);
    }
}