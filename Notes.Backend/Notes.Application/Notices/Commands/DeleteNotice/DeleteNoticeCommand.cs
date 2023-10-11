using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notices.Commands.DeleteNotice
{
    public class DeleteNoticeCommand : IRequest
    {
        public Guid NoticeId { get; set; }
    }
}
