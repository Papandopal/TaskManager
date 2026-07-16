using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using UseCase.Database;
using UseCase.ProjectTaskServices.Services.DTOs;

namespace UseCase.ProjectTaskServices.Services.Validators
{
    public class ChangeProjectTaskStatusUseCaseValidator : AbstractValidator<ChangeProjectTaskStatusUseCaseDTO>
    {
        public ChangeProjectTaskStatusUseCaseValidator(IUnitOfWork unitOfWork) 
        {
            RuleFor(x => x.ChangerId).Must((dto, id) =>
            {
                var projectTask = unitOfWork.ProjectTaskRepository.GetById(dto.Id);
                var project = unitOfWork.ProjectRepository.GetById(projectTask.ProjectId);

                return id == project.OwnerId;
            }).WithMessage("Access denied");
        }
    }
}
