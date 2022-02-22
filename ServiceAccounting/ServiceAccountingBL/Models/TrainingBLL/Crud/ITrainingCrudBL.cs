using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.TrainingBLL.Dto;

namespace ServiceAccountingBL.Models.TrainingBLL.Crud
{
    public interface ITrainingCrudBL
    {
        Task<ResponseTrainingDtoBL> CreateTraining(AcceptCreateTrainingDtoBL createTrainingDtoBL, CancellationToken token = default);
        Task<ResponseTrainingDtoBL> UpdateTraining(AcceptUpdateTrainingDtoBL updateTrainingDtoBL, CancellationToken token = default);
        Task DeleteTraining(int id, CancellationToken token = default);
        Task<ResponseGetTrainingDtoBL> GetTraining(int id, CancellationToken token = default);
    }
}