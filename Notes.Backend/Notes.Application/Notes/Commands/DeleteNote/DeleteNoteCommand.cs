using MediatR;

namespace Notes.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommand : IRequest
    {
        public Guid NoteId { get; set; }
    }
}
