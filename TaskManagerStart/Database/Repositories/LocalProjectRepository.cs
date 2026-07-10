using System.Threading.Tasks;
using Domain.Entities;
using UseCase.Database.Repositories;

namespace TaskManagerStart.Database.Repositories
{
    public class LocalProjectRepository : IProjectRepository
    {
        private List<Project> projects;    
        public void Add(Project entity)
        {
            projects.Add(entity);
        }

        public void Delete(Project entity)
        {
            var project = projects.FirstOrDefault(x => x.Id == entity.Id);
            if (project is null) throw new Exception("project not found");
            projects.Remove(project);
        }

        public IEnumerable<Project> GetAll()
        {
            return projects;
        }

        public bool IsExists(Guid id)
        {
            var project = projects.FirstOrDefault(x => x.Id == id);
            return project is not null; 
        }

        public void Update(Project entity)
        {
            var project = projects.FirstOrDefault(x => x.Id == entity.Id);
            if (project is null) throw new Exception("project not found");
            project = entity;
        }
    }
}
