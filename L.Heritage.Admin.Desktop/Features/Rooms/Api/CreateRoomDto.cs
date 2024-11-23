namespace L.Heritage.Admin.Desktop.Features.Rooms.Api;

public class CreateRoomDto
{
    public int Id { get; init; }
    public string Image { get; init; } = string.Empty;
    public decimal Price { get; init; }
}
