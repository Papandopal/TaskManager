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
    public class UpdateProjectCommandHandler(ProjectService projectService, IMapper mapper) : IRequestHandler<UpdateProjectCommand, UpdateProjectResponce>
    {
        public Task<UpdateProjectResponce> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var updated_project = mapper.Map<UpdateProjectUseCaseDTO>(request);

            projectService.Update(updated_project);

            return Task.FromResult(new UpdateProjectResponce { });
        }
    }
}
