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
        private readonly Lazy<ICreater<CreateClubCardDtoBL, ClubCardDtoBL>> createClubCard;
        private readonly Lazy<IUpdater<UpdateClubCardDtoBL, ClubCardDtoBL>> updateClubCard;
        private readonly Lazy<IRemover<ClubCard>> removeClubCard;

        public AggregatorClubCardBL(Lazy<IClubCardCrudBL> ClubCardCrudBL,
            Lazy<IClubCardFetchersBL> ClubCardFetchersBL,
            Lazy<ICreater<CreateClubCardDtoBL, ClubCardDtoBL>> createClubCard,
            Lazy<IUpdater<UpdateClubCardDtoBL, ClubCardDtoBL>> updateClubCard,
            Lazy<IRemover<ClubCard>> removeClubCard)
        {
            this.clubCardCrudBL = ClubCardCrudBL;
            this.clubCardFetchersBL = ClubCardFetchersBL;
            this.createClubCard = createClubCard;
            this.updateClubCard = updateClubCard;
            this.removeClubCard = removeClubCard;
        }

        public IClubCardCrudBL ClubCardCrudBL => clubCardCrudBL.Value;
        public IClubCardFetchersBL ClubCardFetchersBL => clubCardFetchersBL.Value;
        public ICreater<CreateClubCardDtoBL, ClubCardDtoBL> CreateClubCard => createClubCard.Value;
        public IUpdater<UpdateClubCardDtoBL, ClubCardDtoBL> UpdateClubCard => updateClubCard.Value;
        public IRemover<ClubCard> RemoveClubCard => removeClubCard.Value;
    }
}
