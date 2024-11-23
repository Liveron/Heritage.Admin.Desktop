using L.Heritage.Admin.Desktop.Shared.Lib.ViewModels;
using System.Windows.Input;

namespace L.Heritage.Admin.Desktop.Shared.Model;

public sealed class PaginationVM<T>(int page, int pageSize) : ViewModelBase
{
	private List<T> _values = [];

    private int _page = page;

	private int _pageSize = pageSize;

	private bool _hasNext;

    public List<T> Values
	{
		get => _values;
		set
		{
			_values = value;
			OnPropertyChanged();
		}
	}

    public int Page 
	{ 
		get => _page; 
		set
		{
			_page = value;
			OnPropertyChanged(nameof(HasPrevious));
		}
	}

    public bool HasNext
	{
		get => _hasNext;
		set 
		{ 
			_hasNext = value; 
			OnPropertyChanged();
		}
	}

    public int PageSize 
	{ 
		get => _pageSize; 
		set
		{
			_pageSize = value;
		}
	}

    public bool HasPrevious => _page > 1;

    public ICommand? NextPageCommand { get; set; }

    public ICommand? PrevPageCommand { get; set; }

    public override void Dispose() { }
}
