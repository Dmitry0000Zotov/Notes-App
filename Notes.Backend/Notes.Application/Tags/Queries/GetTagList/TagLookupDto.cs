using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Tags.Queries.GetTagList
{
    public class TagLookupDto : IMapWith<Tag>
    {
        public Guid TagId { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tag, TagLookupDto>()
                .ForMember(tagDto => tagDto.TagId, opt => opt.MapFrom(tag => tag.TagId))
                .ForMember(tagDto => tagDto.Title, opt => opt.MapFrom(tag => tag.Title));
        }
    }
}
