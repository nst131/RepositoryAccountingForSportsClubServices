using ServiceAccountingBL.AttributeValidation;
using ServiceAccountingBL.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ServiceAccountingUI.BaseModels;
using ServiceAccountingUI.Models.DealUI.Dto;

namespace ServiceAccountingUI.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SingleClientCardAndUniqueSubscriptionAttribute : ValidationAttribute
    {
        private int dealId;
        private int clientId;
        private int? clubCardId;
        private int? subscriptionId;
        private readonly Stack<ValidationResult> stack;

        public SingleClientCardAndUniqueSubscriptionAttribute()
        {
            this.stack = new Stack<ValidationResult>();
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                throw new ElementNullReferenceException("Model is null");

            var className = value.GetType().Name;

            if (className is nameof(AcceptUpdateDealDtoUI))
            {
                this.stack.Clear();

                this.Initialization(value, new CheckDealDto()
                {
                    ClientIdName = nameof(AcceptUpdateDealDtoUI.ClientId),
                    ClubCardIdName = nameof(AcceptUpdateDealDtoUI.ClubCardId),
                    DealIdName = nameof(AcceptUpdateDealDtoUI.Id),
                    SubscriptionIdName = nameof(AcceptUpdateDealDtoUI.SubscriptionId)
                });

                if (dealId == -1 || clientId == -1)
                    throw new ElementNullReferenceException(
                        "Do not find necessary properties, likely you are wrong specify them");

                Task.WaitAll(CheckClubCard(validationContext), CheckSubscription(validationContext));

                return this.stack.Count != 0 ? this.stack.Peek() : null;
            }

            if (className is nameof(AcceptCreateDealDtoUI))
            {
                this.stack.Clear();

                this.Initialization(value, new CheckDealDto()
                {
                    ClientIdName = nameof(AcceptCreateDealDtoUI.ClientId),
                    ClubCardIdName = nameof(AcceptCreateDealDtoUI.ClubCardId),
                    DealIdName = "",
                    SubscriptionIdName = nameof(AcceptCreateDealDtoUI.SubscriptionId)
                });

                if (clientId == -1)
                    throw new ElementNullReferenceException(
                        "Do not find necessary properties, likely you are wrong specify them");

                var service = (ICheckCorrectCreateDealBL) validationContext.GetService(typeof(ICheckCorrectCreateDealBL))!;

                return service.ValidateCreateDeal(clientId, clubCardId, subscriptionId).Result;
            }

            return null;
        }

        private void Initialization(object value, CheckDealDto dealDto)
        {
            this.dealId = (int) (value.GetType().GetProperty(dealDto.DealIdName)?.GetValue(value) ?? -1);
            this.clientId = (int) (value.GetType().GetProperty(dealDto.ClientIdName)?.GetValue(value) ?? -1);

            var propertyInfoClubCardId = value.GetType().GetProperty(dealDto.ClubCardIdName)?.GetValue(value);
            var propertyInfoSubscriptionId = value.GetType().GetProperty(dealDto.SubscriptionIdName)?.GetValue(value);

            this.clubCardId = (int?) propertyInfoClubCardId;
            this.subscriptionId = (int?) propertyInfoSubscriptionId;
        }

        private Task CheckClubCard(IServiceProvider provider)
        {
            var service = (ICheckSingleClubCardBL) provider.GetService(typeof(ICheckSingleClubCardBL))!;

            if (service.HasClientHaveClubCard(dealId, clientId, clubCardId).Result)
                this.stack.Push(new ValidationResult("Client has have ClubCard yet"));

            return Task.CompletedTask;
        }

        private Task CheckSubscription(IServiceProvider provider)
        {
            var service = (IUniqueSubscriptionBL) provider.GetService(typeof(IUniqueSubscriptionBL))!;

            if (service.HasClientHaveSubscription(dealId, clientId, subscriptionId).Result)
                this.stack.Push(new ValidationResult("Client has have the same Subscription yet"));

            return Task.CompletedTask;
        }
    }
}
