using MediatR;
using ToDoApp.Commands;
using ToDoApp.Data;

namespace ToDoApp.Entities.DTOs.Handlers
{
    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteToDoCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            var toDo = await _context.ToDoItems.FindAsync(request.ID);

            if (toDo == null)
                return false;

            _context.ToDoItems.Remove(toDo);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
