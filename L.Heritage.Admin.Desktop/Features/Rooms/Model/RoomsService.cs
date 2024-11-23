using L.Heritage.Admin.Desktop.Entities.Room.Model;
using L.Heritage.Admin.Desktop.Features.Rooms.Api;
using L.Heritage.Admin.Desktop.Shared.Lib;
using Mapster;

namespace L.Heritage.Admin.Desktop.Features.Rooms.Model;

public interface IRoomsService
{ 
    public Task<MetadataList<Room>> GetRooms(GetRoomsParameters parameters);
    public Task CreateRoom(CreateRoomDto room);
    public Task EditRoom(Room room);
}

public class RoomsService(IRoomsRepository roomsRepository, RoomsStore roomsStore) : IRoomsService
{
    private readonly IRoomsRepository _roomsRepository = roomsRepository;
    private readonly RoomsStore _roomsStore = roomsStore;

    public async Task<MetadataList<Room>> GetRooms(GetRoomsParameters parameters)
    {
        int totalItemsRequired = parameters.Page * parameters.PageSize;

        if (totalItemsRequired > _roomsStore.Rooms.Count && _roomsStore.ServerHasNext)
        {
            MetadataList<RoomDto> roomDtos = await _roomsRepository.GetRooms(parameters)
                .ConfigureAwait(false);

            _roomsStore.ServerHasNext = roomDtos.MetaData.HasNext;

            var rooms = new MetadataList<Room> { MetaData = roomDtos.MetaData };

            foreach (RoomDto dto in roomDtos)
            {
                Room room = dto.Adapt<Room>();
                _roomsStore.Rooms.Add(room);
                rooms.Add(room);
            }

            return rooms;
        }

        List<Room> storedRooms = _roomsStore.Rooms
            .Skip(parameters.PageSize * (parameters.Page - 1))
            .Take(parameters.PageSize)
            .ToList();

        var metadata = new MetaData
        { HasNext = totalItemsRequired < _roomsStore.Rooms.Count || _roomsStore.ServerHasNext, };

        return new MetadataList<Room>(storedRooms, metadata);
    }

    public async Task CreateRoom(CreateRoomDto room)
    {
        await _roomsRepository.CreateRoom(room);
    }

    public async Task EditRoom(Room room)
    {
        var updateRoomDto = new UpdateRoomDto(room.Price, room.Image.ToBase64());

        await _roomsRepository.UpdateRoom(updateRoomDto, room.RoomNum);
    }
}
