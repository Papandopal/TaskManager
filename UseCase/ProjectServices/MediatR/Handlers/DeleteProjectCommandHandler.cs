using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UseCase.ProjectServices.MediatR.Commands;
using UseCase.ProjectServices.MediatR.Responces;
using UseCase.ProjectServices.Services;

namespace UseCase.ProjectServices.MediatR.Handlers
{
    public class DeleteProjectCommandHandler(ProjectService projectService) : IRequestHandler<DeleteProjectCommand, DeleteProjectResponce>
    {
        public Task<DeleteProjectResponce> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            projectService.Delete(request.Id);
            return Task.FromResult(new DeleteProjectResponce { });
        }
    }
}
