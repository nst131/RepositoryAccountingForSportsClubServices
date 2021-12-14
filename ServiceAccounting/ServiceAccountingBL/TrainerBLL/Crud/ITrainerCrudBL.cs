using ServiceAccountingBL.TrainerBLL.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceAccountingBL.TrainerBLL.Crud
{
    public interface ITrainerCrudBL
    {
        Task<TrainerDtoBL> CreateTrainer(CreateTrainerDtoBL createTrainerDtoBL);
        Task DeleteTrainer(int id);
        Task<GetTrainerDtoBL> GetTrainer(int id);
        Task<ICollection<GetTrainerDtoBL>> GetTrainerAll();
        Task<TrainerDtoBL> UpdateTrainer(UpdateTrainerDtoBL updateTrainerDtoBL);
    }
}