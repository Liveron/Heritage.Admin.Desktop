using L.Heritage.Admin.Desktop.Entities.Order.Model;

namespace L.Heritage.Admin.Desktop.Features.Orders.Model;

public class OrdersStore
{
    public List<Order> Orders { get; set; } = [];

    public bool ServerHasNext { get; set; } = true;
}
