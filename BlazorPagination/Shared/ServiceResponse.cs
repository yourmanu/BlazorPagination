using System.Collections.Generic;

namespace BlazorPagination.Shared
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; } 
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public int NumberOfPages { get; set; }
    }
}
