using BlazorPagination.Server.Data;
using BlazorPagination.Server.Helpers;
using BlazorPagination.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorPagination.Server.Services
{
    public interface IPeopleService
    {
        Task<ServiceResponse<List<People>>> GetPeopleAsync(PaginationInfo paginationInfo);
        Task<People?> GetPeopleByIdAsync(int id);
    }

    public class PeopleService : IPeopleService
    {
        private readonly DataContext _context;

        public PeopleService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<People>>> GetPeopleAsync(PaginationInfo paginationInfo)
        {
            var queryable = _context.People.OrderBy(c => c.Id).AsQueryable();
            var response = new ServiceResponse<List<People>>()
            {
                //Data = await _context.People.Skip((currentPage-1)*rowsPerPage).Take(rowsPerPage).ToListAsync()
                Data = await queryable.Paginate(paginationInfo).ToListAsync(),
                NumberOfPages   = queryable.Count()/paginationInfo.RowsPerPage

            };
            return response;
        }

        public async Task<People?> GetPeopleByIdAsync(int id)
        {
            People? people = _context.People.Where(p=>p.Id==id).FirstOrDefault();

            return people;
        }
    }

}
