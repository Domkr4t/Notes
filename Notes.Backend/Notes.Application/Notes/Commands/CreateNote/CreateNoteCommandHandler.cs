using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INoteDbContext _noteDbContext;

        public CreateNoteCommandHandler(INoteDbContext noteDbContext)
        {
            _noteDbContext = noteDbContext;
        }

        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                CreationDate = DateTime.Now,
            };
;
            await _noteDbContext.Notes.AddAsync(note, cancellationToken);
            await _noteDbContext.SaveChangesAsync(cancellationToken);

            return note.Id;

        }
    }
}
