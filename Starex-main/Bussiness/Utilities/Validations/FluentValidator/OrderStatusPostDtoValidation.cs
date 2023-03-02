using Entities.DTOs.OrderStatusDTOs;
using FluentValidation;

namespace Bussiness.Utilities.Validations.FluentValidator
{
    public class OrderStatusPostDtoValidation : AbstractValidator<OrderStatusPostDto>
    {
        public OrderStatusPostDtoValidation()
        {
            RuleFor(p => p.Value).NotNull().NotEmpty().MinimumLength(3);
        }
    }
}
