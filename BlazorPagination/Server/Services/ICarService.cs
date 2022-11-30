using BlazorPagination.Server.Data;
using BlazorPagination.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorPagination.Server.Services
{
    public interface ICarService
    {
        Task<ServiceResponse<List<Car>>> GetCarAsync();
    }
    public class CarService : ICarService
    {
        private readonly DataContext _context;
        public CarService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Car>>> GetCarAsync()
        {
            var response = new ServiceResponse<List<Car>>()
            {
                //Data = await _context.People.Skip((currentPage-1)*rowsPerPage).Take(rowsPerPage).ToListAsync()
                Data = await _context.Cars.Skip(0).Take(10).ToListAsync()
            };
            return response;
        }
    }
}
