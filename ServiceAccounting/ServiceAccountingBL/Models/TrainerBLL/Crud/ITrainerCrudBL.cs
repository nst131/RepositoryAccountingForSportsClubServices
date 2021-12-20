using System.Threading.Tasks;
using ServiceAccountingBL.Models.TrainerBLL.Dto;

namespace ServiceAccountingBL.Models.TrainerBLL.Crud
{
    public interface ITrainerCrudBL
    {
        Task<ResponseTrainerDtoBL> CreateTrainer(AcceptCreateTrainerDtoBL createTrainerDtoBL);
        Task DeleteTrainer(int id);
        Task<ResponseGetTrainerDtoBL> GetTrainer(int id);
        Task<ResponseTrainerDtoBL> UpdateTrainer(AcceptUpdateTrainerDtoBL updateTrainerDtoBL);
    }
}