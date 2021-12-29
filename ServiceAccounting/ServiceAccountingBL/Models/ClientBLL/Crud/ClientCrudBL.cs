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

        public async Task<ResponseClientDtoBL> CreateClient(AcceptCreateClientDtoBL createClientDtoBL)
            => await createClient.Create(createClientDtoBL);

        public async Task<ResponseClientDtoBL> UpdateClient(AcceptUpdateClientDtoBL updateClientDtoBL)
            => await updateClient.Update(updateClientDtoBL);

        public async Task DeleteClient(int id)
            => await removeClient.Remove(id);

        public async Task<ResponseGetClientDtoBL> GetClient(int id)
            => await getClient.Get(id);
    }
}
