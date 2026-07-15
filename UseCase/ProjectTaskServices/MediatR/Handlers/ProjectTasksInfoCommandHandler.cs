using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using MediatR;
using UseCase.GeneralServices;
using UseCase.ProjectTaskServices.MediatR.Commands;
using UseCase.ProjectTaskServices.MediatR.Responces;
using UseCase.ProjectTaskServices.Services;
using UseCase.ProjectTaskServices.Services.DTOs;

namespace UseCase.ProjectTaskServices.MediatR.Handlers
{
    public class ProjectTasksInfoCommandHandler(ProjectTaskService projectTaskService, IMapper mapper) 
        : IRequestHandler<ProjectTasksInfoCommand, ProjectTasksInfoResponce>
    {
        public Task<ProjectTasksInfoResponce> Handle(ProjectTasksInfoCommand request, CancellationToken cancellationToken)
        {
            var projectTasks = projectTaskService.GetAll();

            return Task.FromResult(new ProjectTasksInfoResponce 
            {
                ProjectTasks = mapper.Map<IEnumerable<ProjectTaskInfoDTO>>(projectTasks)
            });
        }
    }
}
