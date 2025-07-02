using System.Threading;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClubCardBLL.Aggregator;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingDA.Models;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.ClubCardBLL.Crud
{
    public class ClubCardCrudBL : IClubCardCrudBL
    {
        private readonly ICreater<AcceptCreateClubCardDtoBL, ResponseClubCardDtoBL> createClubCard;
        private readonly IUpdater<AcceptUpdateClubCardDtoBL, ResponseClubCardDtoBL> updateClubCard;
        private readonly IRemover<ClubCard> removeClubCard;
        private readonly IGetter<ResponseGetClubCardDtoBL> getClubCard;

        public ClubCardCrudBL(IAggregatorClubCardBL aggregator)
        {
            this.createClubCard = aggregator.CreateClubCard;
            this.updateClubCard = aggregator.UpdateClubCard;
            this.removeClubCard = aggregator.RemoveClubCard;
            this.getClubCard = aggregator.GetClubCard;
        }

        public async Task<ResponseClubCardDtoBL> CreateClubCard(AcceptCreateClubCardDtoBL createClubCardDtoBL, CancellationToken token = default)
            => await createClubCard.Create(createClubCardDtoBL, token);

        public async Task<ResponseClubCardDtoBL> UpdateClubCard(AcceptUpdateClubCardDtoBL updateClubCardDtoBL, CancellationToken token = default)
            => await updateClubCard.Update(updateClubCardDtoBL, token);

        public async Task DeleteClubCard(int id, CancellationToken token = default)
            => await removeClubCard.Remove(id, token);

        public async Task<ResponseGetClubCardDtoBL> GetClubCard(int id, CancellationToken token = default)
            => await getClubCard.Get(id, token);
    }
}
