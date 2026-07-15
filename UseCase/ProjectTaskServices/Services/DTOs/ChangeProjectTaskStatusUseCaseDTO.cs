using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace UseCase.ProjectTaskServices.Services.DTOs
{
    public class ChangeProjectTaskStatusUseCaseDTO
    {
        public Guid Id { get; init; }
        public Guid ChangerId { get; init; }
        public ProjectTaskStatus Status { get; set; }
    }
}
