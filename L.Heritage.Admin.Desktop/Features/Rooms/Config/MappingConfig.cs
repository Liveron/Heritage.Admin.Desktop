using L.Heritage.Admin.Desktop.Entities.Room.Model;
using L.Heritage.Admin.Desktop.Features.Rooms.Api;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Media.Imaging;
using L.Heritage.Admin.Desktop.Shared.Lib;
using L.Heritage.Admin.Desktop.Features.Rooms.Model;
using Mapster;

namespace L.Heritage.Admin.Desktop.Features.Rooms.Config;

public static partial class MappingConfig
{
    public static void ConfigureRoomMappings(this IServiceCollection _)
    {
        TypeAdapterConfig<RoomDto, Room>.NewConfig()
            .Ignore(dest => dest.Image!)
            .ConstructUsing(src => new Room
            {
                Image = new BitmapImage().FromBase64(src.Image),
                Price = src.Price,
                RoomNum = src.Id,
            });

        TypeAdapterConfig<Room, RoomCardVM>.NewConfig()
            .Ignore(dest => dest.Image!)
            .ConstructUsing(src => new RoomCardVM
            {
                Image = src.Image,
                Price = src.Price,
                RoomNum = src.RoomNum,
            });
    }
}
