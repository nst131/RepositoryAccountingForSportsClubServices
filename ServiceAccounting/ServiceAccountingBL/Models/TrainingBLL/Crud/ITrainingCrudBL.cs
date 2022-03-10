using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.TrainingBLL.Dto;

namespace ServiceAccountingBL.Models.TrainingBLL.Crud
{
    public interface ITrainingCrudBL
    {
        Task<ResponseTrainingDtoBL> CreateTrainingByClubCard(AcceptCreateTrainingDtoBL createTrainingDtoBL, CancellationToken token = default);
        Task<ResponseTrainingDtoBL> UpdateTrainingByClubCard(AcceptUpdateTrainingDtoBL updateTrainingDtoBL, CancellationToken token = default);
        Task DeleteTraining(int id, CancellationToken token = default);
        Task<ResponseGetTrainingDtoBL> GetTraining(int id, CancellationToken token = default);
    }
}