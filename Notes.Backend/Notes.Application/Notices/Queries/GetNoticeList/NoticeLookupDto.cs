using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Notices.Queries.GetNoticeList
{
    public class NoticeLookupDto : IMapWith<Notice>
    {
        public Guid NoticeId { get; set; }
        public string Title { get; set; }

        public DateTime Deadline { get; set; }
        public List<Tag> Tags { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Notice, NoticeLookupDto>()
                .ForMember(noticeDto => noticeDto.NoticeId, opt => opt.MapFrom(notice => notice.NoticeId))
                .ForMember(noticeDto => noticeDto.Title, opt => opt.MapFrom(notice => notice.Title))
                .ForMember(noticeDto => noticeDto.Deadline, opt => opt.MapFrom(notice => notice.Deadline));
        }
    }
}
