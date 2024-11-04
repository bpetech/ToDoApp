using MediatR;
using ToDoApp.Commands;
using ToDoApp.Data;
using ToDoApp.Entities.DTOs.Models;

namespace ToDoApp.Entities.DTOs.Handlers
{
    public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand, ToDoItem>
    {
        private readonly ApplicationDbContext _context;

        public UpdateToDoCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ToDoItem> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var existingToDo = await _context.ToDoItems.FindAsync(request.ID);

            if (existingToDo == null)
                return null;

            existingToDo.Title = request.Title;
            existingToDo.Description = request.Description;
            existingToDo.IsCompleted = request.IsCompleted;

            await _context.SaveChangesAsync(cancellationToken);

            return existingToDo;
        }
    }
}
