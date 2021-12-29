using ServiceAccountingBL.AttributeValidation;
using ServiceAccountingDA.Models;
using ServiceAccountingUI.BaseModels;
using System;
using System.ComponentModel.DataAnnotations;
using ServiceAccountingBL.Exceptions;

namespace ServiceAccountingUI.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class UniqueTelephone : ValidationAttribute
    {
        private readonly Role role;

        public UniqueTelephone(Role role)
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
                case Role.Client:
                    if (service.IsUnique<Client>(value as string).Result)
                        return new ValidationResult($"{nameof(Client)} Telephone has existed yet");
                    break;
                case Role.Trainer:
                    if (service.IsUnique<Trainer>(value as string).Result)
                        return new ValidationResult($"{nameof(Trainer)} Telephone has existed yet");
                    break;

                case Role.Responsible:
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
