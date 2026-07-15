using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using MediatR;
using UseCase.GeneralServices;
using UseCase.ProjectTaskServices.MediatR.Commands;
using UseCase.ProjectTaskServices.MediatR.Responces;
using UseCase.ProjectTaskServices.Services;
using UseCase.ProjectTaskServices.Services.DTOs;

namespace UseCase.ProjectTaskServices.MediatR.Handlers
{
    public class UpdateProjectTaskCommandHandler(ProjectTaskService projectTaskService, IMapper mapper) 
        : IRequestHandler<UpdateProjectTaskCommand, UpdateProjectTaskResponce>
    {
        public Task<UpdateProjectTaskResponce> Handle(UpdateProjectTaskCommand request, CancellationToken cancellationToken)
        {
            projectTaskService.Update(mapper.Map<UpdateProjectTaskUseCaseDTO>(request));

            return Task.FromResult(new UpdateProjectTaskResponce { });
        }
    }
}
