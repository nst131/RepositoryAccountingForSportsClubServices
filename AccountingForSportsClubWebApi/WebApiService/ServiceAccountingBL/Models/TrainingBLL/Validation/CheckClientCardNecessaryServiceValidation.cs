using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.BaseModels;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.ClientCardBL.Crud;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.TrainingBLL.Validation
{
    public class CheckClientCardNecessaryServiceValidation : ICheckClientCardNecessaryServiceValidation
    {
        private readonly IClientCardCrudBL clientCardCrud;
        private readonly IServiceAccountingContext context;

        public CheckClientCardNecessaryServiceValidation(IClientCardCrudBL clientCardCrud, IServiceAccountingContext context)
        {
            this.clientCardCrud = clientCardCrud;
            this.context = context;
        }

        public async Task<ICollection<ClientsHasExpiredDto>> GetClientsHasExpired(ICollection<int> clientsId, int necessaryServicId, CancellationToken token)
        {
            var clientsHasExpired = new List<ClientsHasExpiredDto>();
            var deleteClientCards = new List<int>();
            var taskArray = new Task[clientsId.Count];
            var i = 0;

            foreach (var clientId in clientsId)
            {
                taskArray[i] = QueryCheckServiceInClientCard(clientId);
                i++;
            }

            Task.WaitAll(taskArray, token);

            if (deleteClientCards.Count != 0)
            {
                deleteClientCards.ForEach(async x => await this.clientCardCrud.DeleteClientCard(x, token));
            }


            async Task QueryCheckServiceInClientCard(int clientId)
            {
                var client = await this.context.Set<Client>()
                    .AsNoTracking()
                    .Where(x => x.Id == clientId)
                    .Include(x => x.ClientCard)
                    .FirstOrDefaultAsync(token);

                if (client is null)
                    throw new ElementNullReferenceException("Client is null");

                if (client.ClientCard?.ServiceId != necessaryServicId)
                    throw new ElementNullReferenceException("ClientCard is null or not according necessary Service");

                if (client.ClientCard.DateExpiration < DateTime.Now)
                {
                    clientsHasExpired.Add(new ClientsHasExpiredDto()
                    {
                        Id = client.Id,
                        Name = client.Name,
                        SerName = client.SerName
                    });

                    deleteClientCards.Add(client.ClientCard.Id);
                }
            }

            await Task.CompletedTask;

            return clientsHasExpired;
        }
    }
}
