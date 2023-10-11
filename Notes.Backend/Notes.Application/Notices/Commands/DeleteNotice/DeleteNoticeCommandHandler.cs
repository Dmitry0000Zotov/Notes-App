using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Application.Common.Exceptions;

namespace Notes.Application.Notices.Commands.DeleteNotice
{
    public class DeleteNoticeCommandHandler : IRequestHandler<DeleteNoticeCommand>
    {
        private readonly INotesDbContext _context;

        public DeleteNoticeCommandHandler(INotesDbContext context) => _context = context;

        public async Task Handle(DeleteNoticeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Notices.FindAsync(new object[] { request.NoticeId }, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Notice), request.NoticeId);
            }

            _context.Notices.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
