using L.Heritage.Admin.Desktop.Features.Authentication.Api.DTO;
using System.Globalization;
using System.Windows.Data;

namespace L.Heritage.Admin.Desktop.Features.Authentication.Lib;

public class LoginConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return new LoginDto
        {
            UserName = values[0].ToString() ?? string.Empty,
            Password = values[1].ToString() ?? string.Empty,
        };
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
