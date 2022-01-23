using System.Threading.Tasks;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Mapper
{
    public class ResponseTrainerMapperBL : IMapperAsync<Trainer, ResponseTrainerDtoBL>
    {
        public async Task<ResponseTrainerDtoBL> Map(Trainer trainer)
        {
            return await Task.FromResult(new ResponseTrainerDtoBL()
            {
                Id = trainer.Id,
                Name = trainer.Name
            });
        }
    }
}
