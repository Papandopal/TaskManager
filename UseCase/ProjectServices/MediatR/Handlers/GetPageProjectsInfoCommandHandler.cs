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
    public class GetPageProjectsInfoCommandHandler : IRequestHandler<GetPageProjectsInfoCommand, GetPageProjectsInfoResponce>
    {
        public Task<GetPageProjectsInfoResponce> Handle(GetPageProjectsInfoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
