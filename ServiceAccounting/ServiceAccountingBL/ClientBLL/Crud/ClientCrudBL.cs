using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.ClientBLL.Aggregator;
using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingBL.ClientBLL.Mapper;
using ServiceAccountingBL.ClientBLL.Validation;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceAccountingBL.ClientBLL.Crud
{
    public class ClientCrudBL : IClientCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly IClientValidator<CreateClientDtoBL> validatorCreate;
        private readonly IClientValidator<UpdateClientDtoBL> validatorUpdate;

        public ClientCrudBL(IServiceAccountingContext context, IAggregatorClientBL aggregator)
        {
            this.context = context;
            validatorCreate = aggregator.CreateClientValidator;
            validatorUpdate = aggregator.UpdateClientValidator;
        }

        public async Task<ClientDtoBL> CreateClient(CreateClientDtoBL createClientDtoBL)
        {
            await validatorCreate.Validate(createClientDtoBL);
            var client = CreateClientMapperBL.Map<Client>(createClientDtoBL);
            var addedClient = await context.Set<Client>().AddAsync(client);
            await context.SaveChangesAsync();

            return ClientMapperBL.Map<ClientDtoBL>(addedClient.Entity);
        }

        public async Task<ClientDtoBL> UpdateClient(UpdateClientDtoBL updateClientDtoBL)
        {
            await validatorUpdate.Validate(updateClientDtoBL);
            var client = UpdateClientMapperBL.Map<Client>(updateClientDtoBL);
            var updatedClient = await Task.Factory.StartNew(() => context.Set<Client>().Update(client));
            await context.SaveChangesAsync();

            return ClientMapperBL.Map<ClientDtoBL>(updatedClient.Entity);
        }

        public async Task DeleteClient(int id)
        {
            try
            {
                var client = await context.Set<Client>().FirstOrDefaultAsync(x => x.Id == id);
                await Task.Factory.StartNew(() => context.Set<Client>().Remove(client));
                await context.SaveChangesAsync();
            }
            catch
            {
                throw new ElementByIdNotFoundException($"{nameof(Client)} by Id not Found");
            }
        }

        public async Task<GetClientDtoBL> GetClient(int id)
        {
            try
            {
                var client = await context.Set<Client>()
                    .Include(x => x.TypeSex)
                    .FirstOrDefaultAsync(x => x.Id == id);
                return GetClientMapperBL.Map<GetClientDtoBL>(client);
            }
            catch
            {
                throw new ElementByIdNotFoundException($"{nameof(Client)} by Id not Found");
            }
        }

        public async Task<ICollection<GetClientDtoBL>> GetClientAll()
        {
            if(await context.Set<Client>().AnyAsync())
            {
                var allClients = await context.Set<Client>()
                    .Include(x => x.TypeSex)
                    .ToListAsync();
                    
                return GetClientMapperBL.Map<ICollection<GetClientDtoBL>>(allClients);
            }

            return new List<GetClientDtoBL>();
        }
    }
}
