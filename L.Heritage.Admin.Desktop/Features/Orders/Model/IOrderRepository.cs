using L.Heritage.Admin.Desktop.Features.Orders.Api;
using L.Heritage.Admin.Desktop.Shared.Lib;

namespace L.Heritage.Admin.Desktop.Features.Orders.Model;

public interface IOrderRepository
{
    public Task<MetadataList<OrderDto>> GetOrders(GetOrdersParameters parameters);
}