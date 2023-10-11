using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Application.Common.Exceptions;

namespace Notes.Application.Notices.Queries.GetNoticeDetails
{
    public class GetNoticeDetailsQueryHandler : IRequestHandler<GetNoticeDetailsQuery, Notice>
    {
        private readonly INotesDbContext _context;

        public GetNoticeDetailsQueryHandler(INotesDbContext context) => _context = context;

        public async Task<Notice> Handle(GetNoticeDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Notices.FirstOrDefaultAsync(notice => notice.NoticeId == request.NoticeId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Notice), request.NoticeId);
            }

            return entity;
        }
    }
}
