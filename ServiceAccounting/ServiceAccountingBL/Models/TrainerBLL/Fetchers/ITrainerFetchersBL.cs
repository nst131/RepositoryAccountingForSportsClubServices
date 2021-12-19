using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.TrainerBLL.Dto;

namespace ServiceAccountingBL.Models.TrainerBLL.Fetchers
{
    public interface ITrainerFetchersBL
    {
        Task<ICollection<GetTrainerDtoBL>> GetTrainerAll();
    }
}