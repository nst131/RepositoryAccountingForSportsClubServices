using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.VisitBLL.Dto;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.VisitBLL.Mapper
{
    public class UpdateVisitMapperBL : IMapper<AcceptUpdateVisitDtoBL, Visit>
    {
        public Visit Map(AcceptUpdateVisitDtoBL dto)
        {
            return new()
            {
                Id = dto.Id,
                Arrival = dto.Arrival,
                ServiceId = dto.ServiceId,
                ClientId = dto.ClientId
            };
        }
    }
}