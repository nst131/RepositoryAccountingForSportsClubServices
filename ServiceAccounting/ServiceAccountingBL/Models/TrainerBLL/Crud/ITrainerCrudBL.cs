using System.Threading.Tasks;
using ServiceAccountingBL.Models.TrainerBLL.Dto;

namespace ServiceAccountingBL.Models.TrainerBLL.Crud
{
    public interface ITrainerCrudBL
    {
        Task<TrainerDtoBL> CreateTrainer(CreateTrainerDtoBL createTrainerDtoBL);
        Task DeleteTrainer(int id);
        Task<GetTrainerDtoBL> GetTrainer(int id);
        Task<TrainerDtoBL> UpdateTrainer(UpdateTrainerDtoBL updateTrainerDtoBL);
    }
}