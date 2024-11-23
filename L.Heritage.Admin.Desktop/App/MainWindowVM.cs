using L.Heritage.Admin.Desktop.Features.Authentication.Model;
using L.Heritage.Admin.Desktop.Features.Navigation.Model;
using L.Heritage.Admin.Desktop.Shared.Lib.ViewModels;
using L.Heritage.Admin.Desktop.Views.Model;
using L.Heritage.Admin.Desktop.Widgets.SideBar.Model;
using Microsoft.Extensions.DependencyInjection;

namespace L.Heritage.Admin.Desktop.App;

public sealed class MainWindowVM : ViewModelBase
{
    private readonly IServiceProvider _serviceProvider;

    private SideBarVM? _sideBarVM;

    public SideBarVM? SideBarVM
    {
        get => _sideBarVM;
        set 
        { 
            _sideBarVM = value;
            OnPropertyChanged();
        }
    }

    private readonly NavigationStore _navigationStore;
    private readonly AuthStore _authStore;

    public ViewModelBase? CurrentVM => _navigationStore.CurrentVM;
    public bool IsAuthenticated => _authStore.IsAuthenticated;    

    public MainWindowVM(NavigationStore navigationStore, AuthStore authStore, 
        AuthVM authVM, IServiceProvider serviceProvider)
    {
        _navigationStore = navigationStore;
        _authStore = authStore;
        _navigationStore.CurrentVM = authVM;
        _navigationStore.CurrentVMChanged += OnCurrentVMChanged;
        _authStore.AuthChanged += OnAuthChanged;
        _serviceProvider = serviceProvider;
    }

    private void OnAuthChanged()
    {
        SideBarVM = _serviceProvider.GetService<SideBarVM>();
        OnPropertyChanged(nameof(IsAuthenticated));
    }
    private void OnCurrentVMChanged() => OnPropertyChanged(nameof(CurrentVM));

    public override void Dispose() { }
}
