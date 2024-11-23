using L.Heritage.Admin.Desktop.Features.Authentication.Api.DTO;
using L.Heritage.Admin.Desktop.Features.Authentication.Model;
using L.Heritage.Admin.Desktop.Features.Navigation.Model;
using L.Heritage.Admin.Desktop.Shared.Lib.Commands;
using L.Heritage.Admin.Desktop.Views.Model;

namespace L.Heritage.Admin.Desktop.Features.Authentication.Api.Commands;

public sealed class SignInCommand(AuthService authService, NavigationService navigationService, ArticlesVM articlesVM) 
    : AsyncCommandBase
{
    private readonly AuthService _authService = authService;
    private readonly NavigationService _navigationService = navigationService;
    private readonly ArticlesVM _articlesVM = articlesVM;

    public override bool CanExecute(object? parameter)
    {
        return true;
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        ArgumentNullException.ThrowIfNull(parameter);

        if (parameter is LoginDto loginDto)
        {
            bool isAuthenticated = await _authService.Login(loginDto);
            if (isAuthenticated) 
                _navigationService.Navigate(_articlesVM);
        }
    }
}
