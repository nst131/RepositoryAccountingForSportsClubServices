using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.ClubCardBLL.Aggregator;
using ServiceAccountingBL.ClubCardBLL.Dto;
using ServiceAccountingBL.ClubCardBLL.Mapper;
using ServiceAccountingBL.ClubCardBLL.Validation;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceAccountingBL.ClubCardBLL.Crud
{
    public class ClubCardCrudBL : IClubCardCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly IClubCardValidator<CreateClubCardDtoBL> validatorCreate;
        private readonly IClubCardValidator<UpdateClubCardDtoBL> validatorUpdate;

        public ClubCardCrudBL(IServiceAccountingContext context, IAggregatorClubCardBL aggregator)
        {
            this.context = context;
            validatorCreate = aggregator.CreateClubCardValidator;
            validatorUpdate = aggregator.UpdateClubCardValidator;
        }

        public async Task<ClubCardDtoBL> CreateClubCard(CreateClubCardDtoBL createClubCardDtoBL)
        {
            await validatorCreate.Validate(createClubCardDtoBL);
            var clubCard = CreateClubCardMapperBL.Map<ClubCard>(createClubCardDtoBL);
            var addedClubCard = await context.Set<ClubCard>().AddAsync(clubCard);
            await context.SaveChangesAsync();

            return ClubCardMapperBL.Map<ClubCardDtoBL>(addedClubCard.Entity);
        }

        public async Task<ClubCardDtoBL> UpdateClubCard(UpdateClubCardDtoBL updateClubCardDtoBL)
        {
            await validatorUpdate.Validate(updateClubCardDtoBL);
            var clubCard = UpdateClubCardMapperBL.Map<ClubCard>(updateClubCardDtoBL);
            var updatedClubCard = await Task.Factory.StartNew(() => context.Set<ClubCard>().Update(clubCard));
            await context.SaveChangesAsync();

            return ClubCardMapperBL.Map<ClubCardDtoBL>(updatedClubCard.Entity);
        }

        public async Task DeleteClubCard(int id)
        {
            try
            {
                var clubCard = await context.Set<ClubCard>().FirstOrDefaultAsync(x => x.Id == id);
                await Task.Factory.StartNew(() => context.Set<ClubCard>().Remove(clubCard));
                await context.SaveChangesAsync();
            }
            catch
            {
                throw new ElementByIdNotFoundException($"{nameof(ClubCard)} by Id not Found");
            }
        }

        public async Task<GetClubCardDtoBL> GetClubCard(int id)
        {
            try
            {
                var clubCard = await context.Set<ClubCard>()
                    .Include(x => x.Service)
                    .FirstOrDefaultAsync(x => x.Id == id);
                return GetClubCardMapperBL.Map<GetClubCardDtoBL>(clubCard);
            }
            catch
            {
                throw new ElementByIdNotFoundException($"{nameof(ClubCard)} by Id not Found");
            }
        }

        public async Task<ICollection<GetClubCardDtoBL>> GetClubCardAll()
        {
            if (await context.Set<ClubCard>().AnyAsync())
            {
                var allClubCards = await context.Set<ClubCard>()
                    .Include(x => x.Service)
                    .ToListAsync();

                return GetClubCardMapperBL.Map<ICollection<GetClubCardDtoBL>>(allClubCards);
            }

            return new List<GetClubCardDtoBL>();
        }
    }
}
