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
using UseCase.ProjectServices.MediatR.Commands;
using UseCase.ProjectServices.MediatR.Responces;
using UseCase.ProjectServices.Services;
using UseCase.ProjectServices.Services.DTOs;

namespace UseCase.ProjectServices.MediatR.Handlers
{
    public class FilterProjectsInfoCommandHandler(IProjectService projectService, IPaginationService<Project> paginationService,
        IMapper mapper) : IRequestHandler<FilterProjectsCommand, FilterProjectsInfoResponce>
    {
        public Task<FilterProjectsInfoResponce> Handle(FilterProjectsCommand request, CancellationToken cancellationToken)
        {
            var projects = projectService.GetAll();

            paginationService.SetItems(projects);

            var filtered_projects = mapper.Map<IEnumerable<ShortProjectInfoDTO>>
                (paginationService.Filter(mapper.Map<FilterItemsDTO>(request)).ToEnumerable());

            return Task.FromResult(new FilterProjectsInfoResponce { Projects = filtered_projects });
        }
    }
}
