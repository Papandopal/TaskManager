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
    public class ChangeProjectTaskStatusCommandHandler(IProjectTaskService projectTaskService, IMapper mapper) 
        : IRequestHandler<ChangeProjectTaskStatusCommand, ChangeProjectTaskStatusResponce>
    {
        public Task<ChangeProjectTaskStatusResponce> Handle(ChangeProjectTaskStatusCommand request, CancellationToken cancellationToken)
        {
            projectTaskService.ChangeStatus(mapper.Map<ChangeProjectTaskStatusUseCaseDTO>(request));

            return Task.FromResult(new ChangeProjectTaskStatusResponce { });
        }
    }
}
