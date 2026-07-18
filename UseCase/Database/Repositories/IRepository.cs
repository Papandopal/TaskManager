using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCase.Database.Repositories
{
    public interface IRepository<T>
    {
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(Guid id);
        public bool IsExists(Guid id);
        public T GetById(Guid id);
        public IQueryable<T> GetAll();
    }
}
