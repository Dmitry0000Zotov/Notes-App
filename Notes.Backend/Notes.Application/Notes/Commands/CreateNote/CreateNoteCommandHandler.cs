using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Notes.Application.Interfaces;
using Notes.Domain;
using System.Text.Json;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Note>
    {
        private readonly INotesDbContext _dbContext;

        public CreateNoteCommandHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Note> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                NoteId = Guid.NewGuid(),
                Title = request.Title,
                Details = request.Details,
                DateNote = request.DateNote ?? null,
                DateCreation = DateTime.Now.ToUniversalTime(),
                DateEdit = null
            };

            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note;
        }
    }
}
