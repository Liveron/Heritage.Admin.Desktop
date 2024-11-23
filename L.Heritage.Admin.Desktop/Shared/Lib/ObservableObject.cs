using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace L.Heritage.Admin.Desktop.Shared.Lib;

public abstract class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string prop = "") => 
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}
