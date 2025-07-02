using System.Linq;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Mapper
{
    public class UpdateTrainerMapperBL : IMapper<AcceptUpdateTrainerDtoBL, Trainer>
    {
        private readonly IServiceAccountingContext context;

        public UpdateTrainerMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public Trainer Map(AcceptUpdateTrainerDtoBL updateTrainerDtoBL)
        {
            var email = context.Set<Trainer>()
                .AsNoTracking()
                .Where(x => x.Id == updateTrainerDtoBL.Id)
                .Select(x => x.Email).FirstOrDefaultAsync().Result;

            return new ()
            {
                Id = updateTrainerDtoBL.Id,
                Name = updateTrainerDtoBL.Name,
                SerName = updateTrainerDtoBL.SerName,
                Telephone = updateTrainerDtoBL.Telephone,
                TypeSexId = updateTrainerDtoBL.TypeSexId,
                ServiceId = updateTrainerDtoBL.ServiceId,
                Email = email
            };
        }
    }
}
