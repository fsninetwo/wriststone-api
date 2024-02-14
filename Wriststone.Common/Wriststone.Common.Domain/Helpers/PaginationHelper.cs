using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wriststone.Common.Domain.Pagination;

namespace Wriststone.Common.Domain.Helpers
{
    public static class PaginationHelper
    {
        public static async Task<PagedList<TItem>> GetPagedData<TItem>(
            IQueryable<TItem> query,
            PaginationParameters pagination)
        {
            var totalCount = query.LongCount();
            var items = query
                .Skip(pagination.PageIndex - 1)
                .Take(pagination.PageSize)
                .ToList();

            return new PagedList<TItem>(items, totalCount, pagination);
        }    
    }
}
