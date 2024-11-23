using System.Windows.Media.Imaging;

namespace L.Heritage.Admin.Desktop.Features.Articles.Model;

public class ArticleCardVM
{
    public string Title { get; init; } = string.Empty;
    public BitmapImage? Image { get; init; }
}
