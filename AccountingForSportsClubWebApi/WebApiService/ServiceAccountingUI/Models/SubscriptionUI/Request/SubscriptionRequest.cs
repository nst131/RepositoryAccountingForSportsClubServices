using RedisLibrary.Attributes;
using RedisLibrary.Models;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.SubscriptionBLL.Crud;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;
using ServiceAccountingBL.Models.SubscriptionBLL.Fetchers;
using ServiceAccountingUI.Models.SubscriptionUI.Dto;
using ServiceAccountingUI.Models.SubscriptionUI.Mapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAccountingUI.Models.SubscriptionUI.Request
{
    public class SubscriptionRequest
    {
        [ViewOperation(Operation.GetAll)]
        public static async Task<ICollection<ResponseGetSubscriptionDtoUI>> GetAll(
            ISubscriptionFetchersBL subscriptionFetchers,
            CancellationToken token)
        {
            var allSubscriptionsDtoBL = await subscriptionFetchers.GetSubscriptionAll(token);

            if (allSubscriptionsDtoBL is null)
                throw new ElementByIdNotFoundException();

            var allSubscriptionDtoUI = ReadSubscriptionMapperUI.Map<ICollection<ResponseGetSubscriptionDtoUI>>(allSubscriptionsDtoBL);

            return allSubscriptionDtoUI;
        }

        [ViewOperation(Operation.Get)]
        public static async Task<ResponseGetSubscriptionDtoUI> Get(
            AcceptGetSubscriptionDtoUI acceptGetSubscriptionDtoUI,
            ISubscriptionCrudBL subscriptionCrudBL,
            CancellationToken token)
        {
            if (acceptGetSubscriptionDtoUI is null)
                throw new ElementNullReferenceException();

            var subscriptionDtoBL = await subscriptionCrudBL.GetSubscription(acceptGetSubscriptionDtoUI.Id, token);

            if (subscriptionDtoBL is null)
                throw new ElementByIdNotFoundException();

            var subscriptionDtoUI = ReadSubscriptionMapperUI.Map<ResponseGetSubscriptionDtoUI>(subscriptionDtoBL);
            return subscriptionDtoUI;
        }

        [ViewOperation(Operation.Create)]
        public static async Task<ResponseGetSubscriptionDtoUI> Add(
            AcceptCreateSubscriptionDtoUI createSubscriptionDtoUI,
            ISubscriptionCrudBL subscriptionCrudBL,
            CancellationToken token)
        {
            if (createSubscriptionDtoUI is null)
                throw new ElementNullReferenceException();

            var createSubscriptionBL = CreateSubscriptionMapperUI.Map<AcceptCreateSubscriptionDtoBL>(createSubscriptionDtoUI);
            var subscriptionDtoBL = await subscriptionCrudBL.CreateSubscription(createSubscriptionBL, token);
            var subscriptionDtoUI = ReadSubscriptionMapperUI.Map<ResponseGetSubscriptionDtoUI>(subscriptionDtoBL);

            return subscriptionDtoUI;
        }

        [ViewOperation(Operation.Update)]
        public static async Task<ResponseGetSubscriptionDtoUI> Update(
            AcceptUpdateSubscriptionDtoUI updateSubscriptionDtoUI,
            ISubscriptionCrudBL subscriptionCrudBL,
            CancellationToken token)
        {
            if (updateSubscriptionDtoUI is null)
                throw new ElementNullReferenceException();

            var updateSubscriptionBL = UpdateSubscriptionMapperUI.Map<AcceptUpdateSubscriptionDtoBL>(updateSubscriptionDtoUI);
            var subscriptionDtoBL = await subscriptionCrudBL.UpdateSubscription(updateSubscriptionBL, token);
            var subscriptionDtoUI = ReadSubscriptionMapperUI.Map<ResponseGetSubscriptionDtoUI>(subscriptionDtoBL);

            return subscriptionDtoUI;
        }

        [ViewOperation(Operation.Delete)]
        public static async Task<ResponseGetSubscriptionDtoUI> Delete(
            AcceptDeleteSubscriptionDtoUI deleteSubscriptionDtoUI,
            ISubscriptionCrudBL subscriptionCrudBL,
            CancellationToken token)
        {
            if (deleteSubscriptionDtoUI is null)
                throw new ElementNullReferenceException();

            var idSubscription = await subscriptionCrudBL.DeleteSubscription(deleteSubscriptionDtoUI.Id, token);

            return new ResponseGetSubscriptionDtoUI() { Id = idSubscription };
        }
    }
}
