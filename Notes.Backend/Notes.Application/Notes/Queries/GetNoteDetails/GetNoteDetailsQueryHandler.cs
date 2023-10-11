using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, Note>
    {
        private readonly INotesDbContext _dbContext;
        public GetNoteDetailsQueryHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Note> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.NoteId == request.NoteId, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Note), request.NoteId);
            }

            return entity;
        }
    }
}
