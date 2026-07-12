using Domain.Entities;
using UseCase.Database.Repositories;

namespace Infrastructure.Database.Repositories
{
    public class LocalTaskRepository : IProjectTaskRepository
    {
        private List<ProjectTask> tasks = new();
        public void Add(ProjectTask entity)
        {
            tasks.Add(entity);
        }

        public void Delete(Guid id)
        {
            var task = tasks.FirstOrDefault(x => x.Id == id);
            if (task is null) throw new Exception("task not found");
            tasks.Remove(task);
        }

        public IEnumerable<ProjectTask> GetAll()
        {
            return tasks;
        }

        public ProjectTask GetById(Guid id)
        {
            var task = tasks.FirstOrDefault(x => x.Id == id);
            if (task is null) throw new Exception("task not found");
            return task;
        }

        public bool IsExists(Guid id)
        {
            var task = tasks.FirstOrDefault(x => x.Id == id);
            return task is not null;
        }

        public void Update(ProjectTask entity)
        {
            var task = tasks.FirstOrDefault(x => x.Id == entity.Id);
            if (task is null) throw new Exception("task not found");
            task = entity;
        }
    }
}
