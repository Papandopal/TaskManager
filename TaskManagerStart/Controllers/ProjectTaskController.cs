using System.Net.WebSockets;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerStart.DTOs.ProjectTask;
using UseCase.ProjectTaskServices.MediatR.Commands;

namespace TaskManagerStart.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectTaskController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<JsonResult> Create(CreateProjectTaskDTO createProjectTaskDTO)
        {
            var command = mapper.Map<CreateProjectTaskCommand>(createProjectTaskDTO);

            command.CreatedAt = DateTime.Now;

            var responce = await mediator.Send(command);

            return new JsonResult(responce);
        }

        [HttpPut]
        [Authorize]
        public async Task<JsonResult> Update(UpdateProjectTaskDTO updateProjectTaskDTO)
        {
            var command = mapper.Map<UpdateProjectTaskCommand>(updateProjectTaskDTO);

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
        public async Task<JsonResult> ChangeStatus(ChangeProjectTaskStatusDTO changeProjectTaskStatusDTO)
        {
            var command = mapper.Map<ChangeProjectTaskStatusCommand>(changeProjectTaskStatusDTO);

            var token = HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token)) throw new Exception("Authorization token not found");

            Guid ownerId;
            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out ownerId))
                throw new Exception("Owner id not found in claims");

            command.ChangerId = ownerId;

            var responce = await mediator.Send(command);
            return new JsonResult(responce);
        }

        [HttpPost]
        [Authorize]
        public async Task<JsonResult> Delete(DeleteProjectTaskDTO deleteProjectTaskDTO)
        {
            var command = mapper.Map<DeleteProjectTaskCommand>(deleteProjectTaskDTO);

            var token = HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token)) throw new Exception("Authorization token not found");

            Guid ownerId;
            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out ownerId))
                throw new Exception("Owner id not found in claims");

            command.DeleterId = ownerId;

            var responce = await mediator.Send(command);
            return new JsonResult(responce);
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> GetAll()
        {
            var command = new ProjectTasksInfoCommand();

            var responce = await mediator.Send(command);

            return new JsonResult(responce);
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> Filter(FilterProjectTasksInfoDTO filterProjectTasksInfoDTO)
        {
            var command = mapper.Map<FilterProjectTasksInfoCommand>(filterProjectTasksInfoDTO);

            var responce = await mediator.Send(command);

            return new JsonResult(responce);
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> Find(FindProjectTasksInfoDTO findProjectTasksInfoDTO)
        {
            var command = mapper.Map<FindProjectTasksInfoCommand>(findProjectTasksInfoDTO);

            var responce = await mediator.Send(command);

            return new JsonResult(responce);
        }

        [HttpGet]
        [Authorize]
        public async Task<JsonResult> Sort(SortProjectTasksInfoDTO sortProjectTasksInfoDTO)
        {
            var command = mapper.Map<SortProjectTasksInfoCommand>(sortProjectTasksInfoDTO);

            var responce = await mediator.Send(command);

            return new JsonResult(responce);
        }
    }
}
