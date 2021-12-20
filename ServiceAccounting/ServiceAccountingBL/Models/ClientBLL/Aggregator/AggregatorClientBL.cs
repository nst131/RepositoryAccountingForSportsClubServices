using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Crud;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingBL.Models.ClientBLL.Fetchers;
using ServiceAccountingDA.Models;
using System;

namespace ServiceAccountingBL.Models.ClientBLL.Aggregator
{
    public class AggregatorClientBL : IAggregatorClientBL
    {
        private readonly Lazy<IClientCrudBL> clientCrudBL;
        private readonly Lazy<IClientFetchersBL> clientFetchersBL;
        private readonly Lazy<ICreater<AcceptCreateClientDtoBL, ResponseClientDtoBL>> createClient;
        private readonly Lazy<IUpdater<AcceptUpdateClientDtoBL, ResponseClientDtoBL>> updateClient;
        private readonly Lazy<IRemover<Client>> removeClient;

        public AggregatorClientBL(Lazy<IClientCrudBL> clientCrudBL,
            Lazy<IClientFetchersBL> clientFetchersBL,
            Lazy<ICreater<AcceptCreateClientDtoBL, ResponseClientDtoBL>> createClient,
            Lazy<IUpdater<AcceptUpdateClientDtoBL, ResponseClientDtoBL>> updateClient,
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
        public ICreater<AcceptCreateClientDtoBL, ResponseClientDtoBL> CreateClient => createClient.Value;
        public IUpdater<AcceptUpdateClientDtoBL, ResponseClientDtoBL> UpdateClient => updateClient.Value;
        public IRemover<Client> RemoveClient => removeClient.Value;
    }
}
