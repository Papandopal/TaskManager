using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.GeneralServices.Enums;

namespace UseCase.ProjectServices.Services.DTOs
{
    public class SortProjectsDTO
    {
        public string PropertyName { get; set; } = string.Empty;
        public SortMode SortMode { get; set; }
    }
}
