using System.Windows;

namespace L.Heritage.Admin.Desktop.Shared.Lib;

public class BoolToVIsibilityConverter() 
    : BooleanConverter<Visibility>(Visibility.Visible, Visibility.Collapsed)
{ }
