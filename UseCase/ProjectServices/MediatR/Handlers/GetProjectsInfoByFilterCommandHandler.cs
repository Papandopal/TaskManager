using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using MediatR;
using UseCase.ProjectServices.MediatR.Commands;
using UseCase.ProjectServices.MediatR.Responces;
using UseCase.ProjectServices.Services;
using UseCase.ProjectServices.Services.DTOs;

namespace UseCase.ProjectServices.MediatR.Handlers
{
    public class GetProjectsInfoByFilterCommandHandler(ProjectService projectService, PaginationService<Project> paginationService,
        IMapper mapper) : IRequestHandler<GetProjectsInfoByFilterCommand, GetProjectsInfoByFilterResponce>
    {
        public Task<GetProjectsInfoByFilterResponce> Handle(GetProjectsInfoByFilterCommand request, CancellationToken cancellationToken)
        {
            var projects = projectService.GetAll();

            paginationService.SetItems(projects);

            var filtered_projects = mapper.Map<IEnumerable<ShortProjectInfoDTO>>
                (paginationService.Filter(mapper.Map<FilterProjectsDTO>(request)));

            return Task.FromResult(new GetProjectsInfoByFilterResponce { Projects = filtered_projects });
        }
    }
}
