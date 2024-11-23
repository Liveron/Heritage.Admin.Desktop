namespace L.Heritage.Admin.Desktop.Entities.Order.Model;

public class Order
{
    public Guid Id { get; init; }
    public DateTime Start { get; init; }
    public DateTime End { get; init; }
    public int RoomId { get; init; }
    public string UserName { get; init; } = string.Empty;
}
