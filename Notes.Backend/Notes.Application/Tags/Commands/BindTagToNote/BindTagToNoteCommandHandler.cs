using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Tags.Commands.BindTagToNote
{
    public class BindTagToNoteCommandHandler : IRequestHandler<BindTagToNoteCommand>
    {
        private readonly INotesDbContext _context;

        public BindTagToNoteCommandHandler(INotesDbContext context) => _context = context;

        public async Task Handle(BindTagToNoteCommand request, CancellationToken cancellationToken)
        {
            var note = await _context.Notes.Include(n=>n.Tags).FirstOrDefaultAsync(note => note.NoteId == request.NoteId, cancellationToken);
            if (note == null)
            {
                throw new NotFoundException(nameof(Note), request.NoteId);
            }

            if (note != null)
            {
                var newTagIds = request.Tags.ToList();

                foreach (var tag in note.Tags.ToList())
                {
                    if (!newTagIds.Contains(tag.TagId))
                    {
                        note.Tags.Remove(tag);
                    }
                    else
                    {
                        newTagIds.Remove(tag.TagId);
                    }
                }

                foreach (var tagId in newTagIds)
                {
                    var tagToAdd = await _context.Tags.FirstOrDefaultAsync(tag => tag.TagId == tagId);
                    if (tagToAdd != null)
                    {
                        note.Tags.Add(tagToAdd);
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
