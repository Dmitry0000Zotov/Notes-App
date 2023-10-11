using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notices.Commands.CreateNotice
{
    public class CreateNoticeCommandHandler : IRequestHandler<CreateNoticeCommand, Notice>
    {
        private readonly INotesDbContext _context;

        public CreateNoticeCommandHandler(INotesDbContext context) => _context = context;

        public async Task<Notice> Handle(CreateNoticeCommand request, CancellationToken cancellationToken)
        {
            var notice = new Notice
            {
                NoticeId = Guid.NewGuid(),
                Title = request.Title,
                DateCreation = DateTime.Now.ToUniversalTime(),
                DateEdit = null,
                Deadline = request.Deadline.ToUniversalTime()
            };

            await _context.Notices.AddAsync(notice, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return notice;
        }
    }
}
