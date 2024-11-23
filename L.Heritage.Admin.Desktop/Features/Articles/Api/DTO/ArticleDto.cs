namespace L.Heritage.Admin.Desktop.Features.Articles.Api.DTO;

public record ArticleDto(Guid Id, string Content, string Title, ArticlePreviewDto Preview);
