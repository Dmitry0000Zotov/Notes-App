using MediatR;
using Notes.Domain;

namespace Notes.Application.Notices.Commands.UpdateNotice
{
    public class UpdateNoticeCommand : IRequest<Notice>
    {
        public Guid NoticeId { get; set; }
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
    }
}
