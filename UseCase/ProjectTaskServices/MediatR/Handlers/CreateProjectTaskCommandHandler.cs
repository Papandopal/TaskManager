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
    public class CreateProjectTaskCommandHandler(IProjectTaskService projectTaskService, IMapper mapper) 
        : IRequestHandler<CreateProjectTaskCommand, CreateProjectTaskResponce>
    {
        public Task<CreateProjectTaskResponce> Handle(CreateProjectTaskCommand request, CancellationToken cancellationToken)
        {
            projectTaskService.Create(mapper.Map<CreateProjectTaskUseCaseDTO>(request));

            return Task.FromResult(new CreateProjectTaskResponce { });
        }
    }
}
