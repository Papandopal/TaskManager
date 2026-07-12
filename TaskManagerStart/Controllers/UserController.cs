using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagerStart.DTOs;
using UseCase.AuthorisationServices.MediatR.Commands;

namespace TaskManagerStart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        [HttpPost("registrate")]
        public async Task<JsonResult> Registrate([FromBody] RegistrateUserDTO registrateUserDTO)
        {
            var registrateUserCommand = mapper.Map<RegistrateUserCommand>(registrateUserDTO);

            var responce = await mediator.Send(registrateUserCommand);

            return new JsonResult(new { Authorization = "Bearer " + responce.JwtToken });
        }

        [HttpPost("verify")]
        public async Task<JsonResult> Verify(VerifyUserDTO verifyUserDTO)
        {
            var verifyUserCommand = mapper.Map<VerifyUserCommand>(verifyUserDTO);

            var responce = await mediator.Send(verifyUserCommand);

            return new JsonResult(new { Authorization = "Bearer " + responce.JwtToken });
        }
    }
}
