using L.Heritage.Admin.Desktop.Features.Articles.Api.DTO;
using Microsoft.Extensions.DependencyInjection;
using Mapster;
using L.Heritage.Admin.Desktop.Entities.Article.Model;
using System.Windows.Media.Imaging;
using L.Heritage.Admin.Desktop.Shared.Lib;

namespace L.Heritage.Admin.Desktop.Features.Articles.Config;

public static partial class MappingConfig
{   
    public static void ConfigureArticleMappgins(this IServiceCollection _)
    {
        TypeAdapterConfig<ArticlePreviewDto, ArticlePreview>.NewConfig()
            .Map(dest => dest.Image, src => new BitmapImage().FromBase64(src.Image));
    }
}
