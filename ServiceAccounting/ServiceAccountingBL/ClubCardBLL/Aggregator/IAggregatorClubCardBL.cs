using ServiceAccountingBL.ClubCardBLL.Crud;
using ServiceAccountingBL.ClubCardBLL.Dto;
using ServiceAccountingBL.ClubCardBLL.Validation;

namespace ServiceAccountingBL.ClubCardBLL.Aggregator
{
    public interface IAggregatorClubCardBL
    {
        IClubCardCrudBL ClubCardCrudBL { get; }
        IClubCardValidator<CreateClubCardDtoBL> CreateClubCardValidator { get; }
        IClubCardValidator<UpdateClubCardDtoBL> UpdateClubCardValidator { get; }
    }
}