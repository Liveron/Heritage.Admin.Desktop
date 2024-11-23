using System.Windows;
using System.Windows.Controls.Primitives;

namespace L.Heritage.Admin.Desktop.Widgets.UI;

public class NavButton : ButtonBase
{
    public static readonly DependencyProperty NavUriProperty =
        DependencyProperty.Register("NavUri", typeof(Uri), typeof(NavButton), new PropertyMetadata(null));

    public Uri NavUri
    {
        get { return (Uri)GetValue(NavUriProperty); }
        set { SetValue(NavUriProperty, value); }
    }

    static NavButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NavButton), new FrameworkPropertyMetadata(typeof(NavButton)));
    }
}
