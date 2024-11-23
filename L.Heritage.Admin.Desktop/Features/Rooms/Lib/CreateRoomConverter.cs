using L.Heritage.Admin.Desktop.Features.Rooms.Api;
using L.Heritage.Admin.Desktop.Shared.Lib;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace L.Heritage.Admin.Desktop.Features.Rooms.Lib;

public class CreateRoomConverter : IMultiValueConverter
{
    public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Any(x => x == DependencyProperty.UnsetValue))
            return null;

        string base64Image = string.Empty;
        if (values[1] is BitmapImage image)
        {
            base64Image = image.ToBase64();
        }

        return new CreateRoomDto
        {
            Id = (int)values[0],
            Image = base64Image,
            Price = (decimal)values[2],
        };
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
