using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.ProjectServices.Services.DTOs
{
    public class DeleteProjectUseCaseDTO
    {
        public Guid Id { get; set; }
        public Guid DeleterId { get; set; }
    }
}
