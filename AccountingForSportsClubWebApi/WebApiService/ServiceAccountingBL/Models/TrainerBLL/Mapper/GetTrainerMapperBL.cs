using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.TrainerBLL.Mapper
{
    public class GetTrainerMapperBL : IMapperAsync<int, ResponseGetTrainerDtoBL>
    {
        private readonly IServiceAccountingContext context;

        public GetTrainerMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ResponseGetTrainerDtoBL> Map(int id)
        {
            var dto = await context.Set<Trainer>()
                .Include(x => x.TypeSex)
                .Include(x => x.Service)
                .FirstOrDefaultAsync(x => x.Id == id);

            return new ResponseGetTrainerDtoBL()
            {
                Id = dto.Id,
                Name = dto.Name,
                SerName = dto.SerName,
                Telephone = dto.Telephone,
                TypeSex = dto.TypeSex.Name,
                ServiceId = dto.ServiceId ?? 0,
                Service = dto.Service?.Name ?? "Not Assigned",
                Email = dto.Email
            };
        }
    }
}
