using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Interfaces;

namespace Notes.Application.Notices.Queries.GetNoticeList
{
    public class GetNoticeListQueryHandler : IRequestHandler<GetNoticeListQuery, NoticeListVm>
    {
        private readonly INotesDbContext _context;
        private readonly IMapper _mapper;

        public GetNoticeListQueryHandler(INotesDbContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);

        public async Task<NoticeListVm> Handle(GetNoticeListQuery request, CancellationToken cancellationToken)
        {
            var noticeQuery = await _context.Notices
                .ProjectTo<NoticeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new NoticeListVm { Notices = noticeQuery };
        }
    }
}
