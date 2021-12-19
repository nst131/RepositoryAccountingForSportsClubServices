using ServiceAccountingBL.BaseCrud;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Crud;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingBL.Models.ClientBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientBLL.Aggregator
{
    public interface IAggregatorClientBL
    {
        IClientCrudBL ClientCrudBL { get; }
        IClientFetchersBL ClientFetchersBL { get; }
        ICreater<CreateClientDtoBL, ClientDtoBL> CreateClient { get; }
        IUpdater<UpdateClientDtoBL, ClientDtoBL> UpdateClient { get; }
        IRemover<Client> RemoveClient { get; }
    }
}