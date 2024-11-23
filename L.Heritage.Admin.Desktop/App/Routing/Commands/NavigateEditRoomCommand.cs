using L.Heritage.Admin.Desktop.Features.Navigation.Model;
using L.Heritage.Admin.Desktop.Features.Rooms.Model;
using L.Heritage.Admin.Desktop.Shared.Lib.Commands;
using L.Heritage.Admin.Desktop.Views.EditRoom.Model.Commands;
using L.Heritage.Admin.Desktop.Views.Model;

namespace L.Heritage.Admin.Desktop.App.Routing.Commands;

public class NavigateEditRoomCommand(NavigationService navigationService, EditRoomCommand editRoomCommand) : CommandBase
{
    private readonly NavigationService _navigationService = navigationService;
    private readonly EditRoomCommand _editRoomCommand = editRoomCommand; 

    public override event EventHandler? CanExecuteChanged;
    public override event EventHandler? Executed;

    public override bool CanExecute(object? parameter)
    {
        return true;
    }

    public override void Execute(object? parameter)
    {
        if (parameter is not RoomCardVM roomCardVM)
            return;

        _navigationService.Navigate(new EditRoomVM(roomCardVM, _editRoomCommand));
    }
}
