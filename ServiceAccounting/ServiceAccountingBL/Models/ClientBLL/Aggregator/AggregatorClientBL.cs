using System;
using ServiceAccountingBL.BaseCrud;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Crud;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingBL.Models.ClientBLL.Fetchers;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientBLL.Aggregator
{
    public class AggregatorClientBL : IAggregatorClientBL
    {
        private readonly Lazy<IClientCrudBL> clientCrudBL;
        private readonly Lazy<IClientFetchersBL> clientFetchersBL;
        private readonly Lazy<ICreater<CreateClientDtoBL, ClientDtoBL>> createClient;
        private readonly Lazy<IUpdater<UpdateClientDtoBL, ClientDtoBL>> updateClient;
        private readonly Lazy<IRemover<Client>> removeClient;
        
        public AggregatorClientBL(Lazy<IClientCrudBL> clientCrudBL,
            Lazy<IClientFetchersBL> clientFetchersBL,
            Lazy<ICreater<CreateClientDtoBL, ClientDtoBL>> createClient,
            Lazy<IUpdater<UpdateClientDtoBL, ClientDtoBL>> updateClient,
            Lazy<IRemover<Client>> removeClient)
        {
            this.clientCrudBL = clientCrudBL;
            this.clientFetchersBL = clientFetchersBL;
            this.createClient = createClient;
            this.updateClient = updateClient;
            this.removeClient = removeClient;
        }

        public IClientCrudBL ClientCrudBL => clientCrudBL.Value;
        public IClientFetchersBL ClientFetchersBL => clientFetchersBL.Value;
        public ICreater<CreateClientDtoBL, ClientDtoBL> CreateClient => createClient.Value;  
        public IUpdater<UpdateClientDtoBL, ClientDtoBL> UpdateClient => updateClient.Value;  
        public IRemover<Client> RemoveClient => removeClient.Value;  
    }
}
