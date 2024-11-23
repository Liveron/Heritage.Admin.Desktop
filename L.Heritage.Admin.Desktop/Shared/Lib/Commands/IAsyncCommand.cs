using System.Windows.Input;

namespace L.Heritage.Admin.Desktop.Shared.Lib.Commands;

interface IAsyncCommand : ICommand
{
    Task ExecuteAsync(object parameter);
}
