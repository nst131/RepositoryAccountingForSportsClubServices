using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientCardBL.Aggregator;
using ServiceAccountingBL.Models.ClientCardBL.Crud;
using ServiceAccountingBL.Models.ClientCardBL.Fetchers;
using ServiceAccountingDA.Models;
using System;
using ServiceAccountingBL.Models.ClientCardBL.Dto;

namespace ServiceAccountingBL.Models.ClientCardCardBL.Aggregator
{
    public class AggregatorClientCardBL : IAggregatorClientCardBL
    {
        private readonly Lazy<IClientCardCrudBL> clientCardCrudBL;
        private readonly Lazy<IClientCardFetchersBL> clientCardFetchersBL;
        private readonly Lazy<IRemover<ClientCard>> removeClientCard;

        private readonly Lazy<IValidator<AcceptCreateClientCardDtoBL>> createValidator;
        private readonly Lazy<IValidator<AcceptUpdateClientCardDtoBL>> updateValidator;

        public AggregatorClientCardBL(Lazy<IClientCardCrudBL> clientCardCrudBL,
            Lazy<IClientCardFetchersBL> clientCardFetchersBL,
            Lazy<IRemover<ClientCard>> removeClientCard,
            Lazy<IValidator<AcceptCreateClientCardDtoBL>> createValidator,
            Lazy<IValidator<AcceptUpdateClientCardDtoBL>> updateValidator)
        {
            this.clientCardCrudBL = clientCardCrudBL;
            this.clientCardFetchersBL = clientCardFetchersBL;
            this.removeClientCard = removeClientCard;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
        }

        public IClientCardCrudBL ClientCardCrudBL => clientCardCrudBL.Value;
        public IClientCardFetchersBL ClientCardFetchersBL => clientCardFetchersBL.Value;
        public IRemover<ClientCard> RemoveClientCard => removeClientCard.Value;

        public IValidator<AcceptCreateClientCardDtoBL> CreateValidator => createValidator.Value;
        public IValidator<AcceptUpdateClientCardDtoBL> UpdateValidator => updateValidator.Value;
    }
}

