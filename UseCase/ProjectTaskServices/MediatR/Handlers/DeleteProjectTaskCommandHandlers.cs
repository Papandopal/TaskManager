using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using UseCase.ProjectTaskServices.MediatR.Commands;
using UseCase.ProjectTaskServices.MediatR.Responces;
using UseCase.ProjectTaskServices.Services;
using UseCase.ProjectTaskServices.Services.DTOs;

namespace UseCase.ProjectTaskServices.MediatR.Handlers
{
    public class DeleteProjectTaskCommandHandlers(IProjectTaskService projectTaskService, IMapper mapper) 
        : IRequestHandler<DeleteProjectTaskCommand, DeleteProjectTaskResponce>
    {
        public Task<DeleteProjectTaskResponce> Handle(DeleteProjectTaskCommand request, CancellationToken cancellationToken)
        {
            projectTaskService.Delete(mapper.Map<DeleteProjectTaskUseCaseDTO>(request));

            return Task.FromResult(new DeleteProjectTaskResponce { });
        }
    }
}
