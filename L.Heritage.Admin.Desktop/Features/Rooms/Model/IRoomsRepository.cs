using L.Heritage.Admin.Desktop.Features.Rooms.Api;
using L.Heritage.Admin.Desktop.Shared.Lib;
using L.Heritage.Admin.Desktop.Shared.Model;

namespace L.Heritage.Admin.Desktop.Features.Rooms.Model;

public class GetRoomsParameters : GetParametersBase { }

public interface IRoomsRepository
{
    public Task<MetadataList<RoomDto>> GetRooms(GetRoomsParameters parameters);
    public Task CreateRoom(CreateRoomDto room);
    public Task UpdateRoom(UpdateRoomDto room, int id);
}
