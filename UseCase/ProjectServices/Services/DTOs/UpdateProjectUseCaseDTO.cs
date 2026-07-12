using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.ProjectServices.Services.DTOs
{
    public class UpdateProjectUseCaseDTO
    {
        public Guid Id { get; init; }
        public string? Name { get; set; } 
    }
}
