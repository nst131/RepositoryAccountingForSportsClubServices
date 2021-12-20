using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.BaseCrud;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Aggregator;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingBL.Models.ClientBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientBLL.Crud
{
    public class ClientCrudBL : IClientCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly ICreater<AcceptCreateClientDtoBL, ResponseClientDtoBL> createClient;
        private readonly IUpdater<AcceptUpdateClientDtoBL, ResponseClientDtoBL> updateClient;
        private readonly IRemover<Client> removeClient;

        public ClientCrudBL(IServiceAccountingContext context, IAggregatorClientBL aggregator)
        {
            this.context = context;
            this.createClient = aggregator.CreateClient;
            this.updateClient = aggregator.UpdateClient;
            this.removeClient = aggregator.RemoveClient;
        }

        public async Task<ResponseClientDtoBL> CreateClient(AcceptCreateClientDtoBL createClientDtoBL)
        {
            return await createClient.Create(createClientDtoBL);
        }

        public async Task<ResponseClientDtoBL> UpdateClient(AcceptUpdateClientDtoBL updateClientDtoBL)
        {
            return await updateClient.Update(updateClientDtoBL);
        }

        public async Task DeleteClient(int id)
        {
            await removeClient.Remove(id);
        }

        public async Task<ResponseGetClientDtoBL> GetClient(int id)
        {
            if (id < 0)
                throw new ElementOutOfRangeException($"Id {nameof(Client)} is less 0");

            var client = await context.Set<Client>()
                .Include(x => x.TypeSex)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(client is null)
                throw new ElementByIdNotFoundException($"{nameof(Client)} by Id not Found");

            return ReadClientMapperBL.Map<ResponseGetClientDtoBL>(client);
        }
    }
}
