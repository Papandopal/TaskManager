using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.ProjectServices.MediatR.Enums;

namespace UseCase.ProjectServices.Services.DTOs
{
    public class SortProjectsUseCaseDTO
    {
        public string PropertyName { get; set; } = string.Empty;
        public SortMode SortMode { get; set; }
    }
}
