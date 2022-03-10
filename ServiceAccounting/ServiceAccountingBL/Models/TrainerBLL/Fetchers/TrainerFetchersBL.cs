using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingBL.Models.TrainerBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Fetchers
{
    public class TrainerFetchersBL : ITrainerFetchersBL
    {
        private readonly IServiceAccountingContext context;
        private readonly IMapper mapper;

        public TrainerFetchersBL(IServiceAccountingContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ICollection<ResponseGetTrainerDtoBL>> GetTrainerAll(CancellationToken token = default)
        {
            if (!await context.Set<Trainer>().AnyAsync(token)) 
                return new List<ResponseGetTrainerDtoBL>();

            var allTrainers = await context.Set<Trainer>()
                .Include(x => x.TypeSex)
                .Include(x => x.Service)
                .ToListAsync(token);

            return ReadTrainerMapperBL.Map<ICollection<ResponseGetTrainerDtoBL>>(allTrainers);
        }

        public async Task<ResponseGetServiceByTrainerIdDtoBL> GetServiceByTrainerId(int trainerId, CancellationToken token)
        {
            var trainer = await context.Set<Trainer>()
                .AsNoTracking()
                .Include(x => x.Service)
                .FirstOrDefaultAsync(x => x.Id == trainerId, token);

            if (trainer is null)
                throw new ElementNullReferenceException($"{nameof(Trainer)} don't exist");

            //trainer.Service can be null in database
            if (trainer.Service is null)
                throw new ElementNullReferenceException($"{nameof(Trainer)} don't have {nameof(Service)}");

            return this.mapper.Map<ResponseGetServiceByTrainerIdDtoBL>(trainer.Service);
        }
    }
}
