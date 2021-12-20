using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Mapper
{
    public class UpdateResponsibleMapperBL : IMapper<AcceptUpdateResponsibleDtoBL, Responsible>
    {
        public Responsible Map(AcceptUpdateResponsibleDtoBL updateResponsibleDtoBL)
        {
            return new ()
            {
                Id = updateResponsibleDtoBL.Id,
                Name = updateResponsibleDtoBL.Name,
                SerName = updateResponsibleDtoBL.SerName,
                Telephone = updateResponsibleDtoBL.Telephone,
            };
        }
    }
}
