using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace UseCase.ProjectServices.Services.DTOs
{
    public class ChangeProjectStatusUseCaseDTO
    {
        public Guid Id { get; init; }
        public Guid ChangerId { get; init; }
        public ProjectStatus Status { get; set; }
    }
}
