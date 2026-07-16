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
    public class SortValidator : AbstractValidator<SortItemsDTO>
    {
        public SortValidator() 
        {
            RuleFor(x => x.SortMode).Must(mode =>
            {
                return Enum.IsDefined(typeof(SortMode), mode);
            });
        }
    }
}
