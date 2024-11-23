using System.Windows.Input;

namespace L.Heritage.Admin.Desktop.Shared.Lib.Commands;

public abstract class CommandBase<T> : ICommand
{
    public abstract event EventHandler? CanExecuteChanged;

    public abstract event EventHandler<T> Executed;

    public abstract bool CanExecute(object? parameter);

    public abstract void Execute(object? parameter);
}

public abstract class CommandBase : ICommand
{
    public abstract event EventHandler? CanExecuteChanged;

    public abstract event EventHandler? Executed;

    public abstract bool CanExecute(object? parameter);

    public abstract void Execute(object? parameter);
}
