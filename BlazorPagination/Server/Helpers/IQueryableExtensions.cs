using BlazorPagination.Shared;
using Microsoft.EntityFrameworkCore.Query;

namespace BlazorPagination.Server.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationInfo paginationInfo)
        {
            return queryable
                .Skip((paginationInfo.CurrentPage - 1) * paginationInfo.RowsPerPage)
                .Take(paginationInfo.RowsPerPage);
        }
    }
}
