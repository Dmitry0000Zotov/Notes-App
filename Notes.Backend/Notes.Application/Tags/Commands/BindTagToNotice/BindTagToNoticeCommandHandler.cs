using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Application.Tags.Commands.BindTagToNote;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Tags.Commands.BindTagToNotice
{
    public class BindTagToNoticeCommandHandler : IRequestHandler<BindTagToNoticeCommand>
    {
        private readonly INotesDbContext _context;

        public BindTagToNoticeCommandHandler(INotesDbContext context) => _context = context;

        public async Task Handle(BindTagToNoticeCommand request, CancellationToken cancellationToken)
        {
            var notice = await _context.Notices.Include(n => n.Tags).FirstOrDefaultAsync(notice => notice.NoticeId == request.NoticeId, cancellationToken);
            if (notice == null)
            {
                throw new NotFoundException(nameof(Notice), request.NoticeId);
            }

            if (notice != null)
            {
                var newTagIds = request.Tags.ToList();

                foreach (var tag in notice.Tags.ToList())
                {
                    if (!newTagIds.Contains(tag.TagId))
                    {
                        notice.Tags.Remove(tag);
                    }
                    else
                    {
                        newTagIds.Remove(tag.TagId);
                    }
                }

                foreach (var tagId in newTagIds)
                {
                    var tagToAdd = await _context.Tags.FirstOrDefaultAsync(tag => tag.TagId == tagId);
                    if (tagToAdd != null)
                    {
                        notice.Tags.Add(tagToAdd);
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
