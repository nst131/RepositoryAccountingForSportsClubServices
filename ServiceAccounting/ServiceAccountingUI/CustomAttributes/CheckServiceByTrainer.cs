using System;
using System.ComponentModel.DataAnnotations;
using ServiceAccountingBL.AttributeValidation;
using ServiceAccountingBL.Exceptions;

namespace ServiceAccountingUI.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class CheckServiceByTrainer : ValidationAttribute
    {
        private readonly string serviceId;
        private readonly string trainerId;

        public CheckServiceByTrainer(string serviceIdName, string trainerIdName)
        {
            this.serviceId = serviceIdName;
            this.trainerId = trainerIdName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var serviceIdField = (int)(value?.GetType().GetProperty(serviceId)?.GetValue(value) ?? -1);
            var trainerIdField = (int)(value?.GetType().GetProperty(trainerId)?.GetValue(value) ?? -1);

            if (serviceIdField == -1 || trainerIdField == -1)
                throw new ElementNullReferenceException("Do not find necessary properties, likely you are wrong specify them");

            var service = (ICheckServiceByTrainerBL)validationContext.GetService(typeof(ICheckServiceByTrainerBL))!;

            return !service.IsSameService(serviceIdField, trainerIdField).Result
                ? new ValidationResult("Trainer can not specify this training, no necessary Service for trainer")
                : null;
        }
    }
}
