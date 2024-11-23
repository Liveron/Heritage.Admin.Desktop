using System.Windows.Input;

namespace L.Heritage.Admin.Desktop.Shared.Lib.Commands;

public class RelayCommand(Action<object?> execute) : ICommand
{
    private readonly Action<object?> _execute = execute;

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _execute.Invoke(parameter);
    }
}
