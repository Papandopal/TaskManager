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
    public class FindProjectTasksInfoCommandHandler(IProjectTaskService projectTaskService, IMapper mapper,
        IPaginationService<ProjectTask> paginationService) : IRequestHandler<FindProjectTasksInfoCommand, FindProjectTasksInfoResponce>
    {
        public Task<FindProjectTasksInfoResponce> Handle(FindProjectTasksInfoCommand request, CancellationToken cancellationToken)
        {
            var projectTasks = projectTaskService.GetAll();
            paginationService.SetItems(projectTasks);
            var findedProjectTasks = paginationService.Find(mapper.Map<FindItemsDTO>(request)).ToEnumerable();

            return Task.FromResult(new FindProjectTasksInfoResponce 
            {
                ProjectTasks = mapper.Map<IEnumerable<ProjectTaskInfoDTO>>(findedProjectTasks)
            });
        }
    }
}
