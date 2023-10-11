using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Application.Common.Exceptions;

namespace Notes.Application.Notices.Commands.UpdateNotice
{
    public class UpdateNoticeCommandHandler : IRequestHandler<UpdateNoticeCommand, Notice>
    {
        private readonly INotesDbContext _context;

        public UpdateNoticeCommandHandler(INotesDbContext context) => _context = context;

        public async Task<Notice> Handle(UpdateNoticeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Notices.FirstOrDefaultAsync(notice => notice.NoticeId == request.NoticeId, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Notice), request.NoticeId);
            }

            entity.Title = request.Title;
            entity.Deadline = request.Deadline.ToUniversalTime();
            entity.DateEdit = DateTime.Now.ToUniversalTime();

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
