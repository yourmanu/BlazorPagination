using BlazorPagination.Shared;
using System.Net.Http.Json;
using System.Text.Json;
namespace BlazorPagination.Client.Services
{
    public interface IPeopleService
    {
        Task<ServiceResponse<List<People>>> GetPeopleAsync(int page=1,int rowsPerPage=18);
    }

    public class PeopleService : IPeopleService
    {
        private readonly HttpClient _http;

        public PeopleService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ServiceResponse<List<People>>> GetPeopleAsync(int page = 1, int rowsPerPage = 18)
        {
            //var result = await _http.GetFromJsonAsync<ServiceResponse<List<People>>>($"people?currentPage={page}&rowsPerPage={rowsPerPage}");
            //return result;
            var httpResponse = await _http.GetAsync($"people?currentPage={page}&rowsPerPage={rowsPerPage}");
            if(httpResponse.IsSuccessStatusCode)
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ServiceResponse<List<People>>>(responseString, new JsonSerializerOptions() { PropertyNameCaseInsensitive=true });
                return result;
            }

            return null;
        }
    }

}
