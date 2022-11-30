using Microsoft.EntityFrameworkCore;

namespace BlazorPagination.Server.Helpers
{
    public static class HttpContextExtensions
    {
        public static async Task InsertPaginationParameterInResponse(this HttpContext httpContext,int numberOfPages)
        {
            httpContext.Response.Headers.Add("numberOfPages", numberOfPages.ToString());
        }
    }
}
