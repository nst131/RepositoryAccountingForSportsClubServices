using ServiceAccountingBL.AttributeValidation;
using ServiceAccountingBL.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class CheckServiceByTrainerAttribute : ValidationAttribute
    {
        private readonly string serviceId;
        private readonly string trainerId;

        public CheckServiceByTrainerAttribute(string trainerId, string serviceId)
        {
            this.trainerId = trainerId;
            this.serviceId = serviceId;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return null;

            var serviceIdField = (int)(value?.GetType().GetProperty(this.serviceId)?.GetValue(value) ?? -1);
            var trainerIdField = (int)(value?.GetType().GetProperty(this.trainerId)?.GetValue(value) ?? -1);

            if (serviceIdField == -1 || trainerIdField == -1)
                throw new ElementNullReferenceException("Do not find necessary properties, likely you are wrong specify them");

            var service = (ICheckServiceByTrainerBL)validationContext.GetService(typeof(ICheckServiceByTrainerBL))!;

            return !service.IsSameService(serviceIdField, trainerIdField).Result
                ? new ValidationResult("Trainer can not specify this training, no necessary Service for trainer")
                : null;
        }
    }
}
