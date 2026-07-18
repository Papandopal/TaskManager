using System.Buffers;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using FuzzySharp;
using UseCase.GeneralServices.DTOs;
using UseCase.GeneralServices.Enums;

namespace UseCase.GeneralServices
{
    public class PaginationService<T>(IValidator<FindItemsDTO> findValidator, IValidator<FilterItemsDTO> filterValidator,
        IValidator<SortItemsDTO> sortValidator) : IPaginationService<T>
    {
        private IQueryable<T> items;
        public List<T> ToList() => items.ToList();
        public IEnumerable<T> ToEnumerable() => items;

        public void SetItems(IQueryable<T> items)
        {
            this.items = items;
        }

        public IPaginationService<T> GetPage(int page, int size)
        {
            if(page <= 0 || size <= 0) throw new Exception("invalide input data");

            if ((page - 1) * size >= items.Count()) throw new Exception("invalide page number");

            items = items.Skip((page - 1) * size).Take(size < items.Count() ? size : items.Count());
            return this;
        }

        private IEnumerable<T> FindFuzzySearch(string propName, string propValue)
        {
            List<string> properties = new();
            PropertyInfo property = typeof(T).GetProperty(propName) ?? throw new Exception("property not found");
            foreach (var item in items)
            {
                if ((property.GetValue(item)?.ToString() ?? null) is not null) properties.Add(property.GetValue(item).ToString());
            }

            var resultrs = Process.ExtractAll(propValue, properties, cutoff: 70) //procent of similarity
                                  .Select(x => x.Value).ToList();

            List<T> new_items = new List<T>();

            foreach (var item in items)
            {
                if (resultrs.Contains(property.GetValue(item).ToString()))
                {
                    new_items.Add(item);
                }
            }

            return new_items;
        }

        private IEnumerable<T> FindWithoutFlags(string propName, string propValue)
        {
            List<T> new_items = new();
            PropertyInfo property = typeof(T).GetProperty(propName) ?? throw new Exception("property not found");
            foreach (T item in items)
            {
                if ((property.GetValue(item).ToString() ?? null) is null) continue;

                if (property.GetValue(item)?.ToString() == propValue) new_items.Add(item);
            }

            return new_items;
        }

        private IEnumerable<T> FindCaseInsensetive(string propName, string propValue)
        {
            List<T> new_items = new();
            PropertyInfo property = typeof(T).GetProperty(propName) ?? throw new Exception("property not found");
            foreach (T item in items)
            {
                if ((property.GetValue(item).ToString() ?? null) is null) continue;

                if (property.GetValue(item)?.ToString()?.ToLower() == propValue.ToLower()) new_items.Add(item);
            }

            return new_items;
        }

        private IEnumerable<T> FindCaseInsensetiveUseFuzzySearch(string propName, string propValue)
        {
            PropertyInfo property = typeof(T).GetProperty(propName) ?? throw new Exception("property not found");
            if (!property.CanWrite) throw new Exception("property cant sets");
            foreach (T item in items)
            {
                if ((property.GetValue(item).ToString() ?? null) is null) continue;

                var converter = TypeDescriptor.GetConverter(property.PropertyType);

                if (converter is null || !converter.CanConvertFrom(typeof(string)))
                    throw new Exception($"cant convert string to type of property {propName}");

                var value = converter.ConvertFrom(property.GetValue(item)?.ToString()?.ToLower());

                property.SetValue(item, value);
            }

            IEnumerable<T> new_items = FindFuzzySearch(propName, propValue);

            return new_items;
        }

        public IPaginationService<T> Find(FindItemsDTO findItemsDTO)
        {
            findValidator.ValidateAndThrow(findItemsDTO);

            if (findItemsDTO.FindFlags.HasFlag(FindFlags.CaseInsensitive | FindFlags.UseFuzzySearch))
                items = FindCaseInsensetiveUseFuzzySearch(findItemsDTO.PropertyName, findItemsDTO.PropertyValue).AsQueryable();

            else if (findItemsDTO.FindFlags.HasFlag(FindFlags.CaseInsensitive))
                items = FindCaseInsensetive(findItemsDTO.PropertyName, findItemsDTO.PropertyValue).AsQueryable();

            else if (findItemsDTO.FindFlags.HasFlag(FindFlags.UseFuzzySearch))
                items = FindFuzzySearch(findItemsDTO.PropertyName, findItemsDTO.PropertyValue).AsQueryable();

            else
                items = FindWithoutFlags(findItemsDTO.PropertyName, findItemsDTO.PropertyValue).AsQueryable();

            return this;
        }

        public IPaginationService<T> Filter(FilterItemsDTO filterItemsDTO)
        {
            filterValidator.ValidateAndThrow(filterItemsDTO);

            var item = items.First();
            ParameterExpression? parameter = null;
            MemberExpression? member = null;
            ConstantExpression? searchValue = null;

            if (item is null)
                throw new Exception($"collection before \"{filterItemsDTO.FilterComparer} {filterItemsDTO.PropertyName}\" is empty");

            PropertyInfo property = typeof(T).GetProperty(filterItemsDTO.PropertyName);

            var converter = TypeDescriptor.GetConverter(property.PropertyType);

            if (converter is null || !converter.CanConvertFrom(typeof(string)))
                throw new Exception($"cannot convert string to {filterItemsDTO.PropertyName}");

            parameter = Expression.Parameter(typeof(T), typeof(T).Name);
            member = Expression.Property(parameter, property.Name);

            var convertedObj = converter.ConvertFrom(filterItemsDTO.PropertyValue);
            searchValue = Expression.Constant(convertedObj, property.PropertyType);

            BinaryExpression binaryExpression;

            switch (filterItemsDTO.FilterComparer)
            {
                case FilterComparer.Equal:
                    binaryExpression = Expression.Equal(member, searchValue);
                    break;
                case FilterComparer.NotEqual:
                    binaryExpression = Expression.NotEqual(member, searchValue);
                    break;
                case FilterComparer.Greate:
                    binaryExpression = Expression.GreaterThan(member, searchValue);
                    break;
                case FilterComparer.GreateEqual:
                    binaryExpression = Expression.GreaterThanOrEqual(member, searchValue);
                    break;
                case FilterComparer.Less:
                    binaryExpression = Expression.LessThan(member, searchValue);
                    break;
                case FilterComparer.LessEqual:
                    binaryExpression = Expression.LessThanOrEqual(member, searchValue);
                    break;
                default:
                    throw new Exception("unknow comparer");
            }

            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(binaryExpression, parameter);

            items = items.Where(lambda);
            return this;
        }

        private IQueryable<T> SortBy(Expression<Func<T, object?>> keyExpression)
        {
            items = items.OrderBy(keyExpression);
            return items;
        }

        private IQueryable<T> DescSortBy(Expression<Func<T, object?>> keyExpression)
        {
            items = items.OrderByDescending(keyExpression);
            return items;
        }

        public IPaginationService<T> Sort(SortItemsDTO sortItemsDTO)
        {
            sortValidator.ValidateAndThrow(sortItemsDTO);

            Expression parameter = null;
            Expression member = null;

            if (items.Count() == 0) throw new Exception("collection is empty");
            PropertyInfo property = typeof(T).GetProperty(sortItemsDTO.PropertyName);
            parameter = Expression.Parameter(typeof(T), typeof(T).Name);
            member = Expression.Property(parameter, property.Name);

            if (property.PropertyType.IsValueType)
            {
                member = Expression.Convert(member, typeof(object));
            }

            Expression<Func<T, object?>> expression = Expression.Lambda<Func<T, object?>>(member, (ParameterExpression)parameter);

            if (sortItemsDTO.SortMode == SortMode.Ascending) items = SortBy(expression);
            else items = DescSortBy(expression);
            return this;
        }

        public IPaginationService<T> Limit(int count)
        {
            items = items.Take(count);
            return this;
        }
    }
}
