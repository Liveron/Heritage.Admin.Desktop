namespace L.Heritage.Admin.Desktop.Entities.Article.Model;

public class Article
{
    public Guid Id { get; init; }
    public string Content { get; init; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public ArticlePreview? Preview { get; set; }
}
