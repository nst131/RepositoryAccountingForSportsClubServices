using ServiceAccountingBL.ClientBLL.Crud;
using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingBL.ClientBLL.Validation;
using System;

namespace ServiceAccountingBL.ClientBLL.Aggregator
{
    public class AggregatorClientBL : IAggregatorClientBL
    {
        private readonly Lazy<IClientCrudBL> clientCrudBL;
        private readonly Lazy<IClientValidator<CreateClientDtoBL>> createClientValidator;
        private readonly Lazy<IClientValidator<UpdateClientDtoBL>> updateClientValidator;
        
        public AggregatorClientBL(Lazy<IClientCrudBL> clientCrudBL,
            Lazy<IClientValidator<CreateClientDtoBL>> createClientValidator,
            Lazy<IClientValidator<UpdateClientDtoBL>> updateClientValidator)
        {
            this.clientCrudBL = clientCrudBL;
            this.createClientValidator = createClientValidator;
            this.updateClientValidator = updateClientValidator;
        }

        public IClientCrudBL ClientCrudBL => clientCrudBL.Value;
        public IClientValidator<CreateClientDtoBL> CreateClientValidator => createClientValidator.Value;
        public IClientValidator<UpdateClientDtoBL> UpdateClientValidator => updateClientValidator.Value;
    }
}
