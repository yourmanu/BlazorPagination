using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPagination.Shared
{
    public class PaginationInfo
    {
        public int CurrentPage { get; set; } = 1;
        public int RowsPerPage { get; set; } = 18;
    }
}
