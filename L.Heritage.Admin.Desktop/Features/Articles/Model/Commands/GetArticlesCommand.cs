using L.Heritage.Admin.Desktop.Entities.Article.Model;
using L.Heritage.Admin.Desktop.Shared.Lib.Commands;
using L.Heritage.Admin.Desktop.Shared.Lib;

namespace L.Heritage.Admin.Desktop.Features.Articles.Model.Commands;

public class GetArticlesCommand(ArticlesService articlesService) : AsyncCommandBase<MetadataList<Article>>
{
    private readonly ArticlesService _articlesService = articlesService;

    public override event EventHandler<MetadataList<Article>>? Executed;

    public override bool CanExecute(object? parameter)
    {
        throw new NotImplementedException();
    }

    public override async Task ExecuteAsync(object? parameter)
    {
        if (parameter is not GetArticlesParameters parameters)
            return;

        MetadataList<Article> articles = await _articlesService.GetArticles(parameters);
        OnExecuted(articles);
    }

    private void OnExecuted(MetadataList<Article> articles) => Executed?.Invoke(this, articles); 
}
