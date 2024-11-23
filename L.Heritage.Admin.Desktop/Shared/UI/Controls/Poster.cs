using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace L.Heritage.Admin.Desktop.Shared.UI.Controls;

[ContentProperty("Content")]
public class Poster : Control
{
    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(object), typeof(Poster), new PropertyMetadata(null));

    public object Title
    {
        get { return GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    public object Content
    {
        get { return GetValue(ContentProperty); }
        set { SetValue(ContentProperty, value); }
    }

    public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register("Content", typeof(object), typeof(Poster), new PropertyMetadata(null));

    static Poster()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(Poster), new FrameworkPropertyMetadata(typeof(Poster)));
    }
}
