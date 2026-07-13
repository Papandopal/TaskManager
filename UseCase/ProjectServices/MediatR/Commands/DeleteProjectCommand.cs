using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UseCase.ProjectServices.MediatR.Responces;

namespace UseCase.ProjectServices.MediatR.Commands
{
    public class DeleteProjectCommand : IRequest<DeleteProjectResponce>
    {
        public Guid Id { get; set; }
        public Guid DeleterId { get; set; }
    }
}
