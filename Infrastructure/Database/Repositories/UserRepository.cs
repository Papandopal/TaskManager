using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UseCase.Database.Repositories;

namespace Infrastructure.Database.Repositories
{
    public class UserRepository(DbContext dbContext) : IUserRepository
    {
        private DbSet<User> users = dbContext.Set<User>();
        public void Add(User entity)
        {
            users.Add(entity);
        }

        public void Delete(Guid id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user is null) throw new Exception("user not found");
            users.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User GetByEmail(string email)
        {
            var user = users.FirstOrDefault(x => x.Email == email);
            if (user is null) throw new Exception("user not found");
            return user;
        }

        public User GetById(Guid id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user is null) throw new Exception("user not found");
            return user;
        }

        public bool IsExists(Guid id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            return user is not null;
        }

        public bool IsExistsByEmail(string email)
        {
            var user = users.FirstOrDefault(x => x.Email == email);
            return user is not null;
        }

        public void Update(User entity)
        {
            var user = users.FirstOrDefault(x => x.Id == entity.Id);
            if (user is null) throw new Exception("user not found");
            user = entity;
        }
    }
}
