using FluentValidation;

namespace Notes.Application.Notices.Queries.GetNoticeDetails
{
    public class GetNoticeDetailsQueryValidator : AbstractValidator<GetNoticeDetailsQuery>
    {
        public GetNoticeDetailsQueryValidator()
        {
            RuleFor(notice => notice.NoticeId).NotEqual(Guid.Empty);
        }
    }
}
