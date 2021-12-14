using Microsoft.Extensions.DependencyInjection;
using ServiceAccountingBL.ClientBLL.Aggregator;
using ServiceAccountingBL.ClientBLL.Crud;
using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingBL.ClientBLL.Validation;
using ServiceAccountingBL.ResponsibleBLL.Aggregator;
using ServiceAccountingBL.ResponsibleBLL.Crud;
using ServiceAccountingBL.ResponsibleBLL.Dto;
using ServiceAccountingBL.ResponsibleBLL.Validation;
using ServiceAccountingBL.TrainerBLL.Aggregator;
using ServiceAccountingBL.TrainerBLL.Crud;
using ServiceAccountingBL.TrainerBLL.Dto;
using ServiceAccountingBL.TrainerBLL.Validation;
using System;

namespace ServiceAccountingBL
{
    public static class ServiceRegistrationBL
    {
        public static void RegistrationBL(this IServiceCollection services)
        {
            //Client
            services.AddScoped<IAggregatorClientBL, AggregatorClientBL>();
            services.AddScoped<IClientCrudBL, ClientCrudBL>()
                 .AddScoped(serviceProvider => new Lazy<IClientCrudBL>(() => serviceProvider.GetRequiredService<IClientCrudBL>()));
            services.AddScoped<IClientValidator<CreateClientDtoBL>, CreateClientValidatorBL>()
                .AddScoped(serviceProvider => new Lazy<IClientValidator<CreateClientDtoBL>>(() => serviceProvider.GetRequiredService<IClientValidator<CreateClientDtoBL>>()));
            services.AddScoped<IClientValidator<UpdateClientDtoBL>, UpdateClientValidatorBL>()
                .AddScoped(serviceProvider => new Lazy<IClientValidator<UpdateClientDtoBL>>(() => serviceProvider.GetRequiredService<IClientValidator<UpdateClientDtoBL>>()));

            //Trainer
            services.AddScoped<IAggregatorTrainerBL, AggregatorTrainerBL>();
            services.AddScoped<ITrainerCrudBL, TrainerCrudBL>()
                 .AddScoped(serviceProvider => new Lazy<ITrainerCrudBL>(() => serviceProvider.GetRequiredService<ITrainerCrudBL>()));
            services.AddScoped<ITrainerValidator<CreateTrainerDtoBL>, CreateTrainerValidatorBL>()
                .AddScoped(serviceProvider => new Lazy<ITrainerValidator<CreateTrainerDtoBL>>(() => serviceProvider.GetRequiredService<ITrainerValidator<CreateTrainerDtoBL>>()));
            services.AddScoped<ITrainerValidator<UpdateTrainerDtoBL>, UpdateTrainerValidatorBL>()
                .AddScoped(serviceProvider => new Lazy<ITrainerValidator<UpdateTrainerDtoBL>>(() => serviceProvider.GetRequiredService<ITrainerValidator<UpdateTrainerDtoBL>>()));

            //Responsible
            services.AddScoped<IAggregatorResponsibleBL, AggregatorResponsibleBL>();
            services.AddScoped<IResponsibleCrudBL, ResponsibleCrudBL>()
                 .AddScoped(serviceProvider => new Lazy<IResponsibleCrudBL>(() => serviceProvider.GetRequiredService<IResponsibleCrudBL>()));
            services.AddScoped<IResponsibleValidator<CreateResponsibleDtoBL>, CreateResponsibleValidatorBL>()
                .AddScoped(serviceProvider => new Lazy<IResponsibleValidator<CreateResponsibleDtoBL>>(() => serviceProvider.GetRequiredService<IResponsibleValidator<CreateResponsibleDtoBL>>()));
            services.AddScoped<IResponsibleValidator<UpdateResponsibleDtoBL>, UpdateResponsibleValidatorBL>()
                .AddScoped(serviceProvider => new Lazy<IResponsibleValidator<UpdateResponsibleDtoBL>>(() => serviceProvider.GetRequiredService<IResponsibleValidator<UpdateResponsibleDtoBL>>()));
        }
    }
}
