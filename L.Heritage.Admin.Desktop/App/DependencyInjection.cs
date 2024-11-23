using L.Heritage.Admin.Desktop.App.Routing.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace L.Heritage.Admin.Desktop.App;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddTransient<NavigateArticlesCommand>();
        services.AddTransient<NavigateRoomsCommand>();
        services.AddTransient<NavigateCreateRoomCommand>();
        services.AddTransient<NavigateEditRoomCommand>();
        services.AddTransient<NavigateOrdersCommand>();
        services.AddSingleton<MainWindowVM>();
        services.AddSingleton<MainWindow>();
        services.AddSingleton<AppStarter>();
    }
}
