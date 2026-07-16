using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UseCase.ProjectServices.Services.DTOs;

namespace UseCase.ProjectServices.Services.Validators
{
    public class CreateProjectUseCaseValidator : AbstractValidator<CreateProjectUseCaseDTO>
    {
        public CreateProjectUseCaseValidator() 
        {

        }
    }
}
