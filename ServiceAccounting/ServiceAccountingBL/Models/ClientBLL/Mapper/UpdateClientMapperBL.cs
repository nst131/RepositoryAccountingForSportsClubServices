using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientBLL.Mapper
{
    public class UpdateClientMapperBL : IMapper< UpdateClientDtoBL, Client>
    {
        public Client Map(UpdateClientDtoBL updateClientDtoBL)
        {
            return new ()
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
