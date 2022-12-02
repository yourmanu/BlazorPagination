using BlazorPagination.Server.Data;
using BlazorPagination.Server.Helpers;
using BlazorPagination.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorPagination.Server.Services
{
    public interface ICarService
    {
        Task<ServiceResponse<List<Car>>> GetCarAsync(PaginationInfo paginationInfo);
        Task<ServiceResponse<List<Car>>> GetSomeCarAsync();
    }
    public class CarService : ICarService
    {
        private readonly DataContext _context;
        public CarService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Car>>> GetCarAsync(PaginationInfo paginationInfo)
        {
            var queryable = _context.Cars.OrderBy(c => c.Id).AsQueryable();
            var response = new ServiceResponse<List<Car>>()
            {
                Data = await queryable.Paginate(paginationInfo).ToListAsync(),
                NumberOfPages = queryable.Count() / paginationInfo.RowsPerPage

            };
            return response;
        }

        public async Task<ServiceResponse<List<Car>>> GetSomeCarAsync()
        {
            var skipNo = Random.Shared.Next(1, 990);
            var takeNo = Random.Shared.Next(2, 8);
            var queryable = _context.Cars.OrderBy(c => c.Id).Skip(skipNo).Take(takeNo).AsQueryable();
            var response = new ServiceResponse<List<Car>>()
            {
                Data = await queryable.ToListAsync(),
                NumberOfPages = 1

            };
            return response;
        }
    }
}
