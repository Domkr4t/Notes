﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly INoteDbContext _noteDbContext;
        private readonly IMapper _mapper;

        public GetNoteDetailsQueryHandler(INoteDbContext noteDbContext, IMapper mapper)
        {
            _noteDbContext = noteDbContext;
            _mapper = mapper;
        }

        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var note = await _noteDbContext.Notes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (note == null && note?.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            return _mapper.Map<NoteDetailsVm>(note);
        }
    }
}
