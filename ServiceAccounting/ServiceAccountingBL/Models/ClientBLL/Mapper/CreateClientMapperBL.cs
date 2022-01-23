using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientBLL.Mapper
{
    public class CreateClientMapperBL : IMapper<AcceptCreateClientDtoBL, Client>
    {
        public Client Map(AcceptCreateClientDtoBL createClientDtoBL)
        {
            return new()
            {
                Name = createClientDtoBL.Name,
                Email = createClientDtoBL.Email,
                SerName = string.Empty,
                Telephone = string.Empty,
                TypeSexId = TypeOfSex.NoGender.Id
            };
        }
    }
}