using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UseCase.ProjectServices.MediatR.Commands;
using UseCase.ProjectServices.MediatR.Responces;
using UseCase.ProjectServices.Services;
using UseCase.ProjectServices.Services.DTOs;

namespace UseCase.ProjectServices.MediatR.Handlers
{
    public class GetShortProjectsInfoCommandHandler(IProjectService projectService, IMapper mapper) : IRequestHandler<GetShortProjectsInfoCommand, GetShortProjectsInfoResponce>
    {
        public Task<GetShortProjectsInfoResponce> Handle(GetShortProjectsInfoCommand request, CancellationToken cancellationToken)
        {
            var projects = projectService.GetAll();

            return Task.FromResult(new GetShortProjectsInfoResponce 
            { Projects = mapper.Map<IEnumerable<ShortProjectInfoDTO>>(projects) });
        }
    }
}
