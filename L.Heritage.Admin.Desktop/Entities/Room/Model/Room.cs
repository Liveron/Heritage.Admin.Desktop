using System.Windows.Media.Imaging;

namespace L.Heritage.Admin.Desktop.Entities.Room.Model;

public class Room
{
    public int RoomNum { get; init; }
    public BitmapImage? Image { get; init; }
    public decimal Price { get; init; }
}
