using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.ProjectServices.Services.DTOs
{
    public class CreateProjectUseCaseDTO
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
