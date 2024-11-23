using L.Heritage.Admin.Desktop.Entities.Article.Model;

namespace L.Heritage.Admin.Desktop.Features.Articles.Model;

public sealed class ArticlesStore
{
    public List<Article> Articles { get; set; } = [];

    public bool ServerHasNext { get; set; } = true;
}
