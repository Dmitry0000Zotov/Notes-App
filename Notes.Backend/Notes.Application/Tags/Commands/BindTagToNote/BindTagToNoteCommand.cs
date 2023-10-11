using MediatR;
using Notes.Domain;
using System.Text.Json.Serialization;

namespace Notes.Application.Tags.Commands.BindTagToNote
{
    public class BindTagToNoteCommand : IRequest
    {
        public Guid NoteId { get; set; }
        public List<Guid> Tags { get; set; }
    }
}
