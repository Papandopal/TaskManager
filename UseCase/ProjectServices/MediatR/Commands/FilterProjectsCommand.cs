using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using UseCase.ProjectServices.MediatR.Enums;
using UseCase.ProjectServices.MediatR.Responces;

namespace UseCase.ProjectServices.MediatR.Commands
{
    public class FilterProjectsCommand : IRequest<GetProjectsInfoByFilterResponce>
    {
        public string PropertyName { get; set; } = string.Empty;
        public string PropertyValue { get; set; } = string.Empty;
        public FilterComparer FilterComparer { get; set; }
    }
}
