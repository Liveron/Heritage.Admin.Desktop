using System.Windows;

namespace L.Heritage.Admin.Desktop.App;

public class AppStarter(MainWindow mainWindow) : Application
{
    private readonly MainWindow _mainWindow = mainWindow;

    protected override void OnStartup(StartupEventArgs e)
    {
        _mainWindow.Show(); 
        base.OnStartup(e);
    }
}
