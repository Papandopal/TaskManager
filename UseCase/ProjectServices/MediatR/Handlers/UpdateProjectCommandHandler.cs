using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UseCase.ProjectServices.MediatR.Commands;
using UseCase.ProjectServices.MediatR.Responces;

namespace UseCase.ProjectServices.MediatR.Handlers
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, UpdateProjectResponce>
    {
        public Task<UpdateProjectResponce> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
