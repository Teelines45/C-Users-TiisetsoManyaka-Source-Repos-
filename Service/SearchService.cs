using AppSolultion2._0.Models;
using System.Net.Http.Json;


namespace AppSolultion2._0.SearchService;

internal class SearchService
{
    private readonly HttpClient _httpClient;

    public SearchService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(Constants.API_BASE_URL);

    }

    public async Task<MarkModel> GetSearchResults(string latitude, string longitude)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            return null;
        }

        return await _httpClient.GetFromJsonAsync<MarkModel>($"current?access_key={Constants.API_KEY}&query={latitude},{longitude}");
    }
}
