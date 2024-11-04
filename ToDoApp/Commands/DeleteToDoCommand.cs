using MediatR;

namespace ToDoApp.Commands
{
    public class DeleteToDoCommand : IRequest<bool>
    {
        public Guid ID { get; set; }
    }
}
