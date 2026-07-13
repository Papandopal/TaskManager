using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace UseCase.ProjectServices.Services.DTOs
{
    public class ShortProjectInfoDTO
    {
        public Guid Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public ProjectStatus Status { get; set; }
    }
}
