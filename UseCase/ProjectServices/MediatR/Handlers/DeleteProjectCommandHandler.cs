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
    public class DeleteProjectCommandHandler(IProjectService projectService, IMapper mapper) 
        : IRequestHandler<DeleteProjectCommand, DeleteProjectResponce>
    {
        public Task<DeleteProjectResponce> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            projectService.Delete(mapper.Map<DeleteProjectUseCaseDTO>(request));
            return Task.FromResult(new DeleteProjectResponce { });
        }
    }
}
