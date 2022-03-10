using System;
using System.ComponentModel.DataAnnotations;
using ServiceAccountingBL.AttributeValidation;
using ServiceAccountingBL.Exceptions;

namespace ServiceAccountingUI.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class CheckClientCardOnExistanceAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not int clientId)
                throw new ElementCannotbeConverted($"Value can not Converted in Int");

            var service = (ICheckClientCardBL)validationContext.GetService(typeof(ICheckClientCardBL))!;

            return service.ExistClientCard(clientId).Result 
                ? new ValidationResult("Client has had ClientCard yet") 
                : null;
        }
    }
}
