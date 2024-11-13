namespace API.Validation;

using FluentValidation;

public class CreateCarDtoValidator : AbstractValidator<CreateCarDto>
{
    public CreateCarDtoValidator()
    {
        RuleFor(x => x.Brand).NotEmpty().WithMessage("Brand is required.");
        RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required.");
        RuleFor(x => x.Year).InclusiveBetween(1886, 2100)
            .WithMessage("Year must be between 1886 and 2100.");
    }
}

public class UpdateCarDtoValidator : AbstractValidator<UpdateCarDto>
{
    public UpdateCarDtoValidator()
    {
        RuleFor(x => x.Brand).NotEmpty().WithMessage("Brand is required.");
        RuleFor(x => x.Model).NotEmpty().WithMessage("Model is required.");
        RuleFor(x => x.Year).InclusiveBetween(1886, 2100)
            .WithMessage("Year must be between 1886 and 2100.");
    }
}

public class UpdateCarYearDtoValidator : AbstractValidator<UpdateCarYearDto>
{
    public UpdateCarYearDtoValidator()
    {
        RuleFor(x => x.NewYear).InclusiveBetween(1886, 2100)
            .WithMessage("Year must be between 1886 and 2100.");
    }
}
