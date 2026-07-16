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
    internal class ChangeProjectStatusCommandHandler(IProjectService projectService, IMapper mapper) : IRequestHandler<ChangeProjectStatusCommand, ChangeProjectStatusResponce>
    {
        public Task<ChangeProjectStatusResponce> Handle(ChangeProjectStatusCommand request, CancellationToken cancellationToken)
        {
            projectService.ChangeStatus(mapper.Map<ChangeProjectStatusUseCaseDTO>(request));

            return Task.FromResult(new ChangeProjectStatusResponce { });
        }
    }
}
