using MediatR;
using System.Collections.Generic;
using ToDoApp.Entities.DTOs.Models;

namespace ToDoApp.Queries
{
    public class GetAllToDosQuery : IRequest<IEnumerable<ToDoItem>>
    {
    }
}
