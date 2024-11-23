using L.Heritage.Admin.Desktop.Entities.Order.Model;
using L.Heritage.Admin.Desktop.Shared.Lib;
using L.Heritage.Admin.Desktop.Shared.Lib.Commands;

namespace L.Heritage.Admin.Desktop.Features.Orders.Model.Commands;

public sealed class GetOrdersCommand(IOrdersService ordersService) : AsyncCommandBase<MetadataList<Order>>
{
    private readonly IOrdersService _ordersService = ordersService;

    public override event EventHandler<MetadataList<Order>>? Executed;

    public override bool CanExecute(object? parameter)
    {
        return true;
    }

    public async override Task ExecuteAsync(object? parameter)
    {
        if (parameter is not GetOrdersParameters parameters)
            return;

        MetadataList<Order> rooms = await _ordersService.GetOrders(parameters);
        OnExecuted(rooms);
    }

    private void OnExecuted(MetadataList<Order> rooms) => Executed?.Invoke(this, rooms);
}
