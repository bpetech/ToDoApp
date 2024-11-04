using MediatR;
using ToDoApp.Entities.DTOs.Models;

namespace ToDoApp.Commands
{
    public class CreateToDoCommand : IRequest<ToDoItem>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
