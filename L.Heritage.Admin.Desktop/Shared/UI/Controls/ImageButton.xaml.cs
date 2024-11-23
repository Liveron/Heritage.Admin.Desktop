using L.Heritage.Admin.Desktop.Views.CreateRoom.Model.Commands;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace L.Heritage.Admin.Desktop.Shared.UI.Controls;

public partial class ImageButton : UserControl
{
    public static readonly DependencyProperty ImageProperty =
        DependencyProperty.Register("Image", typeof(BitmapImage), typeof(ImageButton), 
            new PropertyMetadata(null, OnImageChanged));

    public static readonly DependencyProperty ImageSetProperty =
        DependencyProperty.Register("ImageSet", typeof(bool), typeof(ImageButton), new PropertyMetadata(false));

    public BitmapImage Image
    {
        get { return (BitmapImage)GetValue(ImageProperty); }
        set { SetValue(ImageProperty, value); }
    }

    public bool ImageSet
    {
        get { return (bool)GetValue(ImageSetProperty); }
        set { SetValue(ImageSetProperty, value); }
    }

    public SetImageCommand SetImageCommand { get; set; }

    public ImageButton()
    {
        SetImageCommand = new SetImageCommand();
        SetImageCommand.Executed += OnImageChosen;
        InitializeComponent();
    }

    private void OnImageChosen(object? _, BitmapImage image)
    {
        Image = image;
    }

    private static void OnImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((ImageButton)d).ImageSet = true;
    }
}
