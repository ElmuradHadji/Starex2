using Entities.DTOs.PackageStatusDTOs;
using FluentValidation;

namespace Bussiness.Utilities.Validations.FluentValidator
{
    public class PackageStatusPostDtoValidation : AbstractValidator<PackageStatusPostDto>
    {
        public PackageStatusPostDtoValidation()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().MinimumLength(3);
        }
    }
}
