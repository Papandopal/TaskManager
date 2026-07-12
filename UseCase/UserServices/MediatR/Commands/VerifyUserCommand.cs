using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UseCase.AuthorisationServices.MediatR.Responces;

namespace UseCase.AuthorisationServices.MediatR.Commands
{
    public class VerifyUserCommand : IRequest<VerifyUserResponce>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
