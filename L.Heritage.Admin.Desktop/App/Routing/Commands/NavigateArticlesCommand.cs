using L.Heritage.Admin.Desktop.Features.Navigation.Model;
using L.Heritage.Admin.Desktop.Shared.Lib.Commands;
using L.Heritage.Admin.Desktop.Views.Model;

namespace L.Heritage.Admin.Desktop.App.Routing.Commands;

public class NavigateArticlesCommand(NavigationService navigationService, ArticlesVM articlesVM) : CommandBase
{
    private readonly NavigationService _navigationService = navigationService;
    private readonly ArticlesVM _articlesV = articlesVM;

    public override event EventHandler? CanExecuteChanged;

    public override event EventHandler? Executed;

    public override bool CanExecute(object? parameter)
    {
        return true;
    }

    public override void Execute(object? parameter)
    {
        _navigationService.Navigate(_articlesV);
        OnExecuted();
    }

    private void OnExecuted() => Executed?.Invoke(this, EventArgs.Empty);
}
