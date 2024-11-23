using L.Heritage.Admin.Desktop.Entities.Article.Model;
using L.Heritage.Admin.Desktop.Features.Articles.Model;
using L.Heritage.Admin.Desktop.Features.Articles.Model.Commands;
using L.Heritage.Admin.Desktop.Shared.Lib;
using L.Heritage.Admin.Desktop.Shared.Lib.Commands;
using L.Heritage.Admin.Desktop.Shared.Lib.ViewModels;
using L.Heritage.Admin.Desktop.Shared.Model;
using Mapster;

namespace L.Heritage.Admin.Desktop.Views.Model;

public sealed class ArticlesVM : ViewModelBase
{
    private readonly GetArticlesCommand _getArticlesCommand;

    public PaginationVM<ArticleCardVM> ArticlesPaginationVM { get; private set; }

    public ArticlesVM(GetArticlesCommand getArticlesCommand)
    {
        ArticlesPaginationVM = new PaginationVM<ArticleCardVM>(1, 3)
        {
            NextPageCommand = new RelayCommand(NextPage),
            PrevPageCommand = new RelayCommand(PrevPage)
        };
        _getArticlesCommand = getArticlesCommand;
        _getArticlesCommand.Executed += OnGetArticlesExecuted;
        _getArticlesCommand.Execute(new GetArticlesParameters
        {
            Page = ArticlesPaginationVM.Page,
            PageSize = ArticlesPaginationVM.PageSize,
        });
    }

    private void OnGetArticlesExecuted(object? _, MetadataList<Article> articles)
    {
        ArticlesPaginationVM.Values = articles.Adapt<List<ArticleCardVM>>();
        ArticlesPaginationVM.HasNext = articles.MetaData.HasNext;
    }

    private void NextPage(object? parameter)
    {
        _getArticlesCommand.Execute(new GetArticlesParameters
        {
            Page = ++ArticlesPaginationVM.Page,
            PageSize = ArticlesPaginationVM.PageSize,
        });
    }

    private void PrevPage(object? parameter)
    {
        _getArticlesCommand.Execute(new GetArticlesParameters
        {
            Page = --ArticlesPaginationVM.Page,
            PageSize = ArticlesPaginationVM.PageSize,
        });
    }

    public override void Dispose() 
    {
        _getArticlesCommand.Executed -= OnGetArticlesExecuted;
    }
}
