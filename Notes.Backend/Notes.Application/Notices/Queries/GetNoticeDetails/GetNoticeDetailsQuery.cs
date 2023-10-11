using MediatR;
using Notes.Domain;

namespace Notes.Application.Notices.Queries.GetNoticeDetails
{
    public class GetNoticeDetailsQuery : IRequest<Notice>
    {
        public Guid NoticeId { get; set; }
    }
}
