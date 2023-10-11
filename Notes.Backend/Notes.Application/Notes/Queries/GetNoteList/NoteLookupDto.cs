using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class NoteLookupDto : IMapWith<Note>
    {
        public Guid NoteId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateEdit { get; set; }
        public DateTime DateNote { get; set; }
        public List<Tag> Tags { get; set; }
 
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookupDto>()
                .ForMember(noteDto => noteDto.NoteId, opt => opt.MapFrom(note => note.NoteId))
                .ForMember(noteDto => noteDto.Title, opt => opt.MapFrom(note => note.Title))
                .ForMember(noteDto => noteDto.Details, opt => opt.MapFrom(note => note.Details))
                .ForMember(noteDto => noteDto.Tags, opt => opt.MapFrom(note => note.Tags));
        }
    }
}
