using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingBL.Models.TrainingBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainingBLL.Fetchers
{
    public class TrainingFetchersBL : ITrainingFetchersBL
    {
        private readonly IServiceAccountingContext context;

        public TrainingFetchersBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ResponseGetTrainingDtoBL>> GetTrainingAll(CancellationToken token = default)
        {
            if (!await context.Set<Training>().AnyAsync(token))
                return new List<ResponseGetTrainingDtoBL>();

            var allClients = await context.Set<Training>()
                .Include(x => x.Trainer)
                .Include(x => x.Service)
                .ToListAsync(token);

            return ReadTrainingMapperBL.Map<ICollection<ResponseGetTrainingDtoBL>>(allClients);
        }

        public async Task<int> GetTrainerIdByTrainingId(int trainingId, CancellationToken token)
        {
            var responsibleId = await context.Set<Training>()
                .AsNoTracking()
                .Where(x => x.Id == trainingId)
                .Select(x => x.TrainerId)
                .FirstOrDefaultAsync(token);

            return responsibleId;
        }
    }
}
