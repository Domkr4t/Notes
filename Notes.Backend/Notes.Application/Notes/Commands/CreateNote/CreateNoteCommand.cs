﻿using MediatR;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public string Title { get; set; } = default!;

        public string Details { get; set; } = default!;
    }
}
