using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.AccountUser.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.AccountUser.Account
{
    public class AccountUserBL : IAccountUserBL
    {
        private readonly IServiceAccountingContext context;
        private readonly IMapper mapper;
        private readonly IOperationGetEntityManyToMany<ResponseTrainingsInfDtoBL, Training, TrainingToClient> getTrainingInfo;
        private readonly IOperationGetEntityManyToMany<ResponseSubscriptionInfDtoBL, Subscription, SubscriptionToClient> getSubscriptionInfo;
        private readonly IOperationGetEntityOneToMany<ResponseVisitInfDtoBL, Visit> getVisitInfo;
        private readonly IOperationGetEntityOneToMany<ResponseDealInfDtoBL, Deal> getDealInfo;

        public AccountUserBL(
            IServiceAccountingContext context,
            IMapper mapper,
            IOperationGetEntityManyToMany<ResponseTrainingsInfDtoBL, Training, TrainingToClient> getTrainingInfo,
            IOperationGetEntityManyToMany<ResponseSubscriptionInfDtoBL, Subscription, SubscriptionToClient> getSubscriptionInfo, 
            IOperationGetEntityOneToMany<ResponseVisitInfDtoBL, Visit> getVisitInfo,
            IOperationGetEntityOneToMany<ResponseDealInfDtoBL, Deal> getDealInfo)
        {
            this.context = context;
            this.mapper = mapper;
            this.getTrainingInfo = getTrainingInfo;
            this.getSubscriptionInfo = getSubscriptionInfo;
            this.getVisitInfo = getVisitInfo;
            this.getDealInfo = getDealInfo;
        }

        public async Task<ResponseMainInformationUserAccountDtoBL> GetMainAccountInformation(int clientId, CancellationToken token)
        {
            var client = await this.context.Set<Client>()
                .AsNoTracking()
                .Include(x => x.TypeSex)
                .Include(x => x.ClientCard).ThenInclude(x => x.ClubCard).ThenInclude(x => x.Service)
                .FirstOrDefaultAsync(x => x.Id == clientId, token);

            if (client is null)
                throw new ElementNullReferenceException($"{nameof(Client)} is null");

            var clientInf = this.mapper.Map<ResponseClientInfDtoBL>(client);
            var mainInf = new ResponseMainInformationUserAccountDtoBL() { ClientInf = clientInf };

            var clientCard = client.ClientCard;
            mainInf.ClientCardInf = clientCard is null ? new ResponseClientCardInfDtoBL() : this.mapper.Map<ResponseClientCardInfDtoBL>(client);

            return mainInf;
        }

        public async Task<ICollection<ResponseVisitInfDtoBL>> GetUserVisitsInfo(int clientId, CancellationToken token)
        {
            return await this.getVisitInfo.GetEntityOneToMany(AccountRequest.GetVisits, context, clientId, token);
        }

        public async Task<ICollection<ResponseTrainingsInfDtoBL>> GetUserTrainingsInfo(int clientId, CancellationToken token)
        {
            return await this.getTrainingInfo.GetEntityManyToMany(AccountRequest.GetTrainingsToClient, AccountRequest.GetTraining, this.context, clientId, token);
        }

        public async Task<ICollection<ResponseSubscriptionInfDtoBL>> GetSubscriptionsInf(int clientId, CancellationToken token)
        {
            return await this.getSubscriptionInfo.GetEntityManyToMany(AccountRequest.GetSubscriptionToClient, AccountRequest.GetSubscription, this.context, clientId, token);
        }

        public async Task<ICollection<ResponseDealInfDtoBL>> GetDealInf(int clientId, CancellationToken token)
        {
            return await this.getDealInfo.GetEntityOneToMany(AccountRequest.GetDeals, context, clientId, token);
        }
    }
}
