using MediatR;
using ToDoApp.Commands;
using ToDoApp.Data;
using ToDoApp.Entities.DTOs.Models;

namespace ToDoApp.Entities.DTOs.Handlers
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand, ToDoItem>
    {
        private readonly ApplicationDbContext _context;

        public CreateToDoCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ToDoItem> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var newToDo = new ToDoItem
            {
                Title = request.Title,
                Description = request.Description,
                IsCompleted = request.IsCompleted,
                CreatedAt = DateTime.UtcNow
            };

            _context.ToDoItems.Add(newToDo);
            await _context.SaveChangesAsync(cancellationToken);

            return newToDo;
        }
    }
}
