using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace L.Heritage.Admin.Desktop.Shared.Api;

public class ApiUtils
{
    private readonly string _baseUrl;

    public ApiUtils(string baseUrl)
    {
         _baseUrl = baseUrl;
    }

    public async Task<TResponse?> PostAsync<TResponse, TBody>(string url, TBody data)
    {
        string json = JsonSerializer.Serialize(data);
        var httpContent = new StringContent(json, new MediaTypeHeaderValue("application/json"));
        var client = new HttpClient();
        using var response = await client.PostAsync(_baseUrl  + url, httpContent).ConfigureAwait(false);
        return await response.Content.ReadFromJsonAsync<TResponse>().ConfigureAwait(false);
    }

    public async Task<TResponse?> GetAsync<TResponse>(string url)
    {
        var client = new HttpClient();
        using var response = await client.GetAsync(_baseUrl + url).ConfigureAwait(false);
        return await response.Content.ReadFromJsonAsync<TResponse>().ConfigureAwait(false);
    }
}
