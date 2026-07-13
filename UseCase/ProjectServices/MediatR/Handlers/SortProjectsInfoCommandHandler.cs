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
    public class SortProjectsInfoCommandHandler(ProjectService projectService, PaginationService<Project> paginationService,
        IMapper mapper) : IRequestHandler<SortProjectsInfoCommand, SortProjectsInfoResponce>
    {
        public Task<SortProjectsInfoResponce> Handle(SortProjectsInfoCommand request, CancellationToken cancellationToken)
        {
            var projects = projectService.GetAll();

            var sorted_projects = paginationService.Sort(mapper.Map<SortProjectsDTO>(request));

            return Task.FromResult(new SortProjectsInfoResponce { Projects = mapper.Map<IEnumerable<ShortProjectInfoDTO>>(projects) });
        }
    }
}
