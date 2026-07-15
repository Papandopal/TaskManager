using System.Data.Common;
using Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using UseCase.Database;
using UseCase.Database.Repositories;

namespace Infrastructure.Database
{
    public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
    {
        private IDbContextTransaction? transaction = null;
        public IUserRepository UserRepository { get; } = new UserRepository(dbContext);

        public IProjectRepository ProjectRepository { get; } = new ProjectRepository(dbContext);

        public IProjectTaskRepository ProjectTaskRepository { get; } = new ProjectTaskRepository(dbContext);
        public void StartTransaction()
        {
            if (transaction is not null) Rollback();
            transaction = dbContext.Database.BeginTransaction();
        }
        public void Commit()
        {
            if (transaction is null) return;
            transaction.Commit();
            dbContext.SaveChanges();
            transaction.Dispose();
            transaction = null;
        }

        public void Rollback()
        {
            if (transaction is null) return;
            transaction.Rollback();
            transaction.Dispose();
            transaction = null;
        }
    }
}
