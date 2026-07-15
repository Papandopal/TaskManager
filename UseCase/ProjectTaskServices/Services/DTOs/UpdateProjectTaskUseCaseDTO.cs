using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.ProjectTaskServices.Services.DTOs
{
    public class UpdateProjectTaskUseCaseDTO
    {
        public Guid Id { get; init; }
        public Guid UpdaterId { get; init; }
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
    }
}
