using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace L.Heritage.Admin.Desktop.Shared.UI.Controls;

[ContentProperty("Content")]
public class ArrowContainer : Control
{
    public static readonly DependencyProperty RightArrowCommandProperty =
        DependencyProperty.Register("RightArrowCommand", typeof(ICommand), typeof(ArrowContainer), new PropertyMetadata(null));

    public static readonly DependencyProperty LeftArrowCommandProperty =
        DependencyProperty.Register("LeftArrowCommand", typeof(ICommand), typeof(ArrowContainer), new PropertyMetadata(null));

    public static readonly DependencyProperty RightArrowVisibilityProperty =
        DependencyProperty.Register("RightArrowVisibility", typeof(Visibility), typeof(ArrowContainer), new PropertyMetadata(Visibility.Visible));

    public static readonly DependencyProperty LeftArrowVisibilityProperty =
        DependencyProperty.Register("LeftArrowVisibility", typeof(Visibility), typeof(ArrowContainer), new PropertyMetadata(Visibility.Visible));
    
    public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register("Content", typeof(object), typeof(ArrowContainer), new PropertyMetadata(null));

    public ICommand RightArrowCommand
    {
        get { return (ICommand)GetValue(RightArrowCommandProperty); }
        set { SetValue(RightArrowCommandProperty, value); }
    }

    public ICommand LeftArrowCommand
    {
        get { return (ICommand)GetValue(LeftArrowCommandProperty); }
        set { SetValue(LeftArrowCommandProperty, value); }
    }

    public Visibility RightArrowVisibility
    {
        get { return (Visibility)GetValue(RightArrowVisibilityProperty); }
        set { SetValue(RightArrowVisibilityProperty, value); }
    }

    public Visibility LeftArrowVisibility
    {
        get { return (Visibility)GetValue(LeftArrowVisibilityProperty); }
        set { SetValue(LeftArrowVisibilityProperty, value); }
    }

    public object Content
    {
        get { return GetValue(ContentProperty); }
        set { SetValue(ContentProperty, value); }
    }

    static ArrowContainer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ArrowContainer), new FrameworkPropertyMetadata(typeof(ArrowContainer)));
    }
}
