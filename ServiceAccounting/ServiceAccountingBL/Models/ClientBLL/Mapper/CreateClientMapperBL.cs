using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientBLL.Mapper
{
    public class CreateClientMapperBL : IMapper<CreateClientDtoBL, Client>
    {
        public Client Map(CreateClientDtoBL createClientDtoBL) 
        {
            return new ()
            {
                Name = createClientDtoBL.Name,
                SerName = createClientDtoBL.SerName,
                Telephone = createClientDtoBL.Telephone,
                TypeSexId = createClientDtoBL.TypeSexId
            };
        }
    }
}
