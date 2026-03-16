using FluentValidation;
using Recam.Service.DTOs.Media;

namespace Recam.Service.Validators;

public class UploadMediaRequestValidator : AbstractValidator<UploadMediaRequestDto>
{
    public UploadMediaRequestValidator()
    {
        RuleFor(x => x.FileStream)
            .NotNull()
            .WithMessage("File stream is required");

        RuleFor(x => x.FileName)
            .NotEmpty()
            .WithMessage("File name is required");
    }
} 