using L.Heritage.Admin.Desktop.Features.Orders.Model;
using L.Heritage.Admin.Desktop.Shared.Lib.ViewModels;
using L.Heritage.Admin.Desktop.Shared.Model;
using L.Heritage.Admin.Desktop.Shared.Lib.Commands;
using L.Heritage.Admin.Desktop.Features.Orders.Model.Commands;
using L.Heritage.Admin.Desktop.Shared.Lib;
using L.Heritage.Admin.Desktop.Entities.Order.Model;
using Mapster;

namespace L.Heritage.Admin.Desktop.Views.Model;

public sealed class OrdersVM : ViewModelBase
{
    private readonly GetOrdersCommand _getOrdersCommand;

    public PaginationVM<OrderRowVM> OrdersPaginationVM { get; private set; }

    public OrdersVM(GetOrdersCommand getOrdersCommand)
    {
        OrdersPaginationVM = new PaginationVM<OrderRowVM>(1, 6)
        {
            NextPageCommand = new RelayCommand(NextPage),
            PrevPageCommand = new RelayCommand(PrevPage),
        };
        _getOrdersCommand = getOrdersCommand;
        _getOrdersCommand.Executed += OnGetOrdersExecuted;
        _getOrdersCommand.Execute(new GetOrdersParameters
        {
            Page = OrdersPaginationVM.Page,
            PageSize = OrdersPaginationVM.PageSize,
        });
    }

    private void NextPage(object? _)
    {
        _getOrdersCommand.Execute(new GetOrdersParameters
        {
            Page = ++OrdersPaginationVM.Page,
            PageSize = OrdersPaginationVM.PageSize,
        });
    }

    private void PrevPage(object? _)
    {
        _getOrdersCommand.Execute(new GetOrdersParameters
        {
            Page = --OrdersPaginationVM.Page,
            PageSize = OrdersPaginationVM.PageSize,
        });
    }

    private void OnGetOrdersExecuted(object? _, MetadataList<Order> orders)
    {
        OrdersPaginationVM.Values = orders.Adapt<List<OrderRowVM>>();
        OrdersPaginationVM.HasNext = orders.MetaData.HasNext;
    }

    public override void Dispose() 
    {
        _getOrdersCommand.Executed -= OnGetOrdersExecuted;
    }
}
