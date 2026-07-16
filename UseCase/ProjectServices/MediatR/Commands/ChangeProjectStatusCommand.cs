using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using MediatR;
using UseCase.ProjectServices.MediatR.Responces;

namespace UseCase.ProjectServices.MediatR.Commands
{
    public class ChangeProjectStatusCommand : IRequest<ChangeProjectStatusResponce>
    {
        public Guid Id { get; init; }
        public Guid ChangerId { get; set; }
        public ProjectStatus Status { get; set; }
    }
}
