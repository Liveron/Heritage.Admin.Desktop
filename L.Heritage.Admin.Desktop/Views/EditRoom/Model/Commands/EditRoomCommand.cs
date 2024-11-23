using L.Heritage.Admin.Desktop.Entities.Room.Model;
using L.Heritage.Admin.Desktop.Features.Rooms.Model;
using L.Heritage.Admin.Desktop.Shared.Lib.Commands;

namespace L.Heritage.Admin.Desktop.Views.EditRoom.Model.Commands;

public class EditRoomCommand(IRoomsService roomsService) : AsyncCommandBase
{
    private readonly IRoomsService _roomsService = roomsService;

    public override bool CanExecute(object? parameter)
    {
        return true;
    }

    public async override Task ExecuteAsync(object? parameter)
    {
        if (parameter is not Room room)
            return;

        await _roomsService.EditRoom(room);
    }
}
