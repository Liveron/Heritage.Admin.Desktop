using L.Heritage.Admin.Desktop.Shared.Lib.ViewModels;

namespace L.Heritage.Admin.Desktop.Features.Navigation.Model;

public interface INavigator
{
    public void Navigate(ViewModelBase viewModel);
}
