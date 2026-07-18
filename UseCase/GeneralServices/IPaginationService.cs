using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.GeneralServices.DTOs;

namespace UseCase.GeneralServices
{
    public interface IPaginationService<T>
    {
        public void SetItems(IQueryable<T> items);
        public IEnumerable<T> ToEnumerable();
        public IPaginationService<T> GetPage(int page, int size);
        public IPaginationService<T> Find(FindItemsDTO findItemsDTO);
        public IPaginationService<T> Filter(FilterItemsDTO filterItemsDTO);
        public IPaginationService<T> Sort(SortItemsDTO sortItemsDTO);
        public IPaginationService<T> Limit(int count);
    }
}
