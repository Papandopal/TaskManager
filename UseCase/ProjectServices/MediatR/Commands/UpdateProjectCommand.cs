using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UseCase.ProjectServices.MediatR.Responces;

namespace UseCase.ProjectServices.MediatR.Commands
{
    public class UpdateProjectCommand : IRequest<UpdateProjectResponce>
    {
        public Guid Id { get; init; }
        public string? Name { get; set; } 
    }
}
