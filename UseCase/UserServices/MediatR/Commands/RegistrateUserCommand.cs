using System;
using MediatR;
using UseCase.UserServices.MediatR.Responces;

namespace UseCase.UserServices.MediatR.Commands
{
    public record RegistrateUserCommand : IRequest<RegistrateUserResponce>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedAt { get; } = DateTime.Now;
    }
}
