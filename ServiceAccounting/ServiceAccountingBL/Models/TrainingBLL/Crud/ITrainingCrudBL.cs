using System.Threading.Tasks;
using ServiceAccountingBL.Models.TrainingBLL.Dto;

namespace ServiceAccountingBL.Models.TrainingBLL.Crud
{
    public interface ITrainingCrudBL
    {
        Task<ResponseTrainingDtoBL> CreateTraining(AcceptCreateTrainingDtoBL createTrainingDtoBL);
        Task<ResponseTrainingDtoBL> UpdateTraining(AcceptUpdateTrainingDtoBL updateTrainingDtoBL);
        Task DeleteTraining(int id);
        Task<ResponseGetTrainingDtoBL> GetTraining(int id);
    }
}