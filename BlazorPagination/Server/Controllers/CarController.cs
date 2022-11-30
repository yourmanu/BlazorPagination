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
        public async Task<ActionResult<ServiceResponse<List<Car>>>> GetCars()
        {
            var result = await _carService.GetCarAsync();
            return Ok(result);
        }
    }
}
