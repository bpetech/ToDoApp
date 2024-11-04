using MediatR;
using ToDoApp.Entities.DTOs.Models;

namespace ToDoApp.Commands
{
    public class UpdateToDoCommand : IRequest<ToDoItem>
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
