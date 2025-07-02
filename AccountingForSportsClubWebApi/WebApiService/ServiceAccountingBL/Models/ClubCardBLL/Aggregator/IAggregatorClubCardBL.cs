using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClubCardBLL.Crud;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingBL.Models.ClubCardBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClubCardBLL.Aggregator
{
    public interface IAggregatorClubCardBL
    {
        IClubCardCrudBL ClubCardCrudBL { get; }
        IClubCardFetchersBL ClubCardFetchersBL { get; }
        ICreater<AcceptCreateClubCardDtoBL, ResponseClubCardDtoBL> CreateClubCard { get; }
        IUpdater<AcceptUpdateClubCardDtoBL, ResponseClubCardDtoBL> UpdateClubCard { get; }
        IRemover<ClubCard> RemoveClubCard { get; }
        IGetter<ResponseGetClubCardDtoBL> GetClubCard { get; }
    }
}