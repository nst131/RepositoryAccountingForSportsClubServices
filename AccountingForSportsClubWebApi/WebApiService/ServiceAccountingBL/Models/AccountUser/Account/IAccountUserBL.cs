using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.AccountUser.Dto;

namespace ServiceAccountingBL.Models.AccountUser.Account
{
    public interface IAccountUserBL
    {
        Task<ResponseMainInformationUserAccountDtoBL> GetMainAccountInformation(int clientId, CancellationToken token);
        Task<ICollection<ResponseTrainingsInfDtoBL>> GetUserTrainingsInfo(int clientId, CancellationToken token);
        Task<ICollection<ResponseVisitInfDtoBL>> GetUserVisitsInfo(int clientId, CancellationToken token);
        Task<ICollection<ResponseSubscriptionInfDtoBL>> GetSubscriptionsInf(int clientId, CancellationToken token);
        Task<ICollection<ResponseDealInfDtoBL>> GetDealInf(int clientId, CancellationToken token);
    }
}