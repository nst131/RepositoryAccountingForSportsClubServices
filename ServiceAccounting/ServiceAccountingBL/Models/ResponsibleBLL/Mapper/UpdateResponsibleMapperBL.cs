using System.Linq;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Mapper
{
    public class UpdateResponsibleMapperBL : IMapper<AcceptUpdateResponsibleDtoBL, Responsible>
    {
        private readonly IServiceAccountingContext context;

        public UpdateResponsibleMapperBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public Responsible Map(AcceptUpdateResponsibleDtoBL updateResponsibleDtoBL)
        {
            var email = context.Set<Responsible>()
                .AsNoTracking()
                .Where(x => x.Id == updateResponsibleDtoBL.Id)
                .Select(x => x.Email).FirstOrDefaultAsync().Result;

            return new ()
            {
                Id = updateResponsibleDtoBL.Id,
                Name = updateResponsibleDtoBL.Name,
                SerName = updateResponsibleDtoBL.SerName,
                Telephone = updateResponsibleDtoBL.Telephone,
                Email = email
            };
        }
    }
}
