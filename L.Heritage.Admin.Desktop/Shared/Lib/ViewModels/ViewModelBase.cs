using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace L.Heritage.Admin.Desktop.Shared.Lib.ViewModels;

public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public abstract void Dispose();

    public void OnPropertyChanged([CallerMemberName] string prop = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}
