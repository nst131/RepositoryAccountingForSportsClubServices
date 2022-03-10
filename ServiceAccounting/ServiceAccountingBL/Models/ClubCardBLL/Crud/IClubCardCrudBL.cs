using System.Threading;
using System.Threading.Tasks;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;

namespace ServiceAccountingBL.Models.ClubCardBLL.Crud
{
    public interface IClubCardCrudBL
    {
        Task<ResponseClubCardDtoBL> CreateClubCard(AcceptCreateClubCardDtoBL createClubCardDtoBL, CancellationToken token = default);
        Task DeleteClubCard(int id, CancellationToken token = default);
        Task<ResponseGetClubCardDtoBL> GetClubCard(int id, CancellationToken token = default);
        Task<ResponseClubCardDtoBL> UpdateClubCard(AcceptUpdateClubCardDtoBL updateClubCardDtoBL, CancellationToken token = default);
    }
}