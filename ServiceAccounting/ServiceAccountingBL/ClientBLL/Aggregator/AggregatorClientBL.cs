using ServiceAccountingBL.ClientBLL.Crud;
using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingBL.ClientBLL.Validation;

namespace ServiceAccountingBL.ClientBLL.Aggregator
{
    public class AggregatorClientBL : IAggregatorClientBL
    {
        private readonly IClientCrudBL clientCrudBL;
        private readonly IClientValidator<CreateClientDtoBL> createClientValidator;
        
        public AggregatorClientBL(IClientCrudBL clientCrudBL,
            IClientValidator<CreateClientDtoBL> createClientValidator)
        {
            this.clientCrudBL = clientCrudBL;
            this.createClientValidator = createClientValidator;
        }

        public IClientCrudBL ClientCrudBL => clientCrudBL;
        public IClientValidator<CreateClientDtoBL> CreateClientValidator => createClientValidator;
    }
}
