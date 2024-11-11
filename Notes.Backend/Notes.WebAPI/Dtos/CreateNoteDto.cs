using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.CreateNote;
using System.ComponentModel.DataAnnotations;

namespace Notes.WebAPI.Dtos
{
    public class CreateNoteDto : IMapWith<CreateNoteCommand>
    {
        [Required]
        public string Title { get; set; } = default!;

        public string Details { get; set; } = default!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDto, CreateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Details,
                    opt => opt.MapFrom(noteDto => noteDto.Details));
        }
    }
}
