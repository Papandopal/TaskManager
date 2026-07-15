using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.ProjectTaskServices.Services.DTOs;

namespace UseCase.ProjectTaskServices.MediatR.Responces
{
    public class FilterProjectTasksInfoResponce
    {
        public IEnumerable<ProjectTaskInfoDTO> ProjectTasks { get; set; } = Enumerable.Empty<ProjectTaskInfoDTO>();
    }
}
