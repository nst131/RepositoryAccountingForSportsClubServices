using ServiceAccountingBL.AttributeValidation;
using ServiceAccountingBL.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class CheckClientsOnAccordingClubCardAttribute : ValidationAttribute
    {
        private readonly string clientsIdNameOf;
        private readonly string serviceIdNameOf;
        private readonly Stack<ValidationResult> stack;

        public CheckClientsOnAccordingClubCardAttribute(string clientsIdNameOf, string serviceIdNameOf)
        {
            this.clientsIdNameOf = clientsIdNameOf;
            this.serviceIdNameOf = serviceIdNameOf;
            this.stack = new Stack<ValidationResult>();
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return null;

            var clientsIdProperty = value.GetType().GetProperty(this.clientsIdNameOf)?.GetValue(value);
            var serviceIdPropert = value.GetType().GetProperty(this.serviceIdNameOf)?.GetValue(value);

            var clientsId = (ICollection<int>?)clientsIdProperty;
            var serviceId = (int?)serviceIdPropert;

            if (clientsId is null || serviceId is null)
                throw new ElementNullReferenceException("ClientsId or ServiceId is null");

            if (clientsId.Count == 0)
                return new ValidationResult("You didn't select the clients");

            var service = (ICheckClientsOnAccordingClubCardBL)validationContext.GetService(typeof(ICheckClientsOnAccordingClubCardBL))!;
            this.stack.Clear();

            foreach (var clientId in clientsId)
            {
                var result = service.CheckClientCardOnAccordanceService(serviceId ?? default, clientId).Result;

                if (result is not null)
                    this.stack.Push(result);
            }

            return stack.Count != 0 ? this.stack.Peek() : null;
        }
    }
}
