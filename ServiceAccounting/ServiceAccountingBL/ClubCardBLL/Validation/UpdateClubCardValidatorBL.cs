﻿using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.ClubCardBLL.Dto;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAccountingBL.ClubCardBLL.Validation
{
    public class UpdateClubCardValidatorBL : IClubCardValidator<UpdateClubCardDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public UpdateClubCardValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(UpdateClubCardDtoBL updateClubCardDtoBL)
        {
            if (updateClubCardDtoBL is null)
                throw new ElementNullReferenceException($"{nameof(UpdateClubCardDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<ClubCard>().AsNoTracking().ToList().Exists(x => x.Id == updateClubCardDtoBL.Id)))
                throw new ElementByIdNotFoundException($"{nameof(ClubCard)} by Id not Found");

            if (string.IsNullOrWhiteSpace(updateClubCardDtoBL.Name))
                throw new ElementNotAssignException($"{nameof(UpdateClubCardDtoBL.Name)} is not assigned");

            if (updateClubCardDtoBL.Price < 0)
                throw new ElementOutOfRangeException($"{nameof(UpdateClubCardDtoBL.Price)} can not less 0");

            if (updateClubCardDtoBL.DurationInDays < 0)
                throw new ElementOutOfRangeException($"{nameof(UpdateClubCardDtoBL.DurationInDays)} can not less 0");

            if (await Task.Factory.StartNew(() => !context.Set<Service>().AsNoTracking().ToList().Exists(x => x.Id == updateClubCardDtoBL.ServiceId)))
                throw new ElementByIdNotFoundException($"{nameof(Service)} by Id not Found");
        }
    }
}
