using ServiceAccountingBL.ResponsibleBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.ResponsibleBLL.Mapper
{
    public static class ResponsibleMapperBL
    {
        public static ResponsibleDtoBL Map<Result>(Responsible responsible)
            where Result : ResponsibleDtoBL
        {
            return new ResponsibleDtoBL()
            {
                Id = responsible.Id,
                Name = responsible.Name,
                SerName = responsible.SerName,
            };
        }
    }
}
