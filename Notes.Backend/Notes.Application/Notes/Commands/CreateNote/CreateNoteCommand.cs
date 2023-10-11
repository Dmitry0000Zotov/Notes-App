using MediatR;
using Notes.Application.Tags.Queries.GetTagList;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<Note>
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime? DateNote { get; set; }
    }
}
