using MediatR;
using ToDoApp.Data;
using ToDoApp.Entities.DTOs.Models;
using ToDoApp.Queries;

public class GetToDoByIdQueryHandler : IRequestHandler<GetToDoByIdQuery, ToDoItem>
{
    private readonly ApplicationDbContext _context;

    public GetToDoByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ToDoItem> Handle(GetToDoByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.ToDoItems.FindAsync(request.Id); 
    }
}
