using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INoteDbContext _noteDbContext;

        public DeleteNoteCommandHandler(INoteDbContext noteDbContext)
        {
            _noteDbContext = noteDbContext;
        }

        public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _noteDbContext.Notes.FindAsync([request.Id], cancellationToken);

            if (note == null || note?.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            _noteDbContext.Notes.Remove(note);
            await _noteDbContext.SaveChangesAsync(cancellationToken);  
            
        }
    }
}
