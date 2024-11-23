using L.Heritage.Admin.Desktop.Features.Navigation.Model;
using L.Heritage.Admin.Desktop.Shared.Lib.Commands;
using L.Heritage.Admin.Desktop.Views.Model;

namespace L.Heritage.Admin.Desktop.App.Routing.Commands;

public class NavigateRoomsCommand(NavigationService navigationService, RoomsVM roomsVM) : CommandBase
{
    private readonly NavigationService _navigationService = navigationService;
    private readonly RoomsVM _roomsVM = roomsVM;

    public override event EventHandler? CanExecuteChanged;

    public override event EventHandler? Executed;

    public override bool CanExecute(object? parameter)
    {
        return true;
    }

    public override void Execute(object? parameter)
    {
        _navigationService.Navigate(_roomsVM);
        OnExecuted();
    }

    private void OnExecuted() => Executed?.Invoke(this, EventArgs.Empty);
}
