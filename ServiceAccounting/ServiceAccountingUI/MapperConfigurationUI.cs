using AutoMapper;
using ServiceAccountingBL.Models.AccountUser.Dto;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingUI.Models.AccountUserUI.Dto;
using ServiceAccountingUI.Models.TrainerUI.Dto;

namespace ServiceAccountingUI
{
    public class MapperConfigurationUI : Profile
    {
        public MapperConfigurationUI()
        {
            //Trainer
            CreateMap<ResponseGetServiceByTrainerIdDtoUI, ResponseGetServiceByTrainerIdDtoBL>().ReverseMap();

            //AccountUser
            CreateMap<ResponseMainInformationUserAccountDtoBL, ResponseMainInformationUserAccountDtoUI>();
            CreateMap<ResponseTrainingsInfDtoBL, ResponseTrainingInfDtoUI>();
            CreateMap<ResponseVisitInfDtoBL, ResponseVisitInfDtoUI>();
            CreateMap<ResponseSubscriptionInfDtoBL, ResponseSubscriptionInfDtoUI>();
            CreateMap<ResponseDealInfDtoBL, ResponseDealInfDtoUI>();
        }
    }
}
