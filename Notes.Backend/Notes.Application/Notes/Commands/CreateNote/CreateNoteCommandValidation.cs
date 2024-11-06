using FluentValidation;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandValidation : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidation()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);

            RuleFor(x => x.Details).NotEmpty().MaximumLength(255);

            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
