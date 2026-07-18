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
    public class SortProjectTasksInfoCommandHandler(IProjectTaskService projectTaskService, IMapper mapper,
        IPaginationService<ProjectTask> paginationService) : IRequestHandler<SortProjectTasksInfoCommand, SortProjectTasksInfoResponce>
    {
        public Task<SortProjectTasksInfoResponce> Handle(SortProjectTasksInfoCommand request, CancellationToken cancellationToken)
        {
            var projectTasks = projectTaskService.GetAll();
            paginationService.SetItems(projectTasks);
            var sortedProjectTasks = paginationService.Sort(mapper.Map<SortItemsDTO>(request)).ToEnumerable();

            return Task.FromResult(new SortProjectTasksInfoResponce 
            {
                ProjectTasks = mapper.Map<IEnumerable<ProjectTaskInfoDTO>>(sortedProjectTasks)
            });
        }
    }
}
