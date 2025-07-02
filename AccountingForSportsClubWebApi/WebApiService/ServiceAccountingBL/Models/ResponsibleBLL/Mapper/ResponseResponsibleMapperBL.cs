using System.Threading.Tasks;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Mapper
{
    public class ResponseResponsibleMapperBL : IMapperAsync<Responsible, ResponseResponsibleDtoBL>
    {
        public async Task<ResponseResponsibleDtoBL> Map(Responsible responsible)
        {
            return await Task.FromResult(new ResponseResponsibleDtoBL()
            {
                Id = responsible.Id,
                Name = responsible.Name
            });
        }
    }
}
