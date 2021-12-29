using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.TrainingBLL.Dto;

namespace ServiceAccountingBL.Models.TrainingBLL.Fetchers
{
    public interface ITrainingFetchersBL
    {
        Task<ICollection<ResponseGetTrainingDtoBL>> GetTrainingAll();
    }
}