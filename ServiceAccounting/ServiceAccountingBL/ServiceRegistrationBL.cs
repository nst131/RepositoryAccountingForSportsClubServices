using Microsoft.Extensions.DependencyInjection;
using ServiceAccountingBL.BaseCrud;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingDA.Models;
using System;
using ServiceAccountingBL.AttributeValidation;
using ServiceAccountingBL.Models.AccountUser.Account;
using ServiceAccountingBL.Models.AccountUser.Dto;
using ServiceAccountingBL.Models.ClientBLL.Aggregator;
using ServiceAccountingBL.Models.ClientBLL.Crud;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingBL.Models.ClientBLL.Fetchers;
using ServiceAccountingBL.Models.ClientBLL.Mapper;
using ServiceAccountingBL.Models.ClientBLL.Validation;
using ServiceAccountingBL.Models.ClientCardBL.Aggregator;
using ServiceAccountingBL.Models.ClientCardBL.Crud;
using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingBL.Models.ClientCardBL.Fetchers;
using ServiceAccountingBL.Models.ClientCardBL.Mapper;
using ServiceAccountingBL.Models.ClientCardBL.Validation;
using ServiceAccountingBL.Models.ClubCardBLL.Aggregator;
using ServiceAccountingBL.Models.ClubCardBLL.Crud;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingBL.Models.ClubCardBLL.Fetchers;
using ServiceAccountingBL.Models.ClubCardBLL.Mapper;
using ServiceAccountingBL.Models.ClubCardBLL.Validation;
using ServiceAccountingBL.Models.CommonBL;
using ServiceAccountingBL.Models.DealBLL.Aggregator;
using ServiceAccountingBL.Models.DealBLL.Crud;
using ServiceAccountingBL.Models.DealBLL.Dto;
using ServiceAccountingBL.Models.DealBLL.Fetchers;
using ServiceAccountingBL.Models.DealBLL.Mapper;
using ServiceAccountingBL.Models.DealBLL.Validation;
using ServiceAccountingBL.Models.PlaceBLL.Aggregator;
using ServiceAccountingBL.Models.PlaceBLL.Crud;
using ServiceAccountingBL.Models.PlaceBLL.Dto;
using ServiceAccountingBL.Models.PlaceBLL.Fetchers;
using ServiceAccountingBL.Models.PlaceBLL.Mapper;
using ServiceAccountingBL.Models.PlaceBLL.Validation;
using ServiceAccountingBL.Models.ResponsibleBLL.Aggregator;
using ServiceAccountingBL.Models.ResponsibleBLL.Crud;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingBL.Models.ResponsibleBLL.Fetchers;
using ServiceAccountingBL.Models.ResponsibleBLL.Mapper;
using ServiceAccountingBL.Models.ResponsibleBLL.Validation;
using ServiceAccountingBL.Models.ServiceBLL.Aggregator;
using ServiceAccountingBL.Models.ServiceBLL.Crud;
using ServiceAccountingBL.Models.ServiceBLL.Dto;
using ServiceAccountingBL.Models.ServiceBLL.Fetchers;
using ServiceAccountingBL.Models.ServiceBLL.Mapper;
using ServiceAccountingBL.Models.ServiceBLL.Validation;
using ServiceAccountingBL.Models.SubscriptionBLL.Aggregator;
using ServiceAccountingBL.Models.SubscriptionBLL.Crud;
using ServiceAccountingBL.Models.SubscriptionBLL.Dto;
using ServiceAccountingBL.Models.SubscriptionBLL.Fetchers;
using ServiceAccountingBL.Models.SubscriptionBLL.Mapper;
using ServiceAccountingBL.Models.SubscriptionBLL.Validation;
using ServiceAccountingBL.Models.TrainerBLL.Aggregator;
using ServiceAccountingBL.Models.TrainerBLL.Crud;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingBL.Models.TrainerBLL.Fetchers;
using ServiceAccountingBL.Models.TrainerBLL.Mapper;
using ServiceAccountingBL.Models.TrainerBLL.Validation;
using ServiceAccountingBL.Models.TrainingBLL.Aggregator;
using ServiceAccountingBL.Models.TrainingBLL.Crud;
using ServiceAccountingBL.Models.TrainingBLL.Dto;
using ServiceAccountingBL.Models.TrainingBLL.Fetchers;
using ServiceAccountingBL.Models.TrainingBLL.Mapper;
using ServiceAccountingBL.Models.TrainingBLL.Validation;
using ServiceAccountingBL.Models.VisitBLL.Aggregator;
using ServiceAccountingBL.Models.VisitBLL.Crud;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingBL.Models.VisitBLL.Fetchers;
using ServiceAccountingBL.Models.VisitBLL.Mapper;
using ServiceAccountingBL.Models.VisitBLL.Validation;

namespace ServiceAccountingBL
{
    public static class ServiceRegistrationBL
    {
        public static void AddRegistrationBL(this IServiceCollection services)
        {
            //Additional
            services.AddScoped<ICommonFetchers, CommonFetchers>();
            //Attributes
            services.AddScoped<IUniqueTelephoneBL, UniqueTelephoneBL>();
            services.AddScoped<IUniqueEmailBL, UniqueEmailBL>();
            services.AddScoped<ICheckServiceByTrainerBL, CheckServiceByTrainerBL>();
            services.AddScoped<ICheckClientCardBL, CheckClientCardBL>();
            services.AddScoped<ICheckSingleClubCardBL, CheckSingleClubCardBL>();
            services.AddScoped<IUniqueSubscriptionBL, UniqueSubscriptionBL>();
            services.AddScoped<ICheckCorrectCreateDealBL, CheckCorrectCreateDealBL>();
            services.AddScoped<ICheckClientsOnAccordingClubCardBL, CheckClientsOnAccordingClubCardBL>();

            //AccountUser
            services.AddScoped<IAccountUserBL, AccountUserBL>();
            services.AddScoped<IOperationGetEntityManyToMany<ResponseTrainingsInfDtoBL, Training, TrainingToClient>,
                    OperationGetEntityManyToMany<ResponseTrainingsInfDtoBL, Training, TrainingToClient>>();
            services.AddScoped<IOperationGetEntityManyToMany<ResponseSubscriptionInfDtoBL, Subscription, SubscriptionToClient>,
                    OperationGetEntityManyToMany<ResponseSubscriptionInfDtoBL, Subscription, SubscriptionToClient>>();

            services.AddScoped<IOperationGetEntityOneToMany<ResponseVisitInfDtoBL, Visit>, OperationGetEntityOneToMany<ResponseVisitInfDtoBL, Visit>>();
            services.AddScoped<IOperationGetEntityOneToMany<ResponseDealInfDtoBL, Deal>, OperationGetEntityOneToMany<ResponseDealInfDtoBL, Deal>>();

            //Client
            services.AddScoped<IAggregatorClientBL, AggregatorClientBL>();
            services.AddScoped<IValidator<AcceptCreateClientDtoBL>, CreateClientValidatorBL>();
            services.AddScoped<IValidator<AcceptUpdateClientDtoBL>, UpdateClientValidatorBL>();
            services.AddScoped<IMapper<AcceptCreateClientDtoBL, Client>, CreateClientMapperBL>();
            services.AddScoped<IMapperAsync<Client, ResponseClientDtoBL>, ResponseClientMapperBL>();
            services.AddScoped<IMapper<AcceptUpdateClientDtoBL, Client>, UpdateClientMapperBL>();
            services.AddScoped<IMapperAsync<int, ResponseGetClientDtoBL>, GetClientMapperBL>();

            services.AddScoped<IGetter<ResponseGetClientDtoBL>, Getter<Client, ResponseGetClientDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IGetter<ResponseGetClientDtoBL>>(serviceProvider.GetRequiredService<IGetter<ResponseGetClientDtoBL>>));
            services.AddScoped<ICreater<AcceptCreateClientDtoBL, ResponseClientDtoBL>, Creater<Client, AcceptCreateClientDtoBL, ResponseClientDtoBL>>()
                 .AddScoped(serviceProvider => new Lazy<ICreater<AcceptCreateClientDtoBL, ResponseClientDtoBL>>(serviceProvider.GetRequiredService<ICreater<AcceptCreateClientDtoBL, ResponseClientDtoBL>>));
            services.AddScoped<IUpdater<AcceptUpdateClientDtoBL, ResponseClientDtoBL>, Updater<Client, AcceptUpdateClientDtoBL, ResponseClientDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IUpdater<AcceptUpdateClientDtoBL, ResponseClientDtoBL>>(serviceProvider.GetRequiredService<IUpdater<AcceptUpdateClientDtoBL, ResponseClientDtoBL>>));
            services.AddScoped<IRemover<Client>, Remover<Client>>()
                .AddScoped(serviceProvider => new Lazy<IRemover<Client>>(serviceProvider.GetRequiredService<IRemover<Client>>));
            services.AddScoped<IClientFetchersBL, ClientFetchersBL>()
                 .AddScoped(serviceProvider => new Lazy<IClientFetchersBL>(serviceProvider.GetRequiredService<IClientFetchersBL>));
            services.AddScoped<IClientCrudBL, ClientCrudBL>()
                 .AddScoped(serviceProvider => new Lazy<IClientCrudBL>(serviceProvider.GetRequiredService<IClientCrudBL>));

            //ClubCard
            services.AddScoped<IAggregatorClubCardBL, AggregatorClubCardBL>();
            services.AddScoped<IValidator<AcceptCreateClubCardDtoBL>, CreateClubCardValidatorBL>();
            services.AddScoped<IValidator<AcceptUpdateClubCardDtoBL>, UpdateClubCardValidatorBL>();
            services.AddScoped<IMapper<AcceptCreateClubCardDtoBL, ClubCard>, CreateClubCardMapperBL>();
            services.AddScoped<IMapperAsync<ClubCard, ResponseClubCardDtoBL>, ResponseClubCardMapperBL>();
            services.AddScoped<IMapper<AcceptUpdateClubCardDtoBL, ClubCard>, UpdateClubCardMapperBL>();
            services.AddScoped<IMapperAsync<int, ResponseGetClubCardDtoBL>, GetClubCardMapperBL>();

            services.AddScoped<IGetter<ResponseGetClubCardDtoBL>, Getter<ClubCard, ResponseGetClubCardDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IGetter<ResponseGetClubCardDtoBL>>(serviceProvider.GetRequiredService<IGetter<ResponseGetClubCardDtoBL>>));
            services.AddScoped<ICreater<AcceptCreateClubCardDtoBL, ResponseClubCardDtoBL>, Creater<ClubCard, AcceptCreateClubCardDtoBL, ResponseClubCardDtoBL>>()
                 .AddScoped(serviceProvider => new Lazy<ICreater<AcceptCreateClubCardDtoBL, ResponseClubCardDtoBL>>(serviceProvider.GetRequiredService<ICreater<AcceptCreateClubCardDtoBL, ResponseClubCardDtoBL>>));
            services.AddScoped<IUpdater<AcceptUpdateClubCardDtoBL, ResponseClubCardDtoBL>, Updater<ClubCard, AcceptUpdateClubCardDtoBL, ResponseClubCardDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IUpdater<AcceptUpdateClubCardDtoBL, ResponseClubCardDtoBL>>(serviceProvider.GetRequiredService<IUpdater<AcceptUpdateClubCardDtoBL, ResponseClubCardDtoBL>>));
            services.AddScoped<IRemover<ClubCard>, Remover<ClubCard>>()
                .AddScoped(serviceProvider => new Lazy<IRemover<ClubCard>>(serviceProvider.GetRequiredService<IRemover<ClubCard>>));
            services.AddScoped<IClubCardFetchersBL, ClubCardFetchersBL>()
                 .AddScoped(serviceProvider => new Lazy<IClubCardFetchersBL>(serviceProvider.GetRequiredService<IClubCardFetchersBL>));
            services.AddScoped<IClubCardCrudBL, ClubCardCrudBL>()
                 .AddScoped(serviceProvider => new Lazy<IClubCardCrudBL>(serviceProvider.GetRequiredService<IClubCardCrudBL>));

            //Responsible
            services.AddScoped<IAggregatorResponsibleBL, AggregatorResponsibleBL>();
            services.AddScoped<IValidator<AcceptCreateResponsibleDtoBL>, CreateResponsibleValidatorBL>();
            services.AddScoped<IValidator<AcceptUpdateResponsibleDtoBL>, UpdateResponsibleValidatorBL>();
            services.AddScoped<IMapper<AcceptCreateResponsibleDtoBL, Responsible>, CreateResponsibleMapperBL>();
            services.AddScoped<IMapperAsync<Responsible, ResponseResponsibleDtoBL>, ResponseResponsibleMapperBL>();
            services.AddScoped<IMapper<AcceptUpdateResponsibleDtoBL, Responsible>, UpdateResponsibleMapperBL>();
            services.AddScoped<IMapperAsync<int, ResponseGetResponsibleDtoBL>, GetResponsibleMapperBL>();

            services.AddScoped<IGetter<ResponseGetResponsibleDtoBL>, Getter<Responsible, ResponseGetResponsibleDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IGetter<ResponseGetResponsibleDtoBL>>(serviceProvider.GetRequiredService<IGetter<ResponseGetResponsibleDtoBL>>));
            services.AddScoped<ICreater<AcceptCreateResponsibleDtoBL, ResponseResponsibleDtoBL>, Creater<Responsible, AcceptCreateResponsibleDtoBL, ResponseResponsibleDtoBL>>()
                 .AddScoped(serviceProvider => new Lazy<ICreater<AcceptCreateResponsibleDtoBL, ResponseResponsibleDtoBL>>(serviceProvider.GetRequiredService<ICreater<AcceptCreateResponsibleDtoBL, ResponseResponsibleDtoBL>>));
            services.AddScoped<IUpdater<AcceptUpdateResponsibleDtoBL, ResponseResponsibleDtoBL>, Updater<Responsible, AcceptUpdateResponsibleDtoBL, ResponseResponsibleDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IUpdater<AcceptUpdateResponsibleDtoBL, ResponseResponsibleDtoBL>>(serviceProvider.GetRequiredService<IUpdater<AcceptUpdateResponsibleDtoBL, ResponseResponsibleDtoBL>>));
            services.AddScoped<IRemover<Responsible>, Remover<Responsible>>()
                .AddScoped(serviceProvider => new Lazy<IRemover<Responsible>>(serviceProvider.GetRequiredService<IRemover<Responsible>>));
            services.AddScoped<IResponsibleFetchersBL, ResponsibleFetchersBL>()
                 .AddScoped(serviceProvider => new Lazy<IResponsibleFetchersBL>(serviceProvider.GetRequiredService<IResponsibleFetchersBL>));
            services.AddScoped<IResponsibleCrudBL, ResponsibleCrudBL>()
                 .AddScoped(serviceProvider => new Lazy<IResponsibleCrudBL>(serviceProvider.GetRequiredService<IResponsibleCrudBL>));

            //Trainer
            services.AddScoped<IAggregatorTrainerBL, AggregatorTrainerBL>();
            services.AddScoped<IValidator<AcceptCreateTrainerDtoBL>, CreateTrainerValidatorBL>();
            services.AddScoped<IValidator<AcceptUpdateTrainerDtoBL>, UpdateTrainerValidatorBL>();
            services.AddScoped<IMapper<AcceptCreateTrainerDtoBL, Trainer>, CreateTrainerMapperBL>();
            services.AddScoped<IMapperAsync<Trainer, ResponseTrainerDtoBL>, ResponseTrainerMapperBL>();
            services.AddScoped<IMapper<AcceptUpdateTrainerDtoBL, Trainer>, UpdateTrainerMapperBL>();
            services.AddScoped<IMapperAsync<int, ResponseGetTrainerDtoBL>, GetTrainerMapperBL>();

            services.AddScoped<IGetter<ResponseGetTrainerDtoBL>, Getter<Trainer, ResponseGetTrainerDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IGetter<ResponseGetTrainerDtoBL>>(serviceProvider.GetRequiredService<IGetter<ResponseGetTrainerDtoBL>>));
            services.AddScoped<ICreater<AcceptCreateTrainerDtoBL, ResponseTrainerDtoBL>, Creater<Trainer, AcceptCreateTrainerDtoBL, ResponseTrainerDtoBL>>()
                 .AddScoped(serviceProvider => new Lazy<ICreater<AcceptCreateTrainerDtoBL, ResponseTrainerDtoBL>>(serviceProvider.GetRequiredService<ICreater<AcceptCreateTrainerDtoBL, ResponseTrainerDtoBL>>));
            services.AddScoped<IUpdater<AcceptUpdateTrainerDtoBL, ResponseTrainerDtoBL>, Updater<Trainer, AcceptUpdateTrainerDtoBL, ResponseTrainerDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IUpdater<AcceptUpdateTrainerDtoBL, ResponseTrainerDtoBL>>(serviceProvider.GetRequiredService<IUpdater<AcceptUpdateTrainerDtoBL, ResponseTrainerDtoBL>>));
            services.AddScoped<IRemover<Trainer>, Remover<Trainer>>()
                .AddScoped(serviceProvider => new Lazy<IRemover<Trainer>>(serviceProvider.GetRequiredService<IRemover<Trainer>>));
            services.AddScoped<ITrainerFetchersBL, TrainerFetchersBL>()
                 .AddScoped(serviceProvider => new Lazy<ITrainerFetchersBL>(serviceProvider.GetRequiredService<ITrainerFetchersBL>));
            services.AddScoped<ITrainerCrudBL, TrainerCrudBL>()
                 .AddScoped(serviceProvider => new Lazy<ITrainerCrudBL>(serviceProvider.GetRequiredService<ITrainerCrudBL>));

            //Place
            services.AddScoped<IAggregatorPlaceBL, AggregatorPlaceBL>();
            services.AddScoped<IValidator<AcceptCreatePlaceDtoBL>, CreatePlaceValidatorBL>();
            services.AddScoped<IValidator<AcceptUpdatePlaceDtoBL>, UpdatePlaceValidatorBL>();
            services.AddScoped<IMapper<AcceptCreatePlaceDtoBL, Place>, CreatePlaceMapperBL>();
            services.AddScoped<IMapperAsync<Place, ResponsePlaceDtoBL>, ResponsePlaceMapperBL>();
            services.AddScoped<IMapper<AcceptUpdatePlaceDtoBL, Place>, UpdatePlaceMapperBL>();
            services.AddScoped<IMapperAsync<int, ResponseGetPlaceDtoBL>, GetPlaceMapperBL>();

            services.AddScoped<IGetter<ResponseGetPlaceDtoBL>, Getter<Place, ResponseGetPlaceDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IGetter<ResponseGetPlaceDtoBL>>(serviceProvider.GetRequiredService<IGetter<ResponseGetPlaceDtoBL>>));
            services.AddScoped<ICreater<AcceptCreatePlaceDtoBL, ResponsePlaceDtoBL>, Creater<Place, AcceptCreatePlaceDtoBL, ResponsePlaceDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<ICreater<AcceptCreatePlaceDtoBL, ResponsePlaceDtoBL>>(serviceProvider.GetRequiredService<ICreater<AcceptCreatePlaceDtoBL, ResponsePlaceDtoBL>>));
            services.AddScoped<IUpdater<AcceptUpdatePlaceDtoBL, ResponsePlaceDtoBL>, Updater<Place, AcceptUpdatePlaceDtoBL, ResponsePlaceDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IUpdater<AcceptUpdatePlaceDtoBL, ResponsePlaceDtoBL>>(serviceProvider.GetRequiredService<IUpdater<AcceptUpdatePlaceDtoBL, ResponsePlaceDtoBL>>));
            services.AddScoped<IRemover<Place>, Remover<Place>>()
                .AddScoped(serviceProvider => new Lazy<IRemover<Place>>(serviceProvider.GetRequiredService<IRemover<Place>>));
            services.AddScoped<IPlaceFetchersBL, PlaceFetchersBL>()
                .AddScoped(serviceProvider => new Lazy<IPlaceFetchersBL>(serviceProvider.GetRequiredService<IPlaceFetchersBL>));
            services.AddScoped<IPlaceCrudBL, PlaceCrudBL>()
                .AddScoped(serviceProvider => new Lazy<IPlaceCrudBL>(serviceProvider.GetRequiredService<IPlaceCrudBL>));

            //ClientCard
            services.AddScoped<IAggregatorClientCardBL, AggregatorClientCardBL>();
            services.AddScoped<IValidator<AcceptCreateClientCardDtoBL>, CreateClientCardValidatorBL>()
                .AddScoped(serviceProvider => new Lazy<IValidator<AcceptCreateClientCardDtoBL>> (serviceProvider.GetRequiredService<IValidator<AcceptCreateClientCardDtoBL>>));
            services.AddScoped<IValidator<AcceptUpdateClientCardDtoBL>, UpdateClientCardValidatorBL>()
                .AddScoped(serviceProvider => new Lazy<IValidator<AcceptUpdateClientCardDtoBL>>(serviceProvider.GetRequiredService<IValidator<AcceptUpdateClientCardDtoBL>>));
            services.AddScoped<IMapperAsync<int, ResponseGetClientCardDtoBL>, GetClientCardMapperBL>();

            services.AddScoped<IGetter<ResponseGetClientCardDtoBL>, Getter<ClientCard, ResponseGetClientCardDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IGetter<ResponseGetClientCardDtoBL>>(serviceProvider.GetRequiredService<IGetter<ResponseGetClientCardDtoBL>>));
            services.AddScoped<IRemover<ClientCard>, Remover<ClientCard>>()
                .AddScoped(serviceProvider => new Lazy<IRemover<ClientCard>>(serviceProvider.GetRequiredService<IRemover<ClientCard>>));
            services.AddScoped<IClientCardFetchersBL, ClientCardFetchersBL>()
                .AddScoped(serviceProvider => new Lazy<IClientCardFetchersBL>(serviceProvider.GetRequiredService<IClientCardFetchersBL>));
            services.AddScoped<IClientCardCrudBL, ClientCardCrudBL>()
                .AddScoped(serviceProvider => new Lazy<IClientCardCrudBL>(serviceProvider.GetRequiredService<IClientCardCrudBL>));

            //Training
            services.AddScoped<IAggregatorTrainingBL, AggregatorTrainingBL>();
            services.AddScoped<IValidator<AcceptCreateTrainingDtoBL>, CreateTrainingValidatorBL>()
                .AddScoped(serviceProvider => new Lazy<IValidator<AcceptCreateTrainingDtoBL>>(serviceProvider.GetRequiredService<IValidator<AcceptCreateTrainingDtoBL>>));
            services.AddScoped<IValidator<AcceptUpdateTrainingDtoBL>, UpdateTrainingValidatorBL>()
                .AddScoped(serviceProvider => new Lazy<IValidator<AcceptUpdateTrainingDtoBL>>(serviceProvider.GetRequiredService<IValidator<AcceptUpdateTrainingDtoBL>>));
            services.AddScoped<IMapperAsync<int, ResponseGetTrainingDtoBL>, GetTrainingMapperBL>();

            services.AddScoped<ICheckClientCardNecessaryServiceValidation, CheckClientCardNecessaryServiceValidation>();
            services.AddScoped<ITrainingAditionalOperation, TrainingAditionalOperation>();

            services.AddScoped<IGetter<ResponseGetTrainingDtoBL>, Getter<Training, ResponseGetTrainingDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IGetter<ResponseGetTrainingDtoBL>>(serviceProvider.GetRequiredService<IGetter<ResponseGetTrainingDtoBL>>));
            services.AddScoped<IRemover<Training>, Remover<Training>>()
                .AddScoped(serviceProvider => new Lazy<IRemover<Training>>(serviceProvider.GetRequiredService<IRemover<Training>>));
            services.AddScoped<ITrainingFetchersBL, TrainingFetchersBL>()
                .AddScoped(serviceProvider => new Lazy<ITrainingFetchersBL>(serviceProvider.GetRequiredService<ITrainingFetchersBL>));
            services.AddScoped<ITrainingCrudBL, TrainingCrudBL>()
                .AddScoped(serviceProvider => new Lazy<ITrainingCrudBL>(serviceProvider.GetRequiredService<ITrainingCrudBL>));

            //Visit
            services.AddScoped<IAggregatorVisitBL, AggregatorVisitBL>();
            services.AddScoped<IValidator<AcceptCreateVisitDtoBL>, CreateVisitValidatorBL>();
            services.AddScoped<IValidator<AcceptUpdateVisitDtoBL>, UpdateVisitValidatorBL>();
            services.AddScoped<IMapper<AcceptCreateVisitDtoBL, Visit>, CreateVisitMapperBL>();
            services.AddScoped<IMapperAsync<Visit, ResponseVisitDtoBL>, ResponseVisitMapperBL>();
            services.AddScoped<IMapper<AcceptUpdateVisitDtoBL, Visit>, UpdateVisitMapperBL>();
            services.AddScoped<IMapperAsync<int, ResponseGetVisitDtoBL>, GetVisitMapperBL>();

            services.AddScoped<IGetter<ResponseGetVisitDtoBL>, Getter<Visit, ResponseGetVisitDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IGetter<ResponseGetVisitDtoBL>>(serviceProvider.GetRequiredService<IGetter<ResponseGetVisitDtoBL>>));
            services.AddScoped<ICreater<AcceptCreateVisitDtoBL, ResponseVisitDtoBL>, Creater<Visit, AcceptCreateVisitDtoBL, ResponseVisitDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<ICreater<AcceptCreateVisitDtoBL, ResponseVisitDtoBL>>(serviceProvider.GetRequiredService<ICreater<AcceptCreateVisitDtoBL, ResponseVisitDtoBL>>));
            services.AddScoped<IUpdater<AcceptUpdateVisitDtoBL, ResponseVisitDtoBL>, Updater<Visit, AcceptUpdateVisitDtoBL, ResponseVisitDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IUpdater<AcceptUpdateVisitDtoBL, ResponseVisitDtoBL>>(serviceProvider.GetRequiredService<IUpdater<AcceptUpdateVisitDtoBL, ResponseVisitDtoBL>>));
            services.AddScoped<IRemover<Visit>, Remover<Visit>>()
                .AddScoped(serviceProvider => new Lazy<IRemover<Visit>>(serviceProvider.GetRequiredService<IRemover<Visit>>));
            services.AddScoped<IVisitFetchersBL, VisitFetchersBL>()
                .AddScoped(serviceProvider => new Lazy<IVisitFetchersBL>(serviceProvider.GetRequiredService<IVisitFetchersBL>));
            services.AddScoped<IVisitCrudBL, VisitCrudBL>()
                .AddScoped(serviceProvider => new Lazy<IVisitCrudBL>(serviceProvider.GetRequiredService<IVisitCrudBL>));

            //Service
            services.AddScoped<IAggregatorServiceBL, AggregatorServiceBL>();
            services.AddScoped<IValidator<AcceptCreateServiceDtoBL>, CreateServiceValidatorBL>();
            services.AddScoped<IValidator<AcceptUpdateServiceDtoBL>, UpdateServiceValidatorBL>();
            services.AddScoped<IMapper<AcceptCreateServiceDtoBL, Service>, CreateServiceMapperBL>();
            services.AddScoped<IMapperAsync<Service, ResponseServiceDtoBL>, ResponseServiceMapperBL>();
            services.AddScoped<IMapper<AcceptUpdateServiceDtoBL, Service>, UpdateServiceMapperBL>();
            services.AddScoped<IMapperAsync<int, ResponseGetServiceDtoBL>, GetServiceMapperBL>();

            services.AddScoped<IGetter<ResponseGetServiceDtoBL>, Getter<Service, ResponseGetServiceDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IGetter<ResponseGetServiceDtoBL>>(serviceProvider.GetRequiredService<IGetter<ResponseGetServiceDtoBL>>));
            services.AddScoped<ICreater<AcceptCreateServiceDtoBL, ResponseServiceDtoBL>, Creater<Service, AcceptCreateServiceDtoBL, ResponseServiceDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<ICreater<AcceptCreateServiceDtoBL, ResponseServiceDtoBL>>(serviceProvider.GetRequiredService<ICreater<AcceptCreateServiceDtoBL, ResponseServiceDtoBL>>));
            services.AddScoped<IUpdater<AcceptUpdateServiceDtoBL, ResponseServiceDtoBL>, Updater<Service, AcceptUpdateServiceDtoBL, ResponseServiceDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IUpdater<AcceptUpdateServiceDtoBL, ResponseServiceDtoBL>>(serviceProvider.GetRequiredService<IUpdater<AcceptUpdateServiceDtoBL, ResponseServiceDtoBL>>));
            services.AddScoped<IRemover<Service>, Remover<Service>>()
                .AddScoped(serviceProvider => new Lazy<IRemover<Service>>(serviceProvider.GetRequiredService<IRemover<Service>>));
            services.AddScoped<IServiceFetchersBL, ServiceFetchersBL>()
                .AddScoped(serviceProvider => new Lazy<IServiceFetchersBL>(serviceProvider.GetRequiredService<IServiceFetchersBL>));
            services.AddScoped<IServiceCrudBL, ServiceCrudBL>()
                .AddScoped(serviceProvider => new Lazy<IServiceCrudBL>(serviceProvider.GetRequiredService<IServiceCrudBL>));

            //Deal
            services.AddScoped<IAggregatorDealBL, AggregatorDealBL>();
            services.AddScoped<IValidator<AcceptCreateDealDtoBL>, CreateDealValidatorBL>();
            services.AddScoped<IValidator<AcceptUpdateDealDtoBL>, UpdateDealValidatorBL>();
            services.AddScoped<IMapper<AcceptCreateDealDtoBL, Deal>, CreateDealMapperBL>();
            services.AddScoped<IMapperAsync<Deal, ResponseDealDtoBL>, ResponseDealMapperBL>();
            services.AddScoped<IMapper<AcceptUpdateDealDtoBL, Deal>, UpdateDealMapperBL>();
            services.AddScoped<IMapperAsync<int, ResponseGetDealDtoBL>, GetDealMapperBL>();

            services.AddScoped<IReternableValidator<AcceptUpdateDealDtoBL, Deal>, ReturnableUpdateDealValidation>();
            services.AddScoped<IDealAdditionalOperations, DealAdditionalOperations>();

            services.AddScoped<IGetter<ResponseGetDealDtoBL>, Getter<Deal, ResponseGetDealDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IGetter<ResponseGetDealDtoBL>>(serviceProvider.GetRequiredService<IGetter<ResponseGetDealDtoBL>>));
            services.AddScoped<ICreater<AcceptCreateDealDtoBL, ResponseDealDtoBL>, Creater<Deal, AcceptCreateDealDtoBL, ResponseDealDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<ICreater<AcceptCreateDealDtoBL, ResponseDealDtoBL>>(serviceProvider.GetRequiredService<ICreater<AcceptCreateDealDtoBL, ResponseDealDtoBL>>));
            services.AddScoped<IUpdater<AcceptUpdateDealDtoBL, ResponseDealDtoBL>, Updater<Deal, AcceptUpdateDealDtoBL, ResponseDealDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IUpdater<AcceptUpdateDealDtoBL, ResponseDealDtoBL>>(serviceProvider.GetRequiredService<IUpdater<AcceptUpdateDealDtoBL, ResponseDealDtoBL>>));
            services.AddScoped<IRemover<Deal>, Remover<Deal>>()
                .AddScoped(serviceProvider => new Lazy<IRemover<Deal>>(serviceProvider.GetRequiredService<IRemover<Deal>>));
            services.AddScoped<IDealFetchersBL, DealFetchersBL>()
                .AddScoped(serviceProvider => new Lazy<IDealFetchersBL>(serviceProvider.GetRequiredService<IDealFetchersBL>));
            services.AddScoped<IDealCrudBL, DealCrudBL>()
                .AddScoped(serviceProvider => new Lazy<IDealCrudBL>(serviceProvider.GetRequiredService<IDealCrudBL>));

            //Subscription
            services.AddScoped<IAggregatorSubscriptionBL, AggregatorSubscriptionBL>();
            services.AddScoped<IValidator<AcceptCreateSubscriptionDtoBL>, CreateSubscriptionValidatorBL>()
                .AddScoped(serviceProvider => new Lazy<IValidator<AcceptCreateSubscriptionDtoBL>>(serviceProvider.GetRequiredService<IValidator<AcceptCreateSubscriptionDtoBL>>));
            services.AddScoped<IValidator<AcceptUpdateSubscriptionDtoBL>, UpdateSubscriptionValidatorBL>()
                .AddScoped(serviceProvider => new Lazy<IValidator<AcceptUpdateSubscriptionDtoBL>>(serviceProvider.GetRequiredService<IValidator<AcceptUpdateSubscriptionDtoBL>>));
            services.AddScoped<IMapperAsync<int, ResponseGetSubscriptionDtoBL>, GetSubscriptionMapperBL>();

            services.AddScoped<ISubscriptionAdditionalOperations, SubscriptionAdditionalOperations>();

            services.AddScoped<IGetter<ResponseGetSubscriptionDtoBL>, Getter<Subscription, ResponseGetSubscriptionDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IGetter<ResponseGetSubscriptionDtoBL>>(serviceProvider.GetRequiredService<IGetter<ResponseGetSubscriptionDtoBL>>));
            services.AddScoped<IRemover<Subscription>, Remover<Subscription>>()
                .AddScoped(serviceProvider => new Lazy<IRemover<Subscription>>(serviceProvider.GetRequiredService<IRemover<Subscription>>));
            services.AddScoped<ISubscriptionFetchersBL, SubscriptionFetchersBL>()
                .AddScoped(serviceProvider => new Lazy<ISubscriptionFetchersBL>(serviceProvider.GetRequiredService<ISubscriptionFetchersBL>));
            services.AddScoped<ISubscriptionCrudBL, SubscriptionCrudBL>()
                .AddScoped(serviceProvider => new Lazy<ISubscriptionCrudBL>(serviceProvider.GetRequiredService<ISubscriptionCrudBL>));
        }
    }
}
