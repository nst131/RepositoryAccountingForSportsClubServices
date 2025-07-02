using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.TrainingBLL.Crud
{
    public interface ITrainingAditionalOperation
    {
        Task AddClientsInTraining(ICollection<int> clientsId, int trainingId);
        Task UpdateClientsInTraining(ICollection<int> clientsId, int trainingId, CancellationToken token = default);
    }
}