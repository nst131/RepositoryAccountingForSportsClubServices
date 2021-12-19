using System.Threading.Tasks;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;

namespace ServiceAccountingBL.Models.ClubCardBLL.Crud
{
    public interface IClubCardCrudBL
    {
        Task<ClubCardDtoBL> CreateClubCard(CreateClubCardDtoBL createClubCardDtoBL);
        Task DeleteClubCard(int id);
        Task<GetClubCardDtoBL> GetClubCard(int id);
        Task<ClubCardDtoBL> UpdateClubCard(UpdateClubCardDtoBL updateClubCardDtoBL);
    }
}