using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UseCase.Database.Repositories;

namespace Infrastructure.Database.Repositories
{
    public class ProjectRepository(DbContext dbContext) : IProjectRepository
    {
        private DbSet<Project> projects = dbContext.Set<Project>();    
        public void Add(Project entity)
        {
            projects.Add(entity);
        }

        public void Delete(Guid id)
        {
            var project = projects.FirstOrDefault(x => x.Id == id);
            if (project is null) throw new Exception("project not found");
            projects.Remove(project);
        }

        public IQueryable<Project> GetAll()
        {
            return projects;
        }

        public Project GetById(Guid id)
        {
            var project = projects.FirstOrDefault(x => x.Id == id);
            if (project is null) throw new Exception("project not found");
            return project;
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
