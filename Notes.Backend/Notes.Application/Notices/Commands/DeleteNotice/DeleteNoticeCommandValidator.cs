using FluentValidation;

namespace Notes.Application.Notices.Commands.DeleteNotice
{
    public class DeleteNoticeCommandValidator : AbstractValidator<DeleteNoticeCommand>
    {
        public DeleteNoticeCommandValidator()
        {
            RuleFor(deleteNoticeCommand => deleteNoticeCommand.NoticeId).NotEqual(Guid.Empty);
        }
    }
}
