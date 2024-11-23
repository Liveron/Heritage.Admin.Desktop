namespace L.Heritage.Admin.Desktop.Shared.Lib.Commands;

public abstract class AsyncCommandBase : IAsyncCommand
{
    public event EventHandler? CanExecuteChanged;

    public abstract bool CanExecute(object? parameter);

    public async void Execute(object? parameter)
    {
        await ExecuteAsync(parameter);
    }

    public abstract Task ExecuteAsync(object? parameter);
}

public abstract class AsyncCommandBase<T> : AsyncCommandBase
{
    public abstract event EventHandler<T>? Executed;
}
