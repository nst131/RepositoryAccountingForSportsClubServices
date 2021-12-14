using ServiceAccountingBL.ResponsibleBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.ResponsibleBLL.Mapper
{
    public static class CreateResponsibleMapperBL
    {
        public static Responsible Map<Result>(CreateResponsibleDtoBL createResponsibleDtoBL)
            where Result : Responsible
        {
            return new Responsible()
            {
                Name = createResponsibleDtoBL.Name,
                SerName = createResponsibleDtoBL.SerName,
                Telephone = createResponsibleDtoBL.Telephone,
            };
        }
    }
}
