using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UseCase.ProjectTaskServices.Services.DTOs;

namespace UseCase.ProjectTaskServices.Services.Validators
{
    public class CreateProjectTaskUseCaseValidator : AbstractValidator<CreateProjectTaskUseCaseDTO>
    {
        public CreateProjectTaskUseCaseValidator()
        {

        }
    }
}
