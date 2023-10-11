using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Tags.Commands.BindTagToNotice
{
    public class BindTagToNoticeCommand : IRequest
    {
        public Guid NoticeId { get; set; }
        public List<Guid> Tags { get; set; }
    }
}
