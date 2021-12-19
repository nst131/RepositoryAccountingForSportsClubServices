using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClubCardBLL.Aggregator;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingBL.Models.ClubCardBLL.Mapper;

namespace ServiceAccountingBL.Models.ClubCardBLL.Crud
{
    public class ClubCardCrudBL : IClubCardCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly ICreater<CreateClubCardDtoBL, ClubCardDtoBL> createClubCard;
        private readonly IUpdater<UpdateClubCardDtoBL, ClubCardDtoBL> updateClubCard;
        private readonly IRemover<ClubCard> removeClubCard;

        public ClubCardCrudBL(IServiceAccountingContext context, IAggregatorClubCardBL aggregator)
        {
            this.context = context;
            this.createClubCard = aggregator.CreateClubCard;
            this.updateClubCard = aggregator.UpdateClubCard;
            this.removeClubCard = aggregator.RemoveClubCard;
        }

        public async Task<ClubCardDtoBL> CreateClubCard(CreateClubCardDtoBL createClubCardDtoBL)
        {
            return await createClubCard.Create(createClubCardDtoBL);
        }

        public async Task<ClubCardDtoBL> UpdateClubCard(UpdateClubCardDtoBL updateClubCardDtoBL)
        {
            return await updateClubCard.Update(updateClubCardDtoBL);
        }

        public async Task DeleteClubCard(int id)
        {
            await removeClubCard.Remove(id);
        }

        public async Task<GetClubCardDtoBL> GetClubCard(int id)
        {
            if (id < 0)
                throw new ElementOutOfRangeException($"Id {nameof(ClubCard)} is less 0");

            var clubCard = await context.Set<ClubCard>()
                    .Include(x => x.Service)
                    .FirstOrDefaultAsync(x => x.Id == id);

            if (clubCard is null)
                throw new ElementByIdNotFoundException($"{nameof(ClubCard)} by Id not Found");

            return ReadClubCardMapperBL.Map<GetClubCardDtoBL>(clubCard);
        }
    }
}
