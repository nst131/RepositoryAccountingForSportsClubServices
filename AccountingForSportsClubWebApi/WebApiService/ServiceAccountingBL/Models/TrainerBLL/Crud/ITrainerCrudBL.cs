using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.TrainerBLL.Dto;

namespace ServiceAccountingBL.Models.TrainerBLL.Crud
{
    public interface ITrainerCrudBL
    {
        Task<ResponseTrainerDtoBL> CreateTrainer(AcceptCreateTrainerDtoBL createTrainerDtoBL, CancellationToken token = default);
        Task DeleteTrainer(int id, CancellationToken token = default);
        Task<ResponseGetTrainerDtoBL> GetTrainer(int id, CancellationToken token = default);
        Task<ResponseTrainerDtoBL> UpdateTrainer(AcceptUpdateTrainerDtoBL updateTrainerDtoBL, CancellationToken token = default);
    }
}