using System.Threading.Tasks;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClubCardBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClubCardBLL.Mapper
{
    public class ResponseClubCardMapperBL : IMapperAsync<ClubCard, ResponseClubCardDtoBL>
    {
        public async Task<ResponseClubCardDtoBL> Map(ClubCard clubCard)
        {
            return await Task.FromResult(new ResponseClubCardDtoBL()
            {
                Id = clubCard.Id,
                Name = clubCard.Name
            });
        }
    }
}