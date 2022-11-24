using BlazorPagination.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorPagination.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars => Set<Car>();
    }
}
