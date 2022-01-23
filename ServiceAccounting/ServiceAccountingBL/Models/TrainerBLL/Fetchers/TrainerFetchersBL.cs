using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingBL.Models.TrainerBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Fetchers
{
    public class TrainerFetchersBL : ITrainerFetchersBL
    {
        private readonly IServiceAccountingContext context;

        public TrainerFetchersBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<ResponseGetTrainerDtoBL>> GetTrainerAll()
        {
            if (!await context.Set<Trainer>().AnyAsync()) 
                return new List<ResponseGetTrainerDtoBL>();

            var allTrainers = await context.Set<Trainer>()
                .Include(x => x.TypeSex)
                .Include(x => x.Service)
                .ToListAsync();

            return ReadTrainerMapperBL.Map<ICollection<ResponseGetTrainerDtoBL>>(allTrainers);

        }
    }
}
