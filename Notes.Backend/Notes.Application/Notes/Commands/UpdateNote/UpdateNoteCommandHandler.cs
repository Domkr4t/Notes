using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Note>
    {
        private readonly INoteDbContext _noteDbContext;

        public UpdateNoteCommandHandler(INoteDbContext noteDbContext)
        {
            _noteDbContext = noteDbContext;
        }

        public async Task<Note> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _noteDbContext.Notes
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (note == null || note.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            note.Title = request.Title;
            note.Details = request.Details;
            note.ModifiedDate = DateTime.Now;

            _noteDbContext.Notes.Update(note);
            await _noteDbContext.SaveChangesAsync(cancellationToken);

            return note;
        }
    }
}
