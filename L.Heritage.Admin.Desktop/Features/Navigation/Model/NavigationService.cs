using L.Heritage.Admin.Desktop.Shared.Lib.ViewModels;

namespace L.Heritage.Admin.Desktop.Features.Navigation.Model;

public class NavigationService(NavigationStore navigator) : INavigationService
{
    private readonly NavigationStore _navigator = navigator;

    public void Navigate<TViewModel>(Func<TViewModel> vmFabric) where TViewModel : ViewModelBase
    {
        _navigator.Navigate(vmFabric());
    }

    public void Navigate<TViewModel>() where TViewModel : ViewModelBase, new()
    {
        _navigator.Navigate(new TViewModel());
    }

    public void Navigate(ViewModelBase viewModel)
    {
        _navigator.Navigate(viewModel);
    }
}
