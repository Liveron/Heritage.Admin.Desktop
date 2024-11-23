using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace L.Heritage.Admin.Desktop.Features.UI;

public partial class RoomCard : UserControl
{
    public static readonly DependencyProperty CommandParameterProperty =
        DependencyProperty.Register("CommandParameter", typeof(object), typeof(RoomCard), new PropertyMetadata(null));

    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register("Command", typeof(ICommand), typeof(RoomCard), new PropertyMetadata(null));

    public object? CommandParameter
    {
        get { return GetValue(CommandParameterProperty); }
        set { SetValue(CommandParameterProperty, value); }
    }

    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }

    public RoomCard()
    {
        InitializeComponent();
    }
}
