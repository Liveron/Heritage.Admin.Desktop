using System.Windows;
using System.Windows.Controls;

namespace L.Heritage.Admin.Desktop.Shared.UI.Controls;

/// <summary>
/// Логика взаимодействия для Input.xaml
/// </summary>
public partial class Input : UserControl
{
    public string Label
    {
        get { return (string)GetValue(LabelProperty); }
        set { SetValue(LabelProperty, value); }
    }

    public static readonly DependencyProperty LabelProperty =
        DependencyProperty.Register("Label", typeof(string), typeof(Input), new PropertyMetadata(string.Empty));

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(Input), new PropertyMetadata(string.Empty));

    public Input()
    {
        InitializeComponent();
        DataContext = this;
    }
}
