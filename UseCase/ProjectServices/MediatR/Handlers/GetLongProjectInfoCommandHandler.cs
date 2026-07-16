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

namespace UseCase.ProjectServices.MediatR.Handlers
{
    public class GetLongProjectInfoCommandHandler(IProjectService projectService, IMapper mapper) : IRequestHandler<GetLongProjectInfoCommand, GetLongProjectInfoResponce>
    {
        public Task<GetLongProjectInfoResponce> Handle(GetLongProjectInfoCommand request, CancellationToken cancellationToken)
        {
            Project project = projectService.GetById(request.Id);
            return Task.FromResult(new GetLongProjectInfoResponce { });
        }
    }
}
