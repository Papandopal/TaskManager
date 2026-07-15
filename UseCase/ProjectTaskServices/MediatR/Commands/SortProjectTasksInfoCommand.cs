using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UseCase.GeneralServices.Enums;
using UseCase.ProjectTaskServices.MediatR.Responces;

namespace UseCase.ProjectTaskServices.MediatR.Commands
{
    public class SortProjectTasksInfoCommand : IRequest<SortProjectTasksInfoResponce>
    {
        public string PropertyName { get; set; } = string.Empty;
        public SortMode SortMode { get; set; }
    }
}
