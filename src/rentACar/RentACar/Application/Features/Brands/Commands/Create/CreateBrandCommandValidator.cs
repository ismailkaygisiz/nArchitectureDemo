using FluentValidation;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(e => e.Name).NotEmpty().MinimumLength(2);
        }
    }
}
