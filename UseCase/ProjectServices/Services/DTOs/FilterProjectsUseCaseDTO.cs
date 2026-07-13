using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.ProjectServices.MediatR.Enums;

namespace UseCase.ProjectServices.Services.DTOs
{
    public class FilterProjectsUseCaseDTO
    {
        public string PropertyName { get; set; } = string.Empty;
        public string PropertyValue { get; set; } = string.Empty;
        public FilterComparer FilterComparer { get; set; }
    }
}
