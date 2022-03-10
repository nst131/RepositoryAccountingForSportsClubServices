using ServiceAccountingBL.AttributeValidation;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingDA.Models;
using ServiceAccountingUI.BaseModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class UniqueEmailAttribute : ValidationAttribute
    {
        private readonly string role;

        public UniqueEmailAttribute(string role)
        {
            this.role = role;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var service = (IUniqueEmailBL)validationContext.GetService(typeof(IUniqueEmailBL))!;

            if (service is null)
                throw new ElementNullReferenceException($"{nameof(service)} is null check your connection");

            switch (role)
            {
                case Roles.User:
                    if (service.IsUnique<Client>(value as string).Result)
                        return new ValidationResult($"{nameof(Client)} Email has existed yet");
                    break;

                case Roles.Trainer:
                    if (service.IsUnique<Trainer>(value as string).Result)
                        return new ValidationResult($"{nameof(Trainer)} Email has existed yet");
                    break;

                case Roles.Responsible:
                    if (service.IsUnique<Responsible>(value as string).Result)
                        return new ValidationResult($"{nameof(Responsible)} Email has existed yet");
                    break;

                default:
                    return new ValidationResult("The Role is incorrectly specified");
            }

            return null!;
        }
    }
}
