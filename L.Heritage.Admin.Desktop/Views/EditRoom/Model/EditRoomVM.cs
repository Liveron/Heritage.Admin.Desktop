using L.Heritage.Admin.Desktop.Features.Rooms.Model;
using L.Heritage.Admin.Desktop.Shared.Lib.ViewModels;
using L.Heritage.Admin.Desktop.Views.EditRoom.Model.Commands;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace L.Heritage.Admin.Desktop.Views.Model;

public sealed class EditRoomVM(RoomCardVM roomCardVM, EditRoomCommand editRoomCommand) : ViewModelBase
{
    private int _roomNum = roomCardVM.RoomNum;
    private BitmapImage? _image = roomCardVM.Image;
    private decimal _price = roomCardVM.Price;

    public ICommand EditRoomCommand { get; set; } = editRoomCommand;

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

    public override void Dispose() { }
}
