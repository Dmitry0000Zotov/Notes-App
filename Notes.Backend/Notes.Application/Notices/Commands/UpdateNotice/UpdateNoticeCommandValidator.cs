using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notices.Commands.UpdateNotice
{
    public class UpdateNoticeCommandValidator : AbstractValidator<UpdateNoticeCommand>
    {
        public UpdateNoticeCommandValidator()
        {
            RuleFor(updateNoticeCommand => updateNoticeCommand.NoticeId).NotEqual(Guid.Empty);
        }
    }
}
