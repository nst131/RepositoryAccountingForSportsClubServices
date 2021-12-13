using ServiceAccountingBL.ClientBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.ClientBLL.Mapper
{
    public static class CreateClientMapperBL
    {
        public static Client Map<Result>(CreateClientDtoBL createClientDtoBL)
            where Result : Client
        {
            return new Client()
            {
                Name = createClientDtoBL.Name,
                SerName = createClientDtoBL.SerName,
                Telephone = createClientDtoBL.Telephone,
                TypeSexId = createClientDtoBL.TypeSexId
            };
        }
    }
}
