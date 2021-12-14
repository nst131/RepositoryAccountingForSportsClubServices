using ServiceAccountingBL.ResponsibleBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.ResponsibleBLL.Mapper
{
    public static class UpdateResponsibleMapperBL
    {
        public static Responsible Map<Result>(UpdateResponsibleDtoBL updateResponsibleDtoBL)
        where Result : Responsible
        {
            return new Responsible()
            {
                Id = updateResponsibleDtoBL.Id,
                Name = updateResponsibleDtoBL.Name,
                SerName = updateResponsibleDtoBL.SerName,
                Telephone = updateResponsibleDtoBL.Telephone,
            };
        }
    }
}
