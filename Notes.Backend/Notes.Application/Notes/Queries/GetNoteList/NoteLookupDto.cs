using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class NoteLookupDto : IMapWith<Note>
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; } = default!;

        public string Details { get; set; } = default!;
        
        public void Maping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookupDto>()
                .ForMember(noteL => noteL.Id, opt => opt.MapFrom(note => note.Id))
                .ForMember(noteL => noteL.Title, opt => opt.MapFrom(note => note.Title))
                .ForMember(noteL => noteL.Details, opt => opt.MapFrom(note => note.Details));
        }
    }
}
