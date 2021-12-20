using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;

namespace ServiceAccountingBL.Models.ClientCardBL.Validation
{
    public class UpdateClientCardValidatorBL : IValidator<AcceptUpdateClientCardDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public UpdateClientCardValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptUpdateClientCardDtoBL dto)
        {
            if (dto is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreateClientCardDtoBL)} is null");

            if(await Task.Factory.StartNew(() => !context.Set<ClientCard>().AsNoTracking().ToList().Exists(x => x.Id == dto.Id)))
                throw new ElementByIdNotFoundException($"{nameof(ClientCard)} by Id not Found");

            if (await Task.Factory.StartNew(() => !context.Set<ClubCard>().AsNoTracking().ToList().Exists(x => x.Id == dto.ClubCardId)))
                throw new ElementByIdNotFoundException($"{nameof(ClubCard)} by Id not Found");

            if (await Task.Factory.StartNew(() => !context.Set<Client>().AsNoTracking().ToList().Exists(x => x.Id == dto.ClientId)))
                throw new ElementByIdNotFoundException($"{nameof(Client)} by Id not Found");
        }
    }
}
