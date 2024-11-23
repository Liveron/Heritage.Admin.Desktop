namespace L.Heritage.Admin.Desktop.Features.Orders.Api;

public record class OrderDto(Guid Id, DateTime Start, DateTime End, int RoomId, string UserName);
