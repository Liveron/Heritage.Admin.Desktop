using Microsoft.Extensions.DependencyInjection;

namespace L.Heritage.Admin.Desktop.Features.Authentication.Api;

public static class HttpClientConfiguration
{
    static readonly Uri API_URL = new("https://localhost:7289/api/");

    public static void ConfigureHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient("Default", client =>
        {
            client.BaseAddress = API_URL;
        });

        services.AddTransient<AuthenticationHandler>();

        services.AddHttpClient("Authenticated", client =>
        {
            client.BaseAddress = API_URL;
        }).AddHttpMessageHandler<AuthenticationHandler>();
    }
}
