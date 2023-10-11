using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Note>
    {
        private readonly INotesDbContext _dbContext;
        public UpdateNoteCommandHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Note> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.NoteId == request.NoteId, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Note), request.NoteId);
            }
            entity.Title = request.Title;
            entity.Details = request.Details;
            entity.DateEdit = DateTime.Now.ToUniversalTime();
            if (request.DateNote.HasValue)
            {
                entity.DateNote = request.DateNote.Value.ToUniversalTime();
            }
            else
            {
                entity.DateNote = null;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
