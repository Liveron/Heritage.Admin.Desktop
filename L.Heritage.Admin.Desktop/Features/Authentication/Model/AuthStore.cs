namespace L.Heritage.Admin.Desktop.Features.Authentication.Model;

public sealed class AuthStore
{
    private bool _isAuthenticated; 

    public bool IsAuthenticated 
    {
        get => _isAuthenticated; 
        set
        {
            _isAuthenticated = value;
            OnAuthChanged();
        }
    }

    public event Action? AuthChanged;

    private void OnAuthChanged() => AuthChanged?.Invoke();
}
