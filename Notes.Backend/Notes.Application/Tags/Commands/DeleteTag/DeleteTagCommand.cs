using MediatR;

namespace Notes.Application.Tags.Commands.DeleteTag
{
    public class DeleteTagCommand : IRequest
    {
        public Guid TagId { get; set; }
    }
}
