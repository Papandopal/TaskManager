using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace UseCase.Database.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetByEmail(string email);
        public bool IsExistsByEmail(string email);
    }
}
