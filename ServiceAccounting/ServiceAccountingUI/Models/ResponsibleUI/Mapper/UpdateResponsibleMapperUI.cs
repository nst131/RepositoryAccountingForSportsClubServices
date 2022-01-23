using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingUI.Models.ResponsibleUI.Dto;

namespace ServiceAccountingUI.Models.ResponsibleUI.Mapper
{
    public static class UpdateResponsibleMapperUI
    {
        public static AcceptUpdateResponsibleDtoBL Map<Result>(AcceptUpdateResponsibleDtoUI responsible)
            where Result : AcceptUpdateResponsibleDtoBL
        {
            return new ()
            {
                Id = responsible.Id,
                Name = responsible.Name,
                SerName = responsible.SerName,
                Telephone = responsible.Telephone,
            };
        }

        public static ResponseResponsibleDtoUI Map<Result>(ResponseResponsibleDtoBL responsible)
            where Result : ResponseResponsibleDtoUI
        {
            return new ()
            {
                Id = responsible.Id,
                Name = responsible.Name
            };
        }
    }
}
