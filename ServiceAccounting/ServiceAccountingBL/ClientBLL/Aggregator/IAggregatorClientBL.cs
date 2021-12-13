using ServiceAccountingBL.ClientBLL.Crud;
using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingBL.ClientBLL.Validation;

namespace ServiceAccountingBL.ClientBLL.Aggregator
{
    public interface IAggregatorClientBL
    {
        IClientCrudBL ClientCrudBL { get; }
        IClientValidator<CreateClientDtoBL> CreateClientValidator { get; }
        IClientValidator<UpdateClientDtoBL> UpdateClientValidator { get; }
    }
}