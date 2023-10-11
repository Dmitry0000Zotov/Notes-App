using MediatR;
using Notes.Domain;

namespace Notes.Application.Notices.Commands.CreateNotice
{
    public class CreateNoticeCommand : IRequest<Notice>
    {
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
    }
}
