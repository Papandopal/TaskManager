using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.VisualBasic;
using UseCase.GeneralServices;
using UseCase.GeneralServices.DTOs;
using UseCase.ProjectServices.MediatR.Commands;
using UseCase.ProjectServices.MediatR.Responces;
using UseCase.ProjectServices.Services;
using UseCase.ProjectServices.Services.DTOs;

namespace UseCase.ProjectServices.MediatR.Handlers
{
    public class FindProjectsInfoCommandHandler(ProjectService projectService, PaginationService<Project> paginationService,
        IMapper mapper) : IRequestHandler<FindProjectsInfoCommand, FindProjectsInfoResponce>
    {
        public Task<FindProjectsInfoResponce> Handle(FindProjectsInfoCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<Project> projects = projectService.GetAll();
            paginationService.SetItems(projects);
            projects = paginationService.Find(mapper.Map<FindItemsDTO>(request)).ToEnumerable();
            return Task.FromResult(new FindProjectsInfoResponce { Projects = mapper.Map<IEnumerable<ShortProjectInfoDTO>>(projects)});
        }
    }
}
