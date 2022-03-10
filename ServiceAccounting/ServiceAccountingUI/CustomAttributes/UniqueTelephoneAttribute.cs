using ServiceAccountingBL.AttributeValidation;
using ServiceAccountingDA.Models;
using ServiceAccountingUI.BaseModels;
using System;
using System.ComponentModel.DataAnnotations;
using ServiceAccountingBL.Exceptions;

namespace ServiceAccountingUI.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class UniqueTelephoneAttribute : ValidationAttribute
    {
        private readonly string role;

        public UniqueTelephoneAttribute(string role)
        {
            this.role = role;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var service = (IUniqueTelephoneBL)validationContext.GetService(typeof(IUniqueTelephoneBL))!;

            if (service is null)
                throw new ElementNullReferenceException($"{nameof(service)} is null check your connection");

            switch (role)
            {
                case Roles.User:
                    if (service.IsUnique<Client>(value as string).Result)
                        return new ValidationResult($"{nameof(Client)} Telephone has existed yet");
                    break;

                case Roles.Trainer:
                    if (service.IsUnique<Trainer>(value as string).Result)
                        return new ValidationResult($"{nameof(Trainer)} Telephone has existed yet");
                    break;

                case Roles.Responsible:
                    if (service.IsUnique<Responsible>(value as string).Result)
                        return new ValidationResult($"{nameof(Responsible)} Telephone has existed yet");
                    break;

                default:
                    return new ValidationResult("The Role is incorrectly specified");
            }

            return null!;
        }
    }
}
