using L.Heritage.Admin.Desktop.Features.Articles.Api.DTO;
using L.Heritage.Admin.Desktop.Shared.Lib;
using L.Heritage.Admin.Desktop.Shared.Model;

namespace L.Heritage.Admin.Desktop.Features.Articles.Model;

public class GetArticlesParameters : GetParametersBase { }

public interface IArticleRepository
{
    public Task<MetadataList<ArticleDto>> GetArticles(GetArticlesParameters parameters);
}
