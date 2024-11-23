using L.Heritage.Admin.Desktop.Shared.Lib.ViewModels;

namespace L.Heritage.Admin.Desktop.Features.Navigation.Model;

public interface INavigationService
{
    public void Navigate<TViewModel>(Func<TViewModel> vmFabric) where TViewModel : ViewModelBase;
}
