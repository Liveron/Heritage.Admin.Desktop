using System.Windows;

namespace L.Heritage.Admin.Desktop.App;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainWindowVM mainWindowVM)
    {
        InitializeComponent();
        DataContext = mainWindowVM;
    }
}