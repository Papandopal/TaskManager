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
    public class FindValidator : AbstractValidator<FindItemsDTO>
    {
        public FindValidator() 
        {
            RuleFor(x => x.FindFlags).Must(flags =>
            {
                Type underlyingType = Enum.GetUnderlyingType(typeof(FindFlags));

                long allAllowedBits = 0;
                foreach (var enumValue in Enum.GetValues(typeof(FindFlags)))
                {
                    allAllowedBits |= Convert.ToInt64(enumValue);
                }

                long checkedValue = Convert.ToInt64(flags);

                return (checkedValue & ~allAllowedBits) == 0;
            });
        }
    }
}
