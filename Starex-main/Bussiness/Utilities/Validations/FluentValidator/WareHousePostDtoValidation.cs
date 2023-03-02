using Entities.DTOs.WareHouseDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Utilities.Validations.FluentValidator
{
    public class WareHousePostDtoValidation:AbstractValidator<WareHousePostDTO>
    {
        public WareHousePostDtoValidation()
        {
            RuleFor(p => p.AdressTitle).NotEmpty().NotNull();
            RuleFor(p => p.Adress1).NotEmpty().NotNull();
            RuleFor(p => p.City).NotEmpty().NotNull();
            RuleFor(p => p.CountryId).NotEmpty().NotNull();
            RuleFor(p => p.District).NotEmpty().NotNull();
            RuleFor(p => p.Province).NotEmpty().NotNull();
            RuleFor(p => p.ZIP).NotEmpty().NotNull();
            RuleFor(p => p.PackageCapasity).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
