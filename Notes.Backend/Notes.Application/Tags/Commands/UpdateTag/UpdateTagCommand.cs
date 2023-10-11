using MediatR;

namespace Notes.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommand : IRequest
    {
        public Guid TagId { get; set; }
        public string Title { get; set; }
    }
}
