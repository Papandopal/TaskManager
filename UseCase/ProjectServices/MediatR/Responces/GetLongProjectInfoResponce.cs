using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using UseCase.ProjectServices.Services.DTOs;

namespace UseCase.ProjectServices.MediatR.Responces
{
    public class GetLongProjectInfoResponce
    {
        public LongProjectInfoDTO LongProjectInfoDTO { get; set; } = new();
    }
}
