using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace L.Heritage.Admin.Desktop.Features.Rooms.Model;

public sealed class RoomCardVM
{
    public int RoomNum { get; set; }
    public BitmapImage? Image { get; set; }
    public decimal Price { get; set; }
    public ICommand? NavigateEditRoomCommand { get; set; }
}
