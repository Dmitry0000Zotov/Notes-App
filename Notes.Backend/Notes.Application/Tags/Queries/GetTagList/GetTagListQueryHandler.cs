using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;

namespace Notes.Application.Tags.Queries.GetTagList
{
    public class GetTagListQueryHandler : IRequestHandler<GetTagListQuery, TagListVm>
    {
        private readonly INotesDbContext _context;
        private readonly IMapper _mapper;

        public GetTagListQueryHandler(INotesDbContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);

        public async Task<TagListVm> Handle(GetTagListQuery request, CancellationToken cancellationToken)
        {
            var tagQuery = await _context.Tags.ProjectTo<TagLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new TagListVm { Tags = tagQuery };
        }
    }
}
