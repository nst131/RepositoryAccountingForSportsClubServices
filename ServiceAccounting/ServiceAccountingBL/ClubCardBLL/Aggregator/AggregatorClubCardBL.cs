using ServiceAccountingBL.ClubCardBLL.Crud;
using ServiceAccountingBL.ClubCardBLL.Dto;
using ServiceAccountingBL.ClubCardBLL.Validation;
using System;

namespace ServiceAccountingBL.ClubCardBLL.Aggregator
{
    public class AggregatorClubCardBL : IAggregatorClubCardBL
    {
        private readonly Lazy<IClubCardCrudBL> clubCardCrudBL;
        private readonly Lazy<IClubCardValidator<CreateClubCardDtoBL>> createClubCardValidator;
        private readonly Lazy<IClubCardValidator<UpdateClubCardDtoBL>> updateClubCardValidator;

        public AggregatorClubCardBL(Lazy<IClubCardCrudBL> clubCardCrudBL,
            Lazy<IClubCardValidator<CreateClubCardDtoBL>> createClubCardValidator,
            Lazy<IClubCardValidator<UpdateClubCardDtoBL>> updateClubCardValidator)
        {
            this.clubCardCrudBL = clubCardCrudBL;
            this.createClubCardValidator = createClubCardValidator;
            this.updateClubCardValidator = updateClubCardValidator;
        }

        public IClubCardCrudBL ClubCardCrudBL => clubCardCrudBL.Value;
        public IClubCardValidator<CreateClubCardDtoBL> CreateClubCardValidator => createClubCardValidator.Value;
        public IClubCardValidator<UpdateClubCardDtoBL> UpdateClubCardValidator => updateClubCardValidator.Value;
    }
}
