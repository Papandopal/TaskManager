using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.ProjectServices.MediatR.Enums;

namespace UseCase.ProjectServices.Services.DTOs
{
    public class FindProjectsUseCaseDTO
    {
        public string PropertyName { get; set; } = string.Empty;
        public string PropertyValue { get; set; } = string.Empty;
        public FindFlags FindFlags { get; set; }
    }
}
