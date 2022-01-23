using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientBLL.Mapper
{
    public class UpdateClientMapperBL : IMapper< AcceptUpdateClientDtoBL, Client>
    {
        public Client Map(AcceptUpdateClientDtoBL updateClientDtoBL)
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
