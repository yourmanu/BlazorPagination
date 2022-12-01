using BlazorPagination.Server.Helpers;
using BlazorPagination.Server.Services;
using BlazorPagination.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorPagination.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public async Task<ServiceResponse<List<People>>> GetPeople([FromQuery] PaginationInfo paginationInfo)
        {
            var result = await _peopleService.GetPeopleAsync(paginationInfo);
            await HttpContext.InsertPaginationParameterInResponse(result.NumberOfPages);
            return result;
        }
        [HttpGet]
        [Route("getPeopleById/{id:int}")]
        public async Task<People> GetPeopleById(int id)
        {
            var result = await _peopleService.GetPeopleByIdAsync(id);
            return result;
        }
    }
}