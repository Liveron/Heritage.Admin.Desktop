using L.Heritage.Admin.Desktop.Entities.Room.Model;

namespace L.Heritage.Admin.Desktop.Features.Rooms.Model;

public class RoomsStore
{
    public List<Room> Rooms { get; set; } = [];

    public bool ServerHasNext { get; set; } = true;
}
