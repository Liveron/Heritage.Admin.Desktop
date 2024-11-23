using L.Heritage.Admin.Desktop.Shared.Api;
using Microsoft.Extensions.DependencyInjection;

namespace L.Heritage.Admin.Desktop.Shared;

public static class DependencyInjection
{
    public static void AddShared(this IServiceCollection services)
    {
        services.AddSingleton(_ => new ApiUtils("https://localhost:7289/api"));
    }
}
