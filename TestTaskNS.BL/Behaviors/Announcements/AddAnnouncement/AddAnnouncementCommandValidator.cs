using FluentValidation;
using TestTaskNS.Domain.Constants;

namespace TestTaskNS.BL.Behaviors.Announcements.AddAnnouncement;

public class AddAnnouncementCommandValidator : AbstractValidator<AddAnnouncementCommand>
{
    public AddAnnouncementCommandValidator()
    {
        RuleFor(t => t.Title)
            .MinimumLength(4)
            .WithMessage(ErrorMessages.TitleTooShort)
            .MaximumLength(50)
            .WithMessage(ErrorMessages.TitleTooLong)
            .NotEmpty()
            .WithMessage(ErrorMessages.TitleRequired);

        RuleFor(t => t.Description)
            .MinimumLength(20)
            .WithMessage(ErrorMessages.DescriptionTooShort)
            .MaximumLength(400)
            .WithMessage(ErrorMessages.DescriptionTooLong)
            .NotEmpty()
            .WithMessage(ErrorMessages.DescriptionRequired);

        RuleFor(t => t.AuthorName)
            .MinimumLength(2)
            .WithMessage(ErrorMessages.AuthorNameTooShort)
            .MaximumLength(40)
            .WithMessage(ErrorMessages.AuthorNameTooLong)
            .NotEmpty()
            .WithMessage(ErrorMessages.AuthorNameRequired);

        RuleFor(t => t.AuthorEmail)
            .EmailAddress()
            .WithMessage(ErrorMessages.AuthorEmailRequired)
            .NotEmpty()
            .WithMessage(ErrorMessages.AuthorEmailRequired);
    }
}
