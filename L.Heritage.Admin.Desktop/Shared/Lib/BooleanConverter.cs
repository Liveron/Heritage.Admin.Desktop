using System.Globalization;
using System.Windows.Data;

namespace L.Heritage.Admin.Desktop.Shared.Lib;

public class BooleanConverter<T>(T trueValue, T falseValue) : IValueConverter
{
    public T True { get; set; } = trueValue;
    public T False { get; set; } = falseValue;

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is bool v && v ? True : False;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is T t && EqualityComparer<T>.Default.Equals(t, True);
    }
}
