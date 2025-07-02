using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public async Task<ICollection<ResponseGetResponsibleDtoBL>> GetResponsibleAll(CancellationToken token = default)
        {
            if (!await context.Set<Responsible>().AnyAsync(token))
                return new List<ResponseGetResponsibleDtoBL>();

            var allResponsibles = await context.Set<Responsible>().ToListAsync(token);

            return ReadResponsibleMapperBL.Map<ICollection<ResponseGetResponsibleDtoBL>>(allResponsibles);
        }
    }
}
