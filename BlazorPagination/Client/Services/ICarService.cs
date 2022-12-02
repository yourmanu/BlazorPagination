using BlazorPagination.Shared;
using System.Text.Json;

namespace BlazorPagination.Client.Services
{
    public interface ICarService
    {
        Task<ServiceResponse<List<Car>>> GetCarAsync(int page = 1, int rowsPerPage = 10);
        Task<ServiceResponse<List<Car>>> GetSomeCarAsync();
        Task<Car> GetCarByIdAsync(int id);
    }

    public class CarService : ICarService
    {
        private readonly HttpClient _http;

        public CarService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ServiceResponse<List<Car>>> GetCarAsync(int page = 1, int rowsPerPage = 18)
        {
            var httpResponse = await _http.GetAsync($"people?currentPage={page}&rowsPerPage={rowsPerPage}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ServiceResponse<List<Car>>>(responseString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return result;
            }

            return null;
        }
        public async Task<ServiceResponse<List<Car>>> GetSomeCarAsync()
        {
            var httpResponse = await _http.GetAsync($"car/getsome");
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ServiceResponse<List<Car>>>(responseString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return result;
            }

            return null;
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            var httpResponse = await _http.GetAsync($"people/getpeoplebyid/{id}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<Car>(responseString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return result;
            }
            return null;
        }
    }

}
