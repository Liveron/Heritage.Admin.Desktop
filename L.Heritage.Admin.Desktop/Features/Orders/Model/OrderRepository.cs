using L.Heritage.Admin.Desktop.Features.Orders.Api;
using L.Heritage.Admin.Desktop.Shared.Lib;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace L.Heritage.Admin.Desktop.Features.Orders.Model;

public class OrderRepository(IHttpClientFactory httpClientFactory) : IOrderRepository
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    public async Task<MetadataList<OrderDto>> GetOrders(GetOrdersParameters parameters)
    {
        using HttpClient client = _httpClientFactory.CreateClient("Authenticated");

		try
		{
			HttpResponseMessage response = await client.GetAsync(
                $"orders?pageNumber={parameters.Page}&pageSize={parameters.PageSize}")
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var orders = await response.Content.ReadFromJsonAsync<MetadataList<OrderDto>>()
                .ConfigureAwait(false);

            string? paginationHeader = response.Headers.GetValues("X-Pagination").FirstOrDefault();

            orders.MetaData = JsonSerializer.Deserialize<MetaData>(paginationHeader);

            return orders ?? [];
        }
		catch (InvalidOperationException)
		{
            return [];
		}
    }
}
