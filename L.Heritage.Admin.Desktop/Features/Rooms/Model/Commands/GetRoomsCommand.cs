using L.Heritage.Admin.Desktop.Entities.Room.Model;
using L.Heritage.Admin.Desktop.Shared.Lib;
using L.Heritage.Admin.Desktop.Shared.Lib.Commands;

namespace L.Heritage.Admin.Desktop.Features.Rooms.Model.Commands;

public class GetRoomsCommand(IRoomsService roomsService) : AsyncCommandBase<MetadataList<Room>>
{
    private readonly IRoomsService _roomsService = roomsService;

    public override event EventHandler<MetadataList<Room>>? Executed;

    public override bool CanExecute(object? parameter)
    {
        return true;
    }

    public async override Task ExecuteAsync(object? parameter)
    {
        if (parameter is not GetRoomsParameters parameters)
            return;

        MetadataList<Room> rooms = await _roomsService.GetRooms(parameters);
        OnExecuted(rooms);
    }

    private void OnExecuted(MetadataList<Room> rooms) => Executed?.Invoke(this, rooms);
}
