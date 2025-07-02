using System.Threading.Tasks;

namespace ServiceAccountingBL.Interfaces
{
    public interface IValidator<Entity>
        where Entity: class
    {
        Task Validate(Entity dto);
    }
}
