using L.Heritage.Admin.Desktop.Widgets.SideBar.Model;
using Microsoft.Extensions.DependencyInjection;

namespace L.Heritage.Admin.Desktop.Widgets;

public static class DependencyInjection
{
    public static void AddWidgets(this IServiceCollection services)
    {
        services.AddSingleton<SideBarVM>();
    }
}
