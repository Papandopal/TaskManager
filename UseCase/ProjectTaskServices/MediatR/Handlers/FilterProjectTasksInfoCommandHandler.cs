using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using MediatR;
using UseCase.GeneralServices;
using UseCase.GeneralServices.DTOs;
using UseCase.ProjectTaskServices.MediatR.Commands;
using UseCase.ProjectTaskServices.MediatR.Responces;
using UseCase.ProjectTaskServices.Services;
using UseCase.ProjectTaskServices.Services.DTOs;

namespace UseCase.ProjectTaskServices.MediatR.Handlers
{
    public class FilterProjectTasksInfoCommandHandler(IProjectTaskService projectTaskService, IMapper mapper,
        IPaginationService<ProjectTask> paginationService) : IRequestHandler<FilterProjectTasksInfoCommand, FilterProjectTasksInfoResponce>
    {
        public Task<FilterProjectTasksInfoResponce> Handle(FilterProjectTasksInfoCommand request, CancellationToken cancellationToken)
        {
            var projectTasks = projectTaskService.GetAll();
            paginationService.SetItems(projectTasks);
            var filteredProjectTasks = paginationService.Filter(mapper.Map<FilterItemsDTO>(request)).ToEnumerable();

            return Task.FromResult(new FilterProjectTasksInfoResponce 
            { 
                ProjectTasks = mapper.Map<IEnumerable<ProjectTaskInfoDTO>>(filteredProjectTasks)
            });
        }
    }
}
