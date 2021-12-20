using System.Threading.Tasks;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;

namespace ServiceAccountingBL.Models.ClubCardBLL.Crud
{
    public interface IClubCardCrudBL
    {
        Task<ResponseClubCardDtoBL> CreateClubCard(AcceptCreateClubCardDtoBL createClubCardDtoBL);
        Task DeleteClubCard(int id);
        Task<ResponseGetClubCardDtoBL> GetClubCard(int id);
        Task<ResponseClubCardDtoBL> UpdateClubCard(AcceptUpdateClubCardDtoBL updateClubCardDtoBL);
    }
}