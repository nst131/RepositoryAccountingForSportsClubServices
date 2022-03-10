using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Models.AccountUser.Account;
using ServiceAccountingBL.Models.AccountUser.Dto;
using ServiceAccountingUI.Models.AccountUserUI.Dto;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ServiceAccountingUI.BaseModels;

namespace ServiceAccountingUI.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AccountUserController : ControllerBase
    {
        private readonly IAccountUserBL accountUserBL;
        private readonly IMapper mapper;

        public AccountUserController(IAccountUserBL accountUserBl, IMapper mapper)
        {
            accountUserBL = accountUserBl;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.User)]
        public async Task<ActionResult<ResponseMainInformationUserAccountDtoBL>> GetMainInformation(
            [FromBody] AcceptMainInformationUserAccountDtoUI acceptAccountDto,
            CancellationToken token)
        {
            if (acceptAccountDto is null)
                throw new ElementNullReferenceException();

            var mainInfBL = await this.accountUserBL.GetMainAccountInformation(acceptAccountDto.Id, token);

            if (mainInfBL is null)
                throw new ElementByIdNotFoundException();

            var mainInfUI = this.mapper.Map<ResponseMainInformationUserAccountDtoUI>(mainInfBL);
            return new JsonResult(mainInfUI);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.User)]
        public async Task<ActionResult<ICollection<ResponseTrainingInfDtoUI>>> GetTrainingsUserInf(
            [FromBody] AcceptTrainingsInfDtoBL acceptAccountDto,
            CancellationToken token)
        {
            if (acceptAccountDto is null)
                throw new ElementNullReferenceException();

            var userCollectionTrainingsBL = await this.accountUserBL.GetUserTrainingsInfo(acceptAccountDto.Id, token);

            if (userCollectionTrainingsBL is null)
                throw new ElementByIdNotFoundException();

            var userCollectionTrainingsUI = userCollectionTrainingsBL.Select(userTraining => this.mapper.Map<ResponseTrainingInfDtoUI>(userTraining)).ToList();

            return new JsonResult(userCollectionTrainingsUI);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.User)]
        public async Task<ActionResult<ICollection<ResponseVisitInfDtoUI>>> GetVisitsUserInf(
            [FromBody] AcceptVisitInfDtoUI acceptVisitInf,
            CancellationToken token)
        {
            if (acceptVisitInf is null)
                throw new ElementNullReferenceException();

            var userCollectionVisitsBL = await this.accountUserBL.GetUserVisitsInfo(acceptVisitInf.Id, token);

            if(userCollectionVisitsBL is null)
                throw new ElementByIdNotFoundException();

            var userCollectionVisitsUI = userCollectionVisitsBL.Select(userVisit => this.mapper.Map<ResponseVisitInfDtoUI>(userVisit)).ToList();

            return new JsonResult(userCollectionVisitsUI);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.User)]
        public async Task<ActionResult<ICollection<ResponseSubscriptionInfDtoUI>>> GetSubscriptionsUserInf(
            [FromBody] AcceptSubscriptionInfDtoUI acceptSubscriptionInf,
            CancellationToken token)
        {
            if (acceptSubscriptionInf is null)
                throw new ElementNullReferenceException();

            var userCollectionSubscriptionsBL = await this.accountUserBL.GetSubscriptionsInf(acceptSubscriptionInf.Id, token);

            if (userCollectionSubscriptionsBL is null)
                throw new ElementByIdNotFoundException();

            var userCollectionSubscriptionsUI = userCollectionSubscriptionsBL.Select(userVisit => this.mapper.Map<ResponseSubscriptionInfDtoUI>(userVisit)).ToList();

            return new JsonResult(userCollectionSubscriptionsUI);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Policy = PolicyService.User)]
        public async Task<ActionResult<ICollection<ResponseDealInfDtoUI>>> GetDealsUserInf(
            [FromBody] AcceptDealInfDtoUI acceptDealInf,
            CancellationToken token)
        {
            if (acceptDealInf is null)
                throw new ElementNullReferenceException();

            var userCollectionDealsBL = await this.accountUserBL.GetDealInf(acceptDealInf.Id, token);

            if (userCollectionDealsBL is null)
                throw new ElementByIdNotFoundException();

            var userCollectionDealsUI = userCollectionDealsBL.Select(userDeal => this.mapper.Map<ResponseDealInfDtoUI>(userDeal)).ToList();

            return new JsonResult(userCollectionDealsUI);
        }
    }
}
