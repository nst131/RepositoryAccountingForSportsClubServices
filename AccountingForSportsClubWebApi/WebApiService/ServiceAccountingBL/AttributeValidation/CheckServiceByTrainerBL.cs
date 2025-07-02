using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.AttributeValidation
{
    public class CheckServiceByTrainerBL : ICheckServiceByTrainerBL
    {
        private readonly IServiceAccountingContext context;

        public CheckServiceByTrainerBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsSameService(int serviceId, int trainerId)
        {
            var trainer = await context.Set<Trainer>().FirstOrDefaultAsync(x => x.Id == trainerId);

            return trainer.ServiceId == serviceId;
        }
    }
}
