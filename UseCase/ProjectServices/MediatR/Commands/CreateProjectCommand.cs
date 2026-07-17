using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UseCase.ProjectServices.MediatR.Responces;

namespace UseCase.ProjectServices.MediatR.Commands
{
    public class CreateProjectCommand : IRequest<CreateProjectResponce>
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
