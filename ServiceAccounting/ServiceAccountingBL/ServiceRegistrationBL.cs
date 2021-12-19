using Microsoft.Extensions.DependencyInjection;
using ServiceAccountingBL.AdditionalValidation;
using ServiceAccountingBL.BaseCrud;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingDA.Models;
using System;
using ServiceAccountingBL.Models.ClientBLL.Aggregator;
using ServiceAccountingBL.Models.ClientBLL.Crud;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingBL.Models.ClientBLL.Fetchers;
using ServiceAccountingBL.Models.ClientBLL.Mapper;
using ServiceAccountingBL.Models.ClientBLL.Validation;
using ServiceAccountingBL.Models.ClubCardBLL.Aggregator;
using ServiceAccountingBL.Models.ClubCardBLL.Crud;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingBL.Models.ClubCardBLL.Fetchers;
using ServiceAccountingBL.Models.ClubCardBLL.Mapper;
using ServiceAccountingBL.Models.ClubCardBLL.Validation;
using ServiceAccountingBL.Models.ResponsibleBLL.Aggregator;
using ServiceAccountingBL.Models.ResponsibleBLL.Crud;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingBL.Models.ResponsibleBLL.Fetchers;
using ServiceAccountingBL.Models.ResponsibleBLL.Mapper;
using ServiceAccountingBL.Models.ResponsibleBLL.Validation;
using ServiceAccountingBL.Models.TrainerBLL.Aggregator;
using ServiceAccountingBL.Models.TrainerBLL.Crud;
using ServiceAccountingBL.Models.TrainerBLL.Dto;
using ServiceAccountingBL.Models.TrainerBLL.Fetchers;
using ServiceAccountingBL.Models.TrainerBLL.Mapper;
using ServiceAccountingBL.Models.TrainerBLL.Validation;

namespace ServiceAccountingBL
{
    public static class ServiceRegistrationBL
    {
        public static void RegistrationBL(this IServiceCollection services)
        {
            //Common
            services.AddScoped<IUniqueTelephoneBL, UniqueTelephoneBL>();

            //Client
            services.AddScoped<IAggregatorClientBL, AggregatorClientBL>();
            services.AddScoped<IValidator<CreateClientDtoBL>, CreateClientValidatorBL>();
            services.AddScoped<IValidator<UpdateClientDtoBL>, UpdateClientValidatorBL>();
            services.AddScoped<IMapper<CreateClientDtoBL, Client>, CreateClientMapperBL>();
            services.AddScoped<IMapper<Client, ClientDtoBL>, ResponseClientMapperBL>();
            services.AddScoped<IMapper<UpdateClientDtoBL, Client>, UpdateClientMapperBL>();

            services.AddScoped<ICreater<CreateClientDtoBL, ClientDtoBL>, Creater<Client, CreateClientDtoBL, ClientDtoBL>>()
                 .AddScoped(serviceProvider => new Lazy<ICreater<CreateClientDtoBL, ClientDtoBL>>(serviceProvider.GetRequiredService<ICreater<CreateClientDtoBL, ClientDtoBL>>));
            services.AddScoped<IUpdater<UpdateClientDtoBL, ClientDtoBL>, Updater<Client, UpdateClientDtoBL, ClientDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IUpdater<UpdateClientDtoBL, ClientDtoBL>>(serviceProvider.GetRequiredService<IUpdater<UpdateClientDtoBL, ClientDtoBL>>));
            services.AddScoped<IRemover<Client>, Remover<Client>>()
                .AddScoped(serviceProvider => new Lazy<IRemover<Client>>(serviceProvider.GetRequiredService<IRemover<Client>>));
            services.AddScoped<IClientFetchersBL, ClientFetchersBL>()
                 .AddScoped(serviceProvider => new Lazy<IClientFetchersBL>(serviceProvider.GetRequiredService<IClientFetchersBL>));
            services.AddScoped<IClientCrudBL, ClientCrudBL>()
                 .AddScoped(serviceProvider => new Lazy<IClientCrudBL>(serviceProvider.GetRequiredService<IClientCrudBL>));

            //ClubCard
            services.AddScoped<IAggregatorClubCardBL, AggregatorClubCardBL>();
            services.AddScoped<IValidator<CreateClubCardDtoBL>, CreateClubCardValidatorBL>();
            services.AddScoped<IValidator<UpdateClubCardDtoBL>, UpdateClubCardValidatorBL>();
            services.AddScoped<IMapper<CreateClubCardDtoBL, ClubCard>, CreateClubCardMapperBL>();
            services.AddScoped<IMapper<ClubCard, ClubCardDtoBL>, ResponseClubCardMapperBL>();
            services.AddScoped<IMapper<UpdateClubCardDtoBL, ClubCard>, UpdateClubCardMapperBL>();

            services.AddScoped<ICreater<CreateClubCardDtoBL, ClubCardDtoBL>, Creater<ClubCard, CreateClubCardDtoBL, ClubCardDtoBL>>()
                 .AddScoped(serviceProvider => new Lazy<ICreater<CreateClubCardDtoBL, ClubCardDtoBL>>(serviceProvider.GetRequiredService<ICreater<CreateClubCardDtoBL, ClubCardDtoBL>>));
            services.AddScoped<IUpdater<UpdateClubCardDtoBL, ClubCardDtoBL>, Updater<ClubCard, UpdateClubCardDtoBL, ClubCardDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IUpdater<UpdateClubCardDtoBL, ClubCardDtoBL>>(serviceProvider.GetRequiredService<IUpdater<UpdateClubCardDtoBL, ClubCardDtoBL>>));
            services.AddScoped<IRemover<ClubCard>, Remover<ClubCard>>()
                .AddScoped(serviceProvider => new Lazy<IRemover<ClubCard>>(serviceProvider.GetRequiredService<IRemover<ClubCard>>));
            services.AddScoped<IClubCardFetchersBL, ClubCardFetchersBL>()
                 .AddScoped(serviceProvider => new Lazy<IClubCardFetchersBL>(serviceProvider.GetRequiredService<IClubCardFetchersBL>));
            services.AddScoped<IClubCardCrudBL, ClubCardCrudBL>()
                 .AddScoped(serviceProvider => new Lazy<IClubCardCrudBL>(serviceProvider.GetRequiredService<IClubCardCrudBL>));

            //Responsible
            services.AddScoped<IAggregatorResponsibleBL, AggregatorResponsibleBL>();
            services.AddScoped<IValidator<CreateResponsibleDtoBL>, CreateResponsibleValidatorBL>();
            services.AddScoped<IValidator<UpdateResponsibleDtoBL>, UpdateResponsibleValidatorBL>();
            services.AddScoped<IMapper<CreateResponsibleDtoBL, Responsible>, CreateResponsibleMapperBL>();
            services.AddScoped<IMapper<Responsible, ResponsibleDtoBL>, ResponseResponsibleMapperBL>();
            services.AddScoped<IMapper<UpdateResponsibleDtoBL, Responsible>, UpdateResponsibleMapperBL>();

            services.AddScoped<ICreater<CreateResponsibleDtoBL, ResponsibleDtoBL>, Creater<Responsible, CreateResponsibleDtoBL, ResponsibleDtoBL>>()
                 .AddScoped(serviceProvider => new Lazy<ICreater<CreateResponsibleDtoBL, ResponsibleDtoBL>>(serviceProvider.GetRequiredService<ICreater<CreateResponsibleDtoBL, ResponsibleDtoBL>>));
            services.AddScoped<IUpdater<UpdateResponsibleDtoBL, ResponsibleDtoBL>, Updater<Responsible, UpdateResponsibleDtoBL, ResponsibleDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IUpdater<UpdateResponsibleDtoBL, ResponsibleDtoBL>>(serviceProvider.GetRequiredService<IUpdater<UpdateResponsibleDtoBL, ResponsibleDtoBL>>));
            services.AddScoped<IRemover<Responsible>, Remover<Responsible>>()
                .AddScoped(serviceProvider => new Lazy<IRemover<Responsible>>(serviceProvider.GetRequiredService<IRemover<Responsible>>));
            services.AddScoped<IResponsibleFetchersBL, ResponsibleFetchersBL>()
                 .AddScoped(serviceProvider => new Lazy<IResponsibleFetchersBL>(serviceProvider.GetRequiredService<IResponsibleFetchersBL>));
            services.AddScoped<IResponsibleCrudBL, ResponsibleCrudBL>()
                 .AddScoped(serviceProvider => new Lazy<IResponsibleCrudBL>(serviceProvider.GetRequiredService<IResponsibleCrudBL>));

            //Trainer
            services.AddScoped<IAggregatorTrainerBL, AggregatorTrainerBL>();
            services.AddScoped<IValidator<CreateTrainerDtoBL>, CreateTrainerValidatorBL>();
            services.AddScoped<IValidator<UpdateTrainerDtoBL>, UpdateTrainerValidatorBL>();
            services.AddScoped<IMapper<CreateTrainerDtoBL, Trainer>, CreateTrainerMapperBL>();
            services.AddScoped<IMapper<Trainer, TrainerDtoBL>, ResponseTrainerMapperBL>();
            services.AddScoped<IMapper<UpdateTrainerDtoBL, Trainer>, UpdateTrainerMapperBL>();

            services.AddScoped<ICreater<CreateTrainerDtoBL, TrainerDtoBL>, Creater<Trainer, CreateTrainerDtoBL, TrainerDtoBL>>()
                 .AddScoped(serviceProvider => new Lazy<ICreater<CreateTrainerDtoBL, TrainerDtoBL>>(serviceProvider.GetRequiredService<ICreater<CreateTrainerDtoBL, TrainerDtoBL>>));
            services.AddScoped<IUpdater<UpdateTrainerDtoBL, TrainerDtoBL>, Updater<Trainer, UpdateTrainerDtoBL, TrainerDtoBL>>()
                .AddScoped(serviceProvider => new Lazy<IUpdater<UpdateTrainerDtoBL, TrainerDtoBL>>(serviceProvider.GetRequiredService<IUpdater<UpdateTrainerDtoBL, TrainerDtoBL>>));
            services.AddScoped<IRemover<Trainer>, Remover<Trainer>>()
                .AddScoped(serviceProvider => new Lazy<IRemover<Trainer>>(serviceProvider.GetRequiredService<IRemover<Trainer>>));
            services.AddScoped<ITrainerFetchersBL, TrainerFetchersBL>()
                 .AddScoped(serviceProvider => new Lazy<ITrainerFetchersBL>(serviceProvider.GetRequiredService<ITrainerFetchersBL>));
            services.AddScoped<ITrainerCrudBL, TrainerCrudBL>()
                 .AddScoped(serviceProvider => new Lazy<ITrainerCrudBL>(serviceProvider.GetRequiredService<ITrainerCrudBL>));
        }
    }
}
