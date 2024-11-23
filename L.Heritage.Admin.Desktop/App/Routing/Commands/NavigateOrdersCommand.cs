using L.Heritage.Admin.Desktop.Features.Navigation.Model;
using L.Heritage.Admin.Desktop.Shared.Lib.Commands;
using L.Heritage.Admin.Desktop.Views.Model;

namespace L.Heritage.Admin.Desktop.App.Routing.Commands;

public sealed class NavigateOrdersCommand(NavigationService navigationService, OrdersVM ordersVM) : CommandBase
{
    private readonly NavigationService _navigationService = navigationService;
    private readonly OrdersVM _ordersVM = ordersVM;

    public override event EventHandler? CanExecuteChanged;
    public override event EventHandler? Executed;

    public override bool CanExecute(object? parameter)
    {
        return true;
    }

    public override void Execute(object? _)
    {
        _navigationService.Navigate(_ordersVM);
        OnExecuted();
    }

    private void OnExecuted() => Executed?.Invoke(this, EventArgs.Empty);
}
