using System.Windows.Media.Imaging;

namespace L.Heritage.Admin.Desktop.Entities.Article.Model;

public class ArticlePreview
{
    public Guid ArticleId { get; set; }
    public BitmapImage? Image { get; set; }
    public string Title { get; set; } = string.Empty;
}
