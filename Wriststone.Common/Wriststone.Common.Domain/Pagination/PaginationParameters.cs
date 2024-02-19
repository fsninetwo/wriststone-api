using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wriststone.Common.Domain.Pagination
{
    public class PaginationParameters
    {
        public int PageIndex { get; }

        public int PageSize { get; }

        public PaginationParameters() 
        {        
            PageIndex = 1;
            PageSize = 25; 
        }

        public PaginationParameters(int? pageIndex, int? pageSize)
        {
            if(pageIndex is null || pageSize is null) 
            {
                PageIndex = 1;
                PageSize = 25; 
            }
            else
            {
                PageIndex = pageIndex.Value;
                PageSize = pageSize.Value; 
            }
        }
    }
}
