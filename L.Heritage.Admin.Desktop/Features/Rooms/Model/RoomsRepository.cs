using L.Heritage.Admin.Desktop.Features.Rooms.Api;
using L.Heritage.Admin.Desktop.Shared.Lib;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace L.Heritage.Admin.Desktop.Features.Rooms.Model;

public class RoomsRepository(IHttpClientFactory httpClientFactory) : IRoomsRepository
{
    readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    public async Task CreateRoom(CreateRoomDto room)
    {
		using HttpClient client = _httpClientFactory.CreateClient("Authenticated");

		try
		{
			HttpResponseMessage response = await client.PostAsJsonAsync("rooms", room)
				.ConfigureAwait(false);
		}
		catch (Exception)
		{
			throw;
		}
    }

    public async Task<MetadataList<RoomDto>> GetRooms(GetRoomsParameters parameters)
    {
        using HttpClient client = _httpClientFactory.CreateClient("Default");

		try
		{
			HttpResponseMessage response = await client.GetAsync(
				$"rooms?pageNumber={parameters.Page}&pageSize={parameters.PageSize}");

			var rooms = await response.Content.ReadFromJsonAsync<MetadataList<RoomDto>>()
				.ConfigureAwait(false);

			string? paginationHeader = response.Headers.GetValues("X-Pagination").FirstOrDefault();

			rooms.MetaData = JsonSerializer.Deserialize<MetaData>(paginationHeader);

			return rooms ?? [];
		}
		catch (Exception)
		{
			throw;
		}
    }

	public async Task UpdateRoom(UpdateRoomDto room, int id)
	{
		using HttpClient client = _httpClientFactory.CreateClient("Authenticated");

		try
		{
			HttpResponseMessage response = await client.PutAsJsonAsync($"rooms/{id}", room)
				.ConfigureAwait(false);
		}
		catch (Exception)
		{
			throw;
		}
	}
}
