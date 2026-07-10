using Domain.Entities;
using UseCase.Database.Repositories;

namespace TaskManagerStart.Database.Repositories
{
    public class LocalUserRepository : IUserRepository
    {
        private List<User> users = new();
        public void Add(User entity)
        {
            users.Add(entity);
        }

        public void Delete(User entity)
        {
            var user = users.FirstOrDefault(x => x.Id == entity.Id);
            if (user is null) throw new Exception("user not found");
            users.Remove(entity);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public bool IsExists(Guid id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
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
