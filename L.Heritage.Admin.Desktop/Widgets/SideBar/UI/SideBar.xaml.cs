using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace L.Heritage.Admin.Desktop.Widgets.UI;

public partial class SideBar : UserControl
{
    public ICommand NavigateArticlesCommand
    {
        get { return (ICommand)GetValue(NavigateArticlesCommandProperty); }
        set { SetValue(NavigateArticlesCommandProperty, value); }
    }

    public static readonly DependencyProperty NavigateArticlesCommandProperty =
        DependencyProperty.Register("NavigateArticlesCommand", typeof(ICommand), typeof(SideBar), new PropertyMetadata(null));

    public SideBar()
    {
        InitializeComponent();
        DataContext = this;
    }
}
