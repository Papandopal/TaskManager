using System;
using MediatR;
using UseCase.AuthorisationServices.MediatR.Responces;

namespace UseCase.AuthorisationServices.MediatR.Commands
{
    public record RegistrateUserCommand : IRequest<RegistrateUserResponce>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedAt { get; } = DateTime.Now;
    }
}
