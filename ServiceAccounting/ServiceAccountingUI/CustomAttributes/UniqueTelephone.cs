using ServiceAccountingBL.AttributeValidation;
using ServiceAccountingDA.Models;
using ServiceAccountingUI.BaseModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceAccountingUI.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class UniqueTelephone : ValidationAttribute
    {
        private readonly Role role;

        public UniqueTelephone(Role role)
        {
            this.role = role;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var service = (IUniqueTelephoneBL)validationContext.GetService(typeof(IUniqueTelephoneBL));

            switch (role)
            {
                case Role.Client:
                    if (service != null && service.IsUnique<Client>(value as string).Result)
                        return new ValidationResult($"{nameof(Client)} Telephone has existed yet");
                    break;
                case Role.Trainer:
                    if (service != null && service.IsUnique<Trainer>(value as string).Result)
                        return new ValidationResult($"{nameof(Trainer)} Telephone has existed yet");
                    break;

                case Role.Responsible:
                    if (service != null && service.IsUnique<Responsible>(value as string).Result)
                        return new ValidationResult($"{nameof(Responsible)} Telephone has existed yet");
                    break;

                default:
                    return new ValidationResult("The Role is incorrectly specified");
            }

            return null;
        }
    }
}
