using L.Heritage.Admin.Desktop.Shared.Lib.ViewModels;

namespace L.Heritage.Admin.Desktop.Features.Navigation.Model;

public class NavigationStore : INavigator
{
    public event Action? CurrentVMChanged;

    private ViewModelBase? _currentVM;

    public ViewModelBase? CurrentVM
    {
        get => _currentVM;
        set
        {
            _currentVM = value;
            OnCurrentVMChanged();
        }
    }

    public void Navigate(ViewModelBase viewModel)
    {
        CurrentVM?.Dispose();
        CurrentVM = viewModel;
    }

    private void OnCurrentVMChanged() => CurrentVMChanged?.Invoke();
}
