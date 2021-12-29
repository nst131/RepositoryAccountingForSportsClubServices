using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainingBLL.Mapper
{
    public class GetTrainingMapperBL : IMapperAsync<int, ResponseGetTrainingDtoBL>
    {
        private readonly IServiceAccountingContext context;

        public GetTrainingMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ResponseGetTrainingDtoBL> Map(int id)
        {
            var dto = await context.Set<Training>()
                .Include(x => x.Trainer)
                .Include(x => x.Service)
                .FirstOrDefaultAsync(x => x.Id == id);

            return new ResponseGetTrainingDtoBL()
            {
                Id = dto.Id,
                Name = dto.Name,
                StartTraining = dto.StartTraining,
                FinishTraining = dto.FinishTraining,
                TrainerName = dto.Trainer.Name, // Load Trainer
                ServiceName = dto.Service.Name // Load Service
            };
        }
    }
}
