using BlazorPagination.Server.Helpers;
using BlazorPagination.Server.Services;
using BlazorPagination.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorPagination.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Car>>>> GetCars([FromQuery] PaginationInfo paginationInfo)
        {
            var result = await _carService.GetCarAsync(paginationInfo);
            await HttpContext.InsertPaginationParameterInResponse(result.NumberOfPages);
            return Ok(result);
        }

        [HttpGet]
        [Route("getSome")]
        public async Task<ActionResult<ServiceResponse<List<Car>>>> GetSomeCars()
        {
            var result = await _carService.GetSomeCarAsync();
            return Ok(result);
        }
    }
}
