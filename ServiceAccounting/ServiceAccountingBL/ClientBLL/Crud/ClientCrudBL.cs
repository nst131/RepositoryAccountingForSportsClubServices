using ServiceAccountingBL.ClientBLL.Aggregator;
using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingBL.ClientBLL.Mapper;
using ServiceAccountingBL.ClientBLL.Validation;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Threading.Tasks;

namespace ServiceAccountingBL.ClientBLL.Crud
{
    public class ClientCrudBL : IClientCrudBL
    {
        private readonly IServiceAccountingContext context;
        private readonly IClientValidator<CreateClientDtoBL> validator;

        public ClientCrudBL(IServiceAccountingContext context, IAggregatorClientBL aggregator)
        {
            this.context = context;
            validator = aggregator.CreateClientValidator;
        }

        public async Task<ClientDtoBL> CreateClient(CreateClientDtoBL createClientDtoBL)
        {
            await validator.Validate(createClientDtoBL);
            var client = CreateClientMapperBL.Map<Client>(createClientDtoBL);
            var addedClient = await context.Set<Client>().AddAsync(client);
            await context.SaveChangesAsync();

            return CreateClientMapperBL.Map<ClientDtoBL>(addedClient.Entity);
        }
    }
}
