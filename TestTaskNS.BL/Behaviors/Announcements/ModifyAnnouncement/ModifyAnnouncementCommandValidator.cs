using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskNS.Domain.Constants;

namespace TestTaskNS.BL.Behaviors.Announcements.ModifyAnnouncement;

public class ModifyAnnouncementCommandValidator : AbstractValidator<ModifyAnnouncementCommand>
{
    public ModifyAnnouncementCommandValidator()
    {
        RuleFor(t => t.Id)
            .NotEqual(Guid.Empty)
            .WithMessage(ErrorMessages.IdIncorrect)
            .NotEmpty()
            .WithMessage(ErrorMessages.IdRequired);

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

        RuleFor(t => t.AuthorEmail)
            .EmailAddress()
            .WithMessage(ErrorMessages.AuthorEmailRequired)
            .NotEmpty()
            .WithMessage(ErrorMessages.AuthorEmailRequired);
    }
}
