using L.Heritage.Admin.Desktop.App.Routing.Commands;
using L.Heritage.Admin.Desktop.Shared.Lib.Commands;
using L.Heritage.Admin.Desktop.Shared.Lib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace L.Heritage.Admin.Desktop.Widgets.SideBar.Model;

public sealed class SideBarVM(IServiceProvider serviceProvider) : ViewModelBase
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    private readonly NavigateArticlesCommand? _navigateArticlesCommand;
    private readonly NavigateRoomsCommand? _navigateRoomsCommand;
    private readonly NavigateOrdersCommand? _navigateOrdersCommand;

    public NavigateArticlesCommand? NavigateArticlesCommand => HandleCommand(_navigateArticlesCommand);
    public NavigateRoomsCommand? NavigateRoomsCommand => HandleCommand(_navigateRoomsCommand);
    public NavigateOrdersCommand? NavigateOrdersCommand => HandleCommand(_navigateOrdersCommand);

    private T? HandleCommand<T>(T? command, [CallerMemberName] string name = "") where T : CommandBase
    {
        if (command != null)
            command.Executed -= (_, _) => OnPropertyChanged(name);

        command = _serviceProvider.GetService<T>();

        if (command != null)
            command.Executed += (_, _) => OnPropertyChanged(name);

        return command;
    }

    public override void Dispose() { }
}
