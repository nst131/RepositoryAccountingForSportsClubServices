using ServiceAccountingBL.ResponsibleBLL.Dto;
using ServiceAccountingUI.ResponsibleUI.Dto;
using System.Collections.Generic;

namespace ServiceAccountingUI.ResponsibleUI.Mapper
{
    public static class GetResponsibleMapperUI
    {
        public static GetResponsibleDtoUI Map<Result>(GetResponsibleDtoBL responsible)
                where Result : GetResponsibleDtoUI
        {
            return new GetResponsibleDtoUI()
            {
                Id = responsible.Id,
                Name = responsible.Name,
                SerName = responsible.SerName,
                Telephone = responsible.Telephone,
            };
        }

        public static ICollection<GetResponsibleDtoUI> Map<Result>(ICollection<GetResponsibleDtoBL> responsibles)
                where Result : ICollection<GetResponsibleDtoUI>
        {
            var responsiblesDtoUI = new List<GetResponsibleDtoUI>();

            foreach (var responsible in responsibles)
            {
                responsiblesDtoUI.Add(Map<GetResponsibleDtoUI>(responsible));
            }

            return responsiblesDtoUI;
        }
    }
}
