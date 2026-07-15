using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.ProjectTaskServices.Services.DTOs
{
    public class DeleteProjectTaskUseCaseDTO
    {
        public Guid Id { get; init; }
        public Guid DeleterId { get; init; }
    }
}
