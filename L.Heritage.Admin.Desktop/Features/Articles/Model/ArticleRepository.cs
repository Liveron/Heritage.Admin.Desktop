using L.Heritage.Admin.Desktop.Features.Articles.Api.DTO;
using L.Heritage.Admin.Desktop.Shared.Lib;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace L.Heritage.Admin.Desktop.Features.Articles.Model;


public class ArticleRepository(IHttpClientFactory httpClientFactory) : IArticleRepository
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    public async Task<MetadataList<ArticleDto>> GetArticles(GetArticlesParameters parameters)
    {
        using HttpClient client = _httpClientFactory.CreateClient("Default");

        try
        {
            HttpResponseMessage response = await client.GetAsync(
                $"articles?pageNumber={parameters.Page}&pageSize={parameters.PageSize}")
                .ConfigureAwait(false);

            var articles = await response.Content.ReadFromJsonAsync<MetadataList<ArticleDto>>()
                .ConfigureAwait(false);

            string? paginationHeader = response.Headers.GetValues("X-Pagination").FirstOrDefault();

            articles.MetaData = JsonSerializer.Deserialize<MetaData>(paginationHeader);

            return articles ?? [];
        }
        catch (Exception)
        {
            throw;
        }
    }
}
