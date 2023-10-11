using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;
using Notes.Domain;
using Notes.Application.Common.Exceptions;

namespace Notes.Application.Tags.Queries.GetTag
{
    public class GetTagQueryHandler : IRequestHandler<GetTagQuery, Tag>
    {
        private readonly INotesDbContext _context;

        public GetTagQueryHandler(INotesDbContext context) => _context = context;

        public async Task<Tag> Handle(GetTagQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Tags.FirstOrDefaultAsync(tag => tag.TagId == request.TagId, cancellationToken);

            if (entity == null) throw new NotFoundException(nameof(Tag), request.TagId);

            return entity;
        }
    }
}
