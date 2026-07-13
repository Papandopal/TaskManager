using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using UseCase.ProjectServices.Services.DTOs;

namespace UseCase.ProjectServices.MediatR.Responces
{
    public class GetPageProjectsInfoResponce
    {
        public IEnumerable<ShortProjectInfoDTO> Projects { get; set; } = Enumerable.Empty<ShortProjectInfoDTO>();
    }
}
