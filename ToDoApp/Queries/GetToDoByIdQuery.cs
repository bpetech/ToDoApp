using MediatR;
using ToDoApp.Entities.DTOs.Models;

namespace ToDoApp.Queries
{
    public class GetToDoByIdQuery : IRequest<ToDoItem>
    {
        public Guid Id { get; set; }
    }
}

