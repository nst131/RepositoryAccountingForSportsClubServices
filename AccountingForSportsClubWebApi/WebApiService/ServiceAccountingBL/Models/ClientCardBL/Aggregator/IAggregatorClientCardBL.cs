using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientCardBL.Crud;
using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingBL.Models.ClientCardBL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientCardBL.Aggregator
{
    public interface IAggregatorClientCardBL
    {
        IClientCardCrudBL ClientCardCrudBL { get; }
        IClientCardFetchersBL ClientCardFetchersBL { get; }
        IRemover<ClientCard> RemoveClientCard { get; }
        IValidator<AcceptCreateClientCardDtoBL> CreateValidator { get; }
        IValidator<AcceptUpdateClientCardDtoBL> UpdateValidator { get; }
        IGetter<ResponseGetClientCardDtoBL> GetClientCard { get; }
    }
}