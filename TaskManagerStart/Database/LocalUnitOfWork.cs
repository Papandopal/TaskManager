using UseCase.Database;
using UseCase.Database.Repositories;

namespace TaskManagerStart.Database
{
    public class LocalUnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; } = new 

        public IProjectRepository ProjectRepository { get; } = new

        public IProjectTaskRepository TaskRepository { get; } = new
        public void Commit()
        {
            
        }

        public void Rollback()
        {
            
        }

        public void StartTransaction()
        {
            
        }
    }
}
