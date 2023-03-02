using Entities.DTOs.PricingDTOs;
using FluentValidation;

namespace Bussiness.Utilities.Validations.FluentValidator
{
    public class PricingPostDtoValidation : AbstractValidator<PricingPostDto>
    {
        public PricingPostDtoValidation()
        {
            RuleFor(p => p.MinKG).NotNull().NotEmpty().LessThanOrEqualTo(p=>p.MaxKG);
            RuleFor(p => p.MaxKG).NotNull().NotEmpty().GreaterThanOrEqualTo(p=>p.MinKG);
            RuleFor(p => p.Price).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(p => p.CountryId).NotNull().NotEmpty();
            RuleFor(p => p.CurrencyId).NotNull().NotEmpty();
        }
    }
}
