using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace UseCase.ProjectServices.Services.DTOs
{
    public class UpdateProjectDTO
    {
        public Guid Id { get; init; }
        public Guid UpdaterId { get; init; }
        public string? Name { get; set; } 
        public ProjectStatus? Status { get; set; }
    }
}
