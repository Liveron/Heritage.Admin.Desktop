using L.Heritage.Admin.Desktop.Features.Navigation.Model;
using L.Heritage.Admin.Desktop.Views.Model;
using System.Windows.Input;

namespace L.Heritage.Admin.Desktop.App.Routing.Commands;

public class NavigateCreateRoomCommand(NavigationService navigationService, CreateRoomVM createRoomVM) : ICommand
{
    private readonly NavigationService _navigationService = navigationService;
    private readonly CreateRoomVM _createRoomVM = createRoomVM;

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _navigationService.Navigate(_createRoomVM);
    }
}
