using L.Heritage.Admin.Desktop.Shared.Lib.ViewModels;
using System.ComponentModel;

namespace L.Heritage.Admin.Desktop.Features.Orders.Model;

public sealed class OrderRowVM : ViewModelBase
{
    private Guid _id;
    private DateTime _start;
    private DateTime _end;
    private int _roomId;
    private string _userName = string.Empty;
    private bool _isChanged;

    public Guid Id 
    { 
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged();
        } 
    }

    public DateTime Start 
    { 
        get => _start; 
        set
        {
            _start = value;
            OnPropertyChanged();
        }
    }

    public DateTime End 
    { 
        get => _end; 
        set
        {
            _end = value;
            OnPropertyChanged();
        }
    }
    public int RoomId 
    { 
        get => _roomId; 
        set
        {
            _roomId = value;
            OnPropertyChanged();
        }
    }

    public string UserName 
    { 
        get => _userName; 
        set
        {
            _userName = value;
            OnPropertyChanged();
        }
    }

    public bool IsChanged
    {
        get => _isChanged;
        set 
        { 
            _isChanged = value;
            OnPropertyChanged();
        }
    }

    public OrderRowVM()
    {
        PropertyChanged += HandlePropertyChanged;
    }

    private void HandlePropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(IsChanged))
            IsChanged = true;
    }

    public override void Dispose() 
    {
        PropertyChanged -= HandlePropertyChanged;
    }
}
