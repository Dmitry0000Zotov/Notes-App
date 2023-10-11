using MediatR;
using Notes.Domain;

namespace Notes.Application.Tags.Commands.CreateTag
{
    public class CreateTagCommand : IRequest<Tag>
    {
        public string Title { get; set; }
    }
}
