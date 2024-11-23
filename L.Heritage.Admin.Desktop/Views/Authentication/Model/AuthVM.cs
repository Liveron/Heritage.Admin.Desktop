using L.Heritage.Admin.Desktop.Features.Authentication.Api.Commands;
using L.Heritage.Admin.Desktop.Shared.Lib.ViewModels;
using System.Windows.Input;

namespace L.Heritage.Admin.Desktop.Views.Model;

public sealed class AuthVM(SignInCommand signInCommand) : ViewModelBase
{
    public ICommand SignInCommand { get; set; } = signInCommand;

    public override void Dispose() { }
}
