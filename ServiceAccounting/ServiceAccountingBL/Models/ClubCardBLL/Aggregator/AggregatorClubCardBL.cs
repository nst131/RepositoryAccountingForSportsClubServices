using System;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClubCardBLL.Crud;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingBL.Models.ClubCardBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClubCardBLL.Aggregator
{
    public class AggregatorClubCardBL : IAggregatorClubCardBL
    {
        private readonly Lazy<IClubCardCrudBL> clubCardCrudBL;
        private readonly Lazy<IClubCardFetchersBL> clubCardFetchersBL;
        private readonly Lazy<ICreater<AcceptCreateClubCardDtoBL, ResponseClubCardDtoBL>> createClubCard;
        private readonly Lazy<IUpdater<AcceptUpdateClubCardDtoBL, ResponseClubCardDtoBL>> updateClubCard;
        private readonly Lazy<IRemover<ClubCard>> removeClubCard;
        private readonly Lazy<IGetter<ResponseGetClubCardDtoBL>> getClubCard;

        public AggregatorClubCardBL(Lazy<IClubCardCrudBL> ClubCardCrudBL,
            Lazy<IClubCardFetchersBL> ClubCardFetchersBL,
            Lazy<ICreater<AcceptCreateClubCardDtoBL, ResponseClubCardDtoBL>> createClubCard,
            Lazy<IUpdater<AcceptUpdateClubCardDtoBL, ResponseClubCardDtoBL>> updateClubCard,
            Lazy<IRemover<ClubCard>> removeClubCard,
            Lazy<IGetter<ResponseGetClubCardDtoBL>> getClubCard)
        {
            this.clubCardCrudBL = ClubCardCrudBL;
            this.clubCardFetchersBL = ClubCardFetchersBL;
            this.createClubCard = createClubCard;
            this.updateClubCard = updateClubCard;
            this.removeClubCard = removeClubCard;
            this.getClubCard = getClubCard;
        }

        public IClubCardCrudBL ClubCardCrudBL => clubCardCrudBL.Value;
        public IClubCardFetchersBL ClubCardFetchersBL => clubCardFetchersBL.Value;
        public ICreater<AcceptCreateClubCardDtoBL, ResponseClubCardDtoBL> CreateClubCard => createClubCard.Value;
        public IUpdater<AcceptUpdateClubCardDtoBL, ResponseClubCardDtoBL> UpdateClubCard => updateClubCard.Value;
        public IRemover<ClubCard> RemoveClubCard => removeClubCard.Value;
        public IGetter<ResponseGetClubCardDtoBL> GetClubCard => getClubCard.Value;
    }
}
