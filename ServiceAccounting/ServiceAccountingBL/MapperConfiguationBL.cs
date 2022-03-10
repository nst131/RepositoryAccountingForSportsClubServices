using AutoMapper;
using ServiceAccountingBL.Models.AccountUser.Dto;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL
{
    public class MapperConfiguationBL : Profile
    {
        public MapperConfiguationBL()
        {
            //Trainer
            CreateMap<ResponseGetServiceByTrainerIdDtoBL, Service>().ReverseMap();

            //AccountUser
            CreateMap<Client, ResponseClientInfDtoBL>()
                .ForMember(x => x.TypeSexName, y => y.MapFrom(z => z.TypeSex.Name));
            CreateMap<Client, ResponseClientCardInfDtoBL>()
                .ForMember(x => x.DateActivation, y => y.MapFrom(z => z.ClientCard.DateActivation.ToLocalTime()))
                .ForMember(x => x.DateExpiration, y => y.MapFrom(z => z.ClientCard.DateExpiration.ToLocalTime()))
                .ForMember(x => x.ClubCardName, y => y.MapFrom(z => z.ClientCard.ClubCard.Name))
                .ForMember(x => x.ServiceName, y => y.MapFrom(z => z.ClientCard.ClubCard.Service.Name));
            CreateMap<Training, ResponseTrainingsInfDtoBL>()
                .ForMember(x => x.StartTraining, y => y.MapFrom(z => z.StartTraining.ToLocalTime()))
                .ForMember(x => x.FinishTraining, y => y.MapFrom(z => z.FinishTraining.ToLocalTime()))
                .ForMember(x => x.TrainerName, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.ServiceName, y =>
                {
                    y.PreCondition(x => x.Service != null);
                    y.MapFrom(z => z.Service.Name);
                });
            CreateMap<Visit, ResponseVisitInfDtoBL>()
                .ForMember(x => x.Arrival, y => y.MapFrom(z => z.Arrival.ToLocalTime()))
                .ForMember(x => x.ServiceName, y =>
                {
                    y.PreCondition(x => x.Service != null);
                    y.MapFrom(z => z.Service.Name);
                });
            CreateMap<Subscription, ResponseSubscriptionInfDtoBL>()
                .ForMember(x => x.ServiceName, y =>
                {
                    y.PreCondition(x => x.Service != null);
                    y.MapFrom(z => z.Service.Name);
                });
            CreateMap<Deal, ResponseDealInfDtoBL>()
                .ForMember(x => x.PurchaseDate, y => y.MapFrom(z => z.PurchaseDate.ToLocalTime()))
                .ForMember(x => x.ClubCardName, y =>
                {
                    y.PreCondition(x => x.ClubCard != null);
                    y.MapFrom(z => z.ClubCard.Name);
                })
                .ForMember(x => x.SubscriptionName, y =>
                {
                    y.PreCondition(z => z.Subscription != null);
                    y.MapFrom(z => z.Subscription.Name);
                });
        }
    }
}
