using Application.User.CrudOperation;
using Models;
using RabbitMQLibrary;
using System.Threading.Tasks;

namespace API.EventsFromRabbitMQ
{
    public class DeleteUserOnAuthEvent : IIntegrationHandler<DeleteUserModel>
    {
        private readonly ICrudHandler crudHandler;

        public DeleteUserOnAuthEvent(ICrudHandler crudHandler)
        {
            this.crudHandler = crudHandler;
        }

        public async Task Handle(DeleteUserModel user)
        {
            await crudHandler.DeleteUser(user.Email);
        }
    }
}
