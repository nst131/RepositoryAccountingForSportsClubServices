using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Models.ResponsibleBLL.Dto;
using ServiceAccountingBL.Models.ResponsibleBLL.Mapper;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ResponsibleBLL.Fetchers
{
    public class ResponsibleFetchersBL : IResponsibleFetchersBL
    {
        private readonly IServiceAccountingContext context;

        public ResponsibleFetchersBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<GetResponsibleDtoBL>> GetResponsibleAll()
        {
            if (!await context.Set<Responsible>().AnyAsync())
                return new List<GetResponsibleDtoBL>();

            var allResponsibles = await context.Set<Responsible>().ToListAsync();

            return ReadResponsibleMapperBL.Map<ICollection<GetResponsibleDtoBL>>(allResponsibles);

        }
    }
}
