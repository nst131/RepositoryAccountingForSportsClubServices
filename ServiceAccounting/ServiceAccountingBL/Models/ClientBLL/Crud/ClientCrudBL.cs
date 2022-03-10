using System.Threading;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Aggregator;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingDA.Models;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.ClientBLL.Crud
{
    public class ClientCrudBL : IClientCrudBL
    {
        private readonly ICreater<AcceptCreateClientDtoBL, ResponseClientDtoBL> createClient;
        private readonly IUpdater<AcceptUpdateClientDtoBL, ResponseClientDtoBL> updateClient;
        private readonly IRemover<Client> removeClient;
        private readonly IGetter<ResponseGetClientDtoBL> getClient;

        public ClientCrudBL(IAggregatorClientBL aggregator)
        {
            this.createClient = aggregator.CreateClient;
            this.updateClient = aggregator.UpdateClient;
            this.removeClient = aggregator.RemoveClient;
            this.getClient = aggregator.GetClient;
        }

        public async Task<ResponseClientDtoBL> CreateClient(AcceptCreateClientDtoBL createClientDtoBL, CancellationToken token = default)
            => await createClient.Create(createClientDtoBL, token);

        public async Task<ResponseClientDtoBL> UpdateClient(AcceptUpdateClientDtoBL updateClientDtoBL, CancellationToken token = default)
            => await updateClient.Update(updateClientDtoBL, token);

        public async Task DeleteClient(int id, CancellationToken token = default)
            => await removeClient.Remove(id, token);

        public async Task<ResponseGetClientDtoBL> GetClient(int id, CancellationToken token = default)
            => await getClient.Get(id, token);
    }
}
