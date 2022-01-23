using System.Threading.Tasks;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientBLL.Mapper
{
    public class ResponseClientMapperBL : IMapperAsync<Client, ResponseClientDtoBL>
    {
        public async Task<ResponseClientDtoBL> Map(Client client)
        {
            return await Task.FromResult(new ResponseClientDtoBL()
            {
                Id = client.Id,
                Name = client.Name,
            });
        }
    }
}
