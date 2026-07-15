using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UseCase.ProjectTaskServices.MediatR.Responces;

namespace UseCase.ProjectTaskServices.MediatR.Commands
{
    public class CreateProjectTaskCommand : IRequest<CreateProjectTaskResponce>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
