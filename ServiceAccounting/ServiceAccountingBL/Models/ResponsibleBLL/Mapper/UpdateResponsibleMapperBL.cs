using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Mapper
{
    public class UpdateResponsibleMapperBL : IMapper<UpdateResponsibleDtoBL, Responsible>
    {
        public Responsible Map(UpdateResponsibleDtoBL updateResponsibleDtoBL)
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
