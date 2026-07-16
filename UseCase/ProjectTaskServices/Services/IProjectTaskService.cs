using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using UseCase.ProjectTaskServices.Services.DTOs;

namespace UseCase.ProjectTaskServices.Services
{
    public interface IProjectTaskService
    {
        public void Create(CreateProjectTaskUseCaseDTO createProjectTaskUseCaseDTO);
        public void Update(UpdateProjectTaskUseCaseDTO updateProjectTaskUseCaseDTO);
        public void ChangeStatus(ChangeProjectTaskStatusUseCaseDTO changeProjectTaskStatusUseCaseDTO);
        public void Delete(DeleteProjectTaskUseCaseDTO deleteProjectTaskUseCaseDTO);
        public ProjectTask GetById(Guid id);
        public IEnumerable<ProjectTask> GetAll();
        public IEnumerable<ProjectTask> GetByProjectId(Guid projectId);
    }
}
