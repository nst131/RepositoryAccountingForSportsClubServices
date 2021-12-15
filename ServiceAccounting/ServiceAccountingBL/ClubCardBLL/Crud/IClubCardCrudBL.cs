using ServiceAccountingBL.ClubCardBLL.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceAccountingBL.ClubCardBLL.Crud
{
    public interface IClubCardCrudBL
    {
        Task<ClubCardDtoBL> CreateClubCard(CreateClubCardDtoBL createClubCardDtoBL);
        Task DeleteClubCard(int id);
        Task<GetClubCardDtoBL> GetClubCard(int id);
        Task<ICollection<GetClubCardDtoBL>> GetClubCardAll();
        Task<ClubCardDtoBL> UpdateClubCard(UpdateClubCardDtoBL updateClubCardDtoBL);
    }
}