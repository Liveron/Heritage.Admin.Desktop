using L.Heritage.Admin.Desktop.Entities.Article.Model;
using L.Heritage.Admin.Desktop.Features.Articles.Api.DTO;
using L.Heritage.Admin.Desktop.Shared.Lib;
using Mapster;
using System.Windows.Media.Imaging;

namespace L.Heritage.Admin.Desktop.Features.Articles.Model;

public interface IArticlesService
{
    public Task<MetadataList<Article>> GetArticles(GetArticlesParameters parameters);
}

public class ArticlesService(IArticleRepository articleRepository, ArticlesStore articlesStore) : IArticlesService
{
    private readonly IArticleRepository _articleRepository = articleRepository;
    private readonly ArticlesStore _articlesStore = articlesStore;

    public async Task<MetadataList<Article>> GetArticles(GetArticlesParameters parameters)
    {
        int totalItemsRequired = parameters.Page * parameters.PageSize;

        if (totalItemsRequired > _articlesStore.Articles.Count && _articlesStore.ServerHasNext)
        {
            MetadataList<ArticleDto> articleDtos = await _articleRepository.GetArticles(parameters)
                .ConfigureAwait(false);

           _articlesStore.ServerHasNext = articleDtos.MetaData.HasNext;

            var articles = new MetadataList<Article> { MetaData = articleDtos.MetaData };

            foreach (ArticleDto dto in articleDtos)
            {
                Article article = dto.Adapt<Article>();
                _articlesStore.Articles.Add(article);
                articles.Add(article);
            }

            return articles;
        }

        List<Article> storedArticles = _articlesStore.Articles
            .Skip(parameters.PageSize * (parameters.Page - 1))
            .Take(parameters.PageSize)
            .ToList();

        var metadata = new MetaData
        { HasNext = totalItemsRequired < _articlesStore.Articles.Count || _articlesStore.ServerHasNext };

        return new MetadataList<Article>(storedArticles, metadata);
    }
}
