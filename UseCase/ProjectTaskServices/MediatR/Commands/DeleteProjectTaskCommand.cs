using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UseCase.ProjectTaskServices.MediatR.Responces;

namespace UseCase.ProjectTaskServices.MediatR.Commands
{
    public class DeleteProjectTaskCommand : IRequest<DeleteProjectTaskResponce>
    {
        public Guid Id { get; init; }
        public Guid DeleterId { get; set; }
    }
}
