using ServiceAccountingBL.AdditionalValidation;
using ServiceAccountingDA.Models;
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

            if(role is Role.Client)
            {
                if(service.IsUnique<Client>(value as string).Result)
                {
                    return new ValidationResult($"{nameof(Client.Telephone)} is not valid");
                }
            }

            return null;
        }
    }
}
