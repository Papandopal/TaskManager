using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.Database.Repositories;

namespace UseCase.Database
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IProjectRepository ProjectRepository { get; }
        public IProjectTaskRepository ProjectTaskRepository { get; }
        public void StartTransaction();
        public void Commit();
        public void Rollback();
    }
}
