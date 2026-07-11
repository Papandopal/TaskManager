using Infrastructure.Database.Repositories;
using UseCase.Database;
using UseCase.Database.Repositories;

namespace Infrastructure.Database
{
    public class LocalUnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; } = new LocalUserRepository();

        public IProjectRepository ProjectRepository { get; } = new LocalProjectRepository();

        public IProjectTaskRepository TaskRepository { get; } = new LocalTaskRepository();
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
