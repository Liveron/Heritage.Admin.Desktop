using L.Heritage.Admin.Desktop.Entities.Room.Model;
using L.Heritage.Admin.Desktop.Features.Rooms.Model;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace L.Heritage.Admin.Desktop.Views.EditRoom.Lib;

public class RoomConverter : IMultiValueConverter
{
    public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Any(value => value == DependencyProperty.UnsetValue)) 
            return null;

        var roomNum = (int)values[0];
        var image = (BitmapImage)values[1];
        var price = (decimal)values[2];
        return new Room { RoomNum = roomNum, Image = image, Price = price };
    }

    public object[]? ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) 
    { return null; }
}
