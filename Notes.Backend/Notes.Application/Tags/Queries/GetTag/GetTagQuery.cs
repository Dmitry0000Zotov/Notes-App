using MediatR;
using Notes.Domain;

namespace Notes.Application.Tags.Queries.GetTag
{
    public class GetTagQuery : IRequest<Tag>
    {
        public Guid TagId { get; set; }
    }
}
