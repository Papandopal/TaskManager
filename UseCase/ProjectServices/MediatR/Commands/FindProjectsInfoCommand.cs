using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MediatR;
using UseCase.ProjectServices.MediatR.Enums;
using UseCase.ProjectServices.MediatR.Responces;

namespace UseCase.ProjectServices.MediatR.Commands
{
    public class FindProjectsInfoCommand : IRequest<FindProjectsInfoResponce>
    {
        public string PropertyName { get; set; } = string.Empty;
        public string PropertyValue { get; set; } = string.Empty;
        public FindFlags FilterFlags { get; set; }
    }
}
