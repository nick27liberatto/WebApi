namespace Application.Validators
{
    using Application.Dto.Request;
    using FluentValidation;
    public class ElementRequestDtoValidator : AbstractValidator<ElementRequestDto>
    {
        public ElementRequestDtoValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name is required")
           .MaximumLength(50);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6);

            RuleFor(x => x.Status)
                .IsInEnum().When(x => x.Status.HasValue);
        }
    }
}
