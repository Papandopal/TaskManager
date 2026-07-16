using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UseCase.GeneralServices.DTOs;
using UseCase.GeneralServices.Enums;

namespace UseCase.GeneralServices.Validators
{
    public class FilterValidator : AbstractValidator<FilterItemsDTO>
    {
        public FilterValidator() 
        {
            RuleFor(x => x.FilterComparer).Must(comparer =>
            {
                return Enum.IsDefined(typeof(FilterComparer), comparer);
            });
        }
    }
}
