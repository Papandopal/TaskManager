using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using UseCase.ProjectServices.MediatR.Enums;

namespace UseCase.ProjectServices.Services
{
    public class PaginationService<T>
    {
        private IEnumerable<T> items = new List<T>();
        public List<T> ToList() => items.ToList();

        public void SetItems(IEnumerable<T> items)
        {
            this.items = items;
        }

        public PaginationService<T> GetPage(int page, int size = 5)
        {
            items = items.Skip((page - 1) * size);
            return this;
        }


        public PaginationService<T> Filter(Func<T, bool> predicate)
        {
            List<T> new_items = new();

            foreach (T item in items)
            {
                if (predicate(item)) new_items.Add(item);
            }

            items = new_items;

            return this;
        }

        public PaginationService<T> SortBy(Expression<Func<T, object?>> keyExpression)
        {
            items = items.AsQueryable().OrderBy(keyExpression);
            return this;
        }

        public PaginationService<T> DescSortBy(Expression<Func<T, object?>> keyExpression)
        {
            items = items.AsQueryable().OrderByDescending(keyExpression);
            return this;
        }

        public PaginationService<T> Limit(int count)
        {
            items = items.Take(count);
            return this;
        }
    }
}
