using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using MediatR;
using UseCase.ProjectTaskServices.MediatR.Responces;

namespace UseCase.ProjectTaskServices.MediatR.Commands
{
    public class ChangeProjectTaskStatusCommand : IRequest<ChangeProjectTaskStatusResponce>
    {
        public Guid Id { get; init; }
        public Guid ChangerId { get; init; }
        public ProjectTaskStatus Status { get; set; }
    }
}
