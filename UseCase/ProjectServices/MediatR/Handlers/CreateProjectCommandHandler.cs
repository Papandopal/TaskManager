using AutoMapper;
using MediatR;
using UseCase.ProjectServices.MediatR.Commands;
using UseCase.ProjectServices.MediatR.Responces;
using UseCase.ProjectServices.Services;
using UseCase.ProjectServices.Services.DTOs;

namespace UseCase.ProjectServices.MediatR.Handlers
{
    public class CreateProjectCommandHandler(IMapper mapper, ProjectService projectService) : IRequestHandler<CreateProjectCommand, CreateProjectResponce>
    {
        public Task<CreateProjectResponce> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var createProjectUseCaseDTO = mapper.Map<CreateProjectUseCaseDTO>(request);
            projectService.Create(createProjectUseCaseDTO);
            return Task.FromResult(new CreateProjectResponce { });
        }
    }
}
