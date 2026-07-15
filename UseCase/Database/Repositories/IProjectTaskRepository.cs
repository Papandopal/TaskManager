using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace UseCase.Database.Repositories
{
    public interface IProjectTaskRepository : IRepository<ProjectTask>
    {
        public IEnumerable<ProjectTask> GetByProjectId(Guid projectId);
    }
}
