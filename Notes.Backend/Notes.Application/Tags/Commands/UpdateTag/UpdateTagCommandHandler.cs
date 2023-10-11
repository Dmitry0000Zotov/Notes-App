using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Application.Common.Exceptions;

namespace Notes.Application.Tags.Commands.UpdateTag
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
    {
        private readonly INotesDbContext _context;

        public UpdateTagCommandHandler(INotesDbContext context) => _context = context;

        public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Tags.FirstOrDefaultAsync(tag => tag.TagId == request.TagId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Tag), request.TagId);
            }

            entity.Title = request.Title;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
