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
    public class GetPageProjectsInfoCommandHandler(ProjectService projectService, PaginationService<Project> paginationService,
        IMapper mapper) : IRequestHandler<GetPageProjectsInfoCommand, GetPageProjectsInfoResponce>
    {
        public Task<GetPageProjectsInfoResponce> Handle(GetPageProjectsInfoCommand request, CancellationToken cancellationToken)
        {
            var projects = projectService.GetAll();

            paginationService.SetItems(projects);

            var findedProjects = mapper.Map<IEnumerable<ShortProjectInfoDTO>>(paginationService.GetPage(request.PageNumber, request.PageSize));

            return Task.FromResult(new GetPageProjectsInfoResponce { Projects =  findedProjects });
        }
    }
}
