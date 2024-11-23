using L.Heritage.Admin.Desktop.Features.Rooms.Api;
using L.Heritage.Admin.Desktop.Features.Rooms.Model;
using L.Heritage.Admin.Desktop.Shared.Lib.Commands;

namespace L.Heritage.Admin.Desktop.Views.CreateRoom.Model.Commands;

public class CreateRoomCommand(IRoomsService roomsService) : AsyncCommandBase
{
    private readonly IRoomsService _roomsService = roomsService;

    public override bool CanExecute(object? parameter)
    {
        return true;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        if (parameter is not CreateRoomDto room)
            return;

        await _roomsService.CreateRoom(room);
    }
}
