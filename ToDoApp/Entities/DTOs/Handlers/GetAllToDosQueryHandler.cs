using MediatR;
using ToDoApp.Data;
using ToDoApp.Queries;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Entities.DTOs.Models;

namespace ToDoApp.Entities.DTOs.Handlers
{
    public class GetAllToDosQueryHandler : IRequestHandler<GetAllToDosQuery, IEnumerable<ToDoItem>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllToDosQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoItem>> Handle(GetAllToDosQuery request, CancellationToken cancellationToken)
        {
            return await _context.ToDoItems.ToListAsync(cancellationToken);
        }
    }
}
