using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UseCase.ProjectTaskServices.MediatR.Responces;

namespace UseCase.ProjectTaskServices.MediatR.Commands
{
    public class UpdateProjectTaskCommand : IRequest<UpdateProjectTaskResponce>
    {
        public Guid Id { get; init; }
        public Guid UpdaterId { get; init; }
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
    }
}
