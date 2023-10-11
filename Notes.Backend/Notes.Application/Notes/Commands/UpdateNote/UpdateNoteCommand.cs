using MediatR;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest<Note>
    {
        public Guid NoteId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime? DateNote { get; set; }
    }
}
