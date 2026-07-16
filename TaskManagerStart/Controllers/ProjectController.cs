using System.Net;
using System.Runtime.InteropServices;
using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerStart.DTOs.Project;
using UseCase.ProjectServices.MediatR.Commands;
using UseCase.ProjectServices.Services.DTOs;

namespace TaskManagerStart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<JsonResult> Create(CreateProjectDTO createProjectDTO)
        {
            var command = mapper.Map<CreateProjectCommand>(createProjectDTO);

            var token = HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token)) throw new Exception("Authorization token not found");

            Guid ownerId;
            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out ownerId)) 
                throw new Exception("Owner id not found in claims");

            command.OwnerId = ownerId;

            var responce = await mediator.Send(command);
            return new JsonResult(responce);
        }

        [HttpDelete]
        [Authorize]
        public async Task<JsonResult> Delete(DeleteProjectDTO deleteProjectDTO)
        {
            var command = mapper.Map<DeleteProjectCommand>(deleteProjectDTO);

            var token = HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token)) throw new Exception("Authorization token not found");

            Guid ownerId;
            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out ownerId))
                throw new Exception("Owner id not found in claims");

            command.DeleterId = ownerId;

            var responce = await mediator.Send(command);
            return new JsonResult(responce);
        }

        [HttpPut]
        [Authorize]

        public async Task<JsonResult> Update(UpdateProjectDTO updateProjectDTO)
        {
            var command = mapper.Map<UpdateProjectCommand>(updateProjectDTO);

            var token = HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token)) throw new Exception("Authorization token not found");

            Guid ownerId;
            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out ownerId))
                throw new Exception("Owner id not found in claims");

            command.UpdaterId = ownerId;

            var responce = await mediator.Send(command);
            return new JsonResult(responce);
        }

        [HttpPut]
        [Authorize]

        public async Task<JsonResult> ChangeStatus(ChangeProjectStatusDTO changeProjectStatusDTO)
        {
            var command = mapper.Map<ChangeProjectStatusCommand>(changeProjectStatusDTO);

            var token = HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token)) throw new Exception("Authorization token not found");

            Guid ownerId;
            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out ownerId))
                throw new Exception("Owner id not found in claims");

            command.ChangerId = ownerId;

            var responce = await mediator.Send(command);
            return new JsonResult(responce);
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> Find(FindProjectsDTO findProjectsDTO)
        {
            var command = mapper.Map<FindProjectsInfoCommand>(findProjectsDTO);

            var responce = await mediator.Send(command);

            return new JsonResult(responce.Projects);
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> Filter(FilterProjectsDTO findProjectsDTO)
        {
            var command = mapper.Map<FilterProjectsCommand>(findProjectsDTO);

            var responce = await mediator.Send(command);

            return new JsonResult(responce.Projects);
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetLongInfoById(Guid id)
        {
            var command = new GetLongProjectInfoCommand { Id = id };

            var responce = await mediator.Send(command);

            return new JsonResult(responce.LongProjectInfoDTO);
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetPage(GetPageDTO getPageDTO)
        {
            var command = mapper.Map<GetPageProjectsInfoCommand>(getPageDTO);

            var responce = await mediator.Send(command);

            return new JsonResult(responce.Projects);
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetAll()
        {
            var command = new GetShortProjectsInfoCommand();

            var responce = await mediator.Send(command);

            return new JsonResult(responce.Projects);
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> Sort(SortProjectsDTO sortProjectsDTO)
        {
            var command = mapper.Map<SortProjectsInfoCommand>(sortProjectsDTO);

            var responce = await mediator.Send(command);

            return new JsonResult(responce.Projects);
        }
    }
}
