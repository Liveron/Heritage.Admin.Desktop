using L.Heritage.Admin.Desktop.App;
using L.Heritage.Admin.Desktop.Features;
using L.Heritage.Admin.Desktop.Shared;
using L.Heritage.Admin.Desktop.Views;
using L.Heritage.Admin.Desktop.Widgets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace L.Heritage.Admin.Desktop;

sealed class Program
{
    [STAThread]
    public static void Main()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddShared();
                services.AddFeatures();
                services.AddWidgets();
                services.AddViews();
                services.AddApplication();
            })
            .Build();

        var app = host.Services.GetService<AppStarter>();
        app?.Run();
    }
}
