using System.Buffers;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using FuzzySharp;
using UseCase.ProjectServices.MediatR.Enums;
using UseCase.ProjectServices.Services.DTOs;

namespace UseCase.ProjectServices.Services
{
    public class PaginationService<T>
    {
        private IEnumerable<T> items = new List<T>();
        public List<T> ToList() => items.ToList();
        public IEnumerable<T> ToEnumerable() => items;

        public void SetItems(IEnumerable<T> items)
        {
            this.items = items;
        }

        public PaginationService<T> GetPage(int page, int size = 5)
        {
            items = items.Skip((page - 1) * size);
            return this;
        }

        private IEnumerable<T> FindFuzzySearch(string PropName, string PropValue)
        {
            List<string> properties = new();

            foreach (var item in items)
            {
                if (item is null) continue;
                foreach (var property in item.GetType().GetProperties())
                {
                    if (property.Name == PropName && property.CanRead) properties.Add(property.GetValue(property).ToString());
                }
            }

            var resultrs = Process.ExtractAll(PropValue, properties, cutoff: 70) //procent of similarity
                                  .Select(x => x.Value).ToList();

            List<T> new_items = new List<T>();

            foreach (var item in items)
            {
                if (item is null) continue;
                foreach (var property in item.GetType().GetProperties())
                {
                    if (property.Name == PropName && resultrs.Contains(property.GetValue(property).ToString()))
                    {
                        new_items.Add(item);
                    }
                }
            }

            return new_items;
        }

        private IEnumerable<T> FindCaseInsensetive(string propName, string propValue)
        {
            foreach (var item in items)
            {
                if (item is null) continue;
                foreach (var property in item.GetType().GetProperties())
                {
                    if (property.Name == propName) property.SetValue(item, propValue.ToLower());
                }
            }

            return items;
        }

        public IEnumerable<T> Find(FindProjectsUseCaseDTO findProjectsDTO)
        {
            if (findProjectsDTO.FilterFlags.HasFlag(FindFlags.CaseInsensitive))
                items = FindCaseInsensetive(findProjectsDTO.PropertyName, findProjectsDTO.PropertyValue);

            if (findProjectsDTO.FilterFlags.HasFlag(FindFlags.UseFuzzySearch))
                items = FindFuzzySearch(findProjectsDTO.PropertyName, findProjectsDTO.PropertyValue);

            return items;
        }

        public IEnumerable<T> Filter(FilterProjectsUseCaseDTO filterProjectsDTO)
        {
            var item = items.First();
            ParameterExpression? parameter = null;
            MemberExpression? member = null;
            ConstantExpression? searchValue = null;

            if (item is null) throw new Exception($"collection before \"{filterProjectsDTO.FilterComparer} {filterProjectsDTO.PropertyName}\" is empty");
            foreach (var property in item.GetType().GetProperties())
            {
                if (property.Name == filterProjectsDTO.PropertyName)
                {
                    parameter = ParameterExpression.Parameter(typeof(T), typeof(T).Name);
                    member = MemberExpression.Property(parameter, property.Name);
                    searchValue = Expression.Constant(filterProjectsDTO.PropertyValue, property.PropertyType);
                    break;
                }
            }

            if (parameter is null || searchValue is null || member is null)
                throw new Exception($"property {filterProjectsDTO.PropertyName} not found in {typeof(T).Name}");

            BinaryExpression binaryExpression;

            switch (filterProjectsDTO.FilterComparer)
            {
                case FilterComparer.Equal:
                    binaryExpression = Expression.Equal(member, searchValue);
                    break;
                case FilterComparer.NotEqual:
                    binaryExpression = Expression.NotEqual(member, searchValue);
                    break;
                case FilterComparer.GreateEqual:
                    binaryExpression = Expression.GreaterThanOrEqual(member, searchValue);
                    break;
                case FilterComparer.GreateNotEqual:
                    binaryExpression = Expression.GreaterThan(member, searchValue);
                    break;
                case FilterComparer.LessEqual:
                    binaryExpression = Expression.LessThanOrEqual(member, searchValue);
                    break;
                case FilterComparer.LessNotEqual:
                    binaryExpression = Expression.LessThan(member, searchValue);
                    break;
                default:
                    throw new Exception("unknow comparer");
            }

            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(binaryExpression, parameter);

            return items.Where(lambda.Compile());
        }

        private PaginationService<T> SortBy(Expression<Func<T, object?>> keyExpression)
        {
            items = items.AsQueryable().OrderBy(keyExpression);
            return this;
        }

        private PaginationService<T> DescSortBy(Expression<Func<T, object?>> keyExpression)
        {
            items = items.AsQueryable().OrderByDescending(keyExpression);
            return this;
        }

        public PaginationService<T> Sort(SortProjectsUseCaseDTO sortProjectsDTO)
        {

            ParameterExpression? parameter = null;
            MemberExpression? member = null;

            if (items.Count() == 0) throw new Exception("collection is empty");
            foreach (var property in items.First().GetType().GetProperties())
            {
                if (property.Name == sortProjectsDTO.PropertyName)
                {
                    parameter = ParameterExpression.Parameter(typeof(T), typeof(T).Name);
                    member = MemberExpression.Property(parameter, property.Name);
                    break;
                }
            }

            if (parameter is null || member is null)
                throw new Exception($"property {sortProjectsDTO.PropertyName} not found in {typeof(T).Name}");

            Expression<Func<T, object?>> expression = Expression.Lambda<Func<T, object?>>(member, parameter);

            if(sortProjectsDTO.SortMode == SortMode.Ascending) return SortBy(expression);
            else return DescSortBy(expression);
        }

        public PaginationService<T> Limit(int count)
        {
            items = items.Take(count);
            return this;
        }
    }
}
