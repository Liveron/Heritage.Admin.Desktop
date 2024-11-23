using L.Heritage.Admin.Desktop.Shared.Lib.Commands;
using L.Heritage.Admin.Desktop.Shared.Lib.ViewModels;
using L.Heritage.Admin.Desktop.Views.CreateRoom.Model.Commands;
using System.Windows.Media.Imaging;

namespace L.Heritage.Admin.Desktop.Views.Model;

public sealed class CreateRoomVM(CreateRoomCommand createRoomCommand) : ViewModelBase
{
    private int _roomNum;
    private BitmapImage? _image;
    private decimal _price;

    public int RoomNum 
    { 
        get => _roomNum; 
        set
        {
            _roomNum = value;
            OnPropertyChanged();
        }
    }

    public BitmapImage? Image
    {
        get => _image;
        set
        {
            _image = value;
            OnPropertyChanged();
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged();
        }
    }

    public CreateRoomCommand CreateRoomCommand { get; set; } = createRoomCommand;

    public override void Dispose() { }
}
