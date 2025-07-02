using Microsoft.EntityFrameworkCore;
using ServiceAccountingBL.Exceptions;
using ServiceAccountingBL.Interfaces;
using ServiceAccountingBL.Models.ClientCardBL.Dto;
using ServiceAccountingDA.Context;
using ServiceAccountingDA.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAccountingBL.Models.ClientCardBL.Validation
{
    public class CreateClientCardValidatorBL : IValidator<AcceptCreateClientCardDtoBL>
    {
        public readonly IServiceAccountingContext context;

        public CreateClientCardValidatorBL(IServiceAccountingContext context)
        {
            this.context = context;
        }

        public async Task Validate(AcceptCreateClientCardDtoBL dto)
        {
            if (dto is null)
                throw new ElementNullReferenceException($"{nameof(AcceptCreateClientCardDtoBL)} is null");

            if (await Task.Factory.StartNew(() => !context.Set<ClubCard>().AsNoTracking().ToList().Exists(x => x.Id == dto.ClubCardId)))
                throw new ElementByIdNotFoundException($"{nameof(ClubCard)} by Id not Found");

            // ClientCard will add on business level
            var client = await context.Set<Client>().Include(x => x.ClientCard).AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.ClientId);
            if (client is null)
                throw new ElementByIdNotFoundException($"{nameof(Client)} by Id not Found");
            if (client.ClientCard is not null)
                throw new ElementBindOneToOneException($"{nameof(Client)} has had {nameof(ClientCard)} yet");
        }
    }
}
