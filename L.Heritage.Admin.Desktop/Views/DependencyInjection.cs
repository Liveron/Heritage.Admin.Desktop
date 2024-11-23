using L.Heritage.Admin.Desktop.Views.CreateRoom.Model.Commands;
using L.Heritage.Admin.Desktop.Views.EditRoom.Model.Commands;
using L.Heritage.Admin.Desktop.Views.Model;
using L.Heritage.Admin.Desktop.Views.UI;
using Microsoft.Extensions.DependencyInjection;

namespace L.Heritage.Admin.Desktop.Views;

public static class DependencyInjection
{
    public static void AddViews(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddTransient<RoomsVM>();
        services.AddTransient<AuthVM>();
        services.AddTransient<ArticlesVM>();
        services.AddTransient<CreateRoomVM>();
        services.AddTransient<OrdersVM>();
    }

    private static void AddCommands(this IServiceCollection services)
    {
        services.AddTransient<CreateRoomCommand>();
        services.AddTransient<EditRoomCommand>();
    }
}
