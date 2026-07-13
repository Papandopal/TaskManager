using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.ProjectServices.Services.DTOs;

namespace UseCase.ProjectServices.MediatR.Responces
{
    public class GetProjectsInfoByFilterResponce
    {
        public IEnumerable<ShortProjectInfoDTO> Projects { get; set; } = Enumerable.Empty<ShortProjectInfoDTO>();
    }
}
