using System;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Mapper
{
    public class CreateResponsibleMapperBL : IMapper<AcceptCreateResponsibleDtoBL, Responsible>
    {
        public Responsible Map(AcceptCreateResponsibleDtoBL createResponsibleDtoBL)
        {
            return new ()
            {
                Name = createResponsibleDtoBL.Name,
                Email = createResponsibleDtoBL.Email,
                SerName = String.Empty,
                Telephone = String.Empty
            };
        }
    }
}
