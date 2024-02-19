using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wriststone.Common.Domain.Pagination
{
    public class PagedList<TItem>
    {
        public PagedList() { }

        public PagedList(
            ICollection<TItem> items,
            long totalCount,
            PaginationParameters pagination) 
        {
            Items = items;
            TotalCount = totalCount;
            PageSize = pagination.PageSize;
            PageIndex = pagination.PageIndex;
        }

        public PagedList(PaginationParameters pagination) 
        {
            Items = new List<TItem>(0);
            TotalCount = 0;
            PageSize = pagination.PageSize;
            PageIndex = pagination.PageIndex;
        }

        public ICollection<TItem> Items { get; set; }

        public long TotalCount { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
