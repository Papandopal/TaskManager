using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace UseCase.AuthorisationServices
{
    public record RegistrateUserCommand(string name, string password) : IRequest<string>;
    public class RegistrateUserCommandHandler : IRequestHandler<RegistrateUserCommand, string>
    {
        public Task<string> Handle(RegistrateUserCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
