using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.ClientBLL.Mapper
{
    public static class UpdateClientMapperBL
    {
        public static Client Map<Result>(UpdateClientDtoBL updateClientDtoBL)
                where Result : Client
        {
            return new Client()
            {
                Id = updateClientDtoBL.Id,
                Name = updateClientDtoBL.Name,
                SerName = updateClientDtoBL.SerName,
                Telephone = updateClientDtoBL.Telephone,
                TypeSexId = updateClientDtoBL.TypeSexId
            };
        }
    }
}
