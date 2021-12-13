using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.ClientBLL.Mapper
{
    public static class ClientMapperBL
    {
        public static ClientDtoBL Map<Result>(Client client)
        where Result : ClientDtoBL
        {
            return new ClientDtoBL()
            {
                Id = client.Id,
                Name = client.Name,
                SerName = client.SerName,
            };
        }
    }
}
