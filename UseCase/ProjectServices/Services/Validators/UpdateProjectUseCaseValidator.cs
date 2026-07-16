using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UseCase.Database;
using UseCase.ProjectServices.Services.DTOs;

namespace UseCase.ProjectServices.Services.Validators
{
    public class UpdateProjectUseCaseValidator : AbstractValidator<UpdateProjectUseCaseDTO>
    {
        public UpdateProjectUseCaseValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.UpdaterId).Must((dto, id) =>
            {
                var project = unitOfWork.ProjectRepository.GetById(dto.Id);
                return id == project.OwnerId;
            }).WithMessage("Access denied");
        }
    }
}
