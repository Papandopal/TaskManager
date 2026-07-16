using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using UseCase.ProjectServices.Services.DTOs;

namespace UseCase.ProjectServices.Services
{
    public interface IProjectService
    {
        public void Create(CreateProjectUseCaseDTO createProjectUseCaseDTO);
        public void Update(UpdateProjectUseCaseDTO updateProjectUseCaseDTO);
        public void ChangeStatus(ChangeProjectStatusUseCaseDTO changeStatusUseCaseDTO);
        public void Delete(DeleteProjectUseCaseDTO deleteProjectUseCaseDTO);
        public Project GetById(Guid id);
        public IEnumerable<Project> GetAll();
    }
}
