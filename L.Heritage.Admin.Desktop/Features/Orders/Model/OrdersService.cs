using L.Heritage.Admin.Desktop.Entities.Order.Model;
using L.Heritage.Admin.Desktop.Features.Orders.Api;
using L.Heritage.Admin.Desktop.Shared.Lib;
using L.Heritage.Admin.Desktop.Shared.Model;
using Mapster;

namespace L.Heritage.Admin.Desktop.Features.Orders.Model;

public class GetOrdersParameters : GetParametersBase { }

public interface IOrdersService
{
    public Task<MetadataList<Order>> GetOrders(GetOrdersParameters parameters);
}

public class OrdersService(IOrderRepository orderRepository, OrdersStore ordersStore) : IOrdersService
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly OrdersStore _ordersStore = ordersStore;

    public async Task<MetadataList<Order>> GetOrders(GetOrdersParameters parameters)
    {
        int totalItemsRequired = parameters.Page * parameters.PageSize;

        if (totalItemsRequired > _ordersStore.Orders.Count && _ordersStore.ServerHasNext)
        {
            MetadataList<OrderDto> orderDtos = await _orderRepository.GetOrders(parameters)
                .ConfigureAwait(false);

            _ordersStore.ServerHasNext = orderDtos.MetaData.HasNext;

            var orders = new MetadataList<Order> { MetaData = orderDtos.MetaData };

            foreach (OrderDto dto in orderDtos)
            {
                Order order = dto.Adapt<Order>();
                _ordersStore.Orders.Add(order);
                orders.Add(order);
            }

            return orders;
        }

        List<Order> storedOrders = _ordersStore.Orders
            .Skip(parameters.PageSize * (parameters.Page - 1))
            .Take(parameters.PageSize)
            .ToList();

        var metadata = new MetaData
        { HasNext = totalItemsRequired < _ordersStore.Orders.Count || _ordersStore.ServerHasNext };

        return new MetadataList<Order>(storedOrders, metadata);
    }
}
