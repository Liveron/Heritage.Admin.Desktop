using L.Heritage.Admin.Desktop.Features.Articles.Config;
using L.Heritage.Admin.Desktop.Features.Articles.Model;
using L.Heritage.Admin.Desktop.Features.Articles.Model.Commands;
using L.Heritage.Admin.Desktop.Features.Authentication.Api;
using L.Heritage.Admin.Desktop.Features.Authentication.Api.Commands;
using L.Heritage.Admin.Desktop.Features.Authentication.Model;
using L.Heritage.Admin.Desktop.Features.Navigation.Model;
using L.Heritage.Admin.Desktop.Features.Orders.Config;
using L.Heritage.Admin.Desktop.Features.Orders.Model;
using L.Heritage.Admin.Desktop.Features.Orders.Model.Commands;
using L.Heritage.Admin.Desktop.Features.Rooms.Config;
using L.Heritage.Admin.Desktop.Features.Rooms.Model;
using L.Heritage.Admin.Desktop.Features.Rooms.Model.Commands;
using L.Heritage.Admin.Desktop.Views.CreateRoom.Model.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace L.Heritage.Admin.Desktop.Features;

public static class DependencyInjection
{
    public static void AddFeatures(this IServiceCollection services)
    {
        services.ConfigureMappings();
        services.AddStores();
        services.AddRepositories();
        services.AddServices();
        services.AddCommands();
        services.AddApi();
    }

    private static void AddStores(this IServiceCollection services)
    {
        services.AddSingleton<NavigationStore>();
        services.AddSingleton<AuthStore>();
        services.AddSingleton<ArticlesStore>();
        services.AddSingleton<RoomsStore>();
        services.AddSingleton<OrdersStore>();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ITokenRepository, TokenRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IRoomsRepository, RoomsRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<NavigationService>();
        services.AddScoped<AuthService>();
        services.AddScoped<ArticlesService>();
        services.AddScoped<IRoomsService, RoomsService>();
        services.AddScoped<IOrdersService, OrdersService>();
    }

    private static void AddCommands(this IServiceCollection services)
    {
        services.AddTransient<SignInCommand>();
        services.AddTransient<GetArticlesCommand>();
        services.AddTransient<GetRoomsCommand>();
        services.AddTransient<SetImageCommand>();
        services.AddTransient<GetOrdersCommand>();
    }

    private static void AddApi(this IServiceCollection services)
    {
        services.ConfigureHttpClients();
    }

    private static void ConfigureMappings(this IServiceCollection services)
    {
        services.ConfigureOrderMappings();
        services.ConfigureArticleMappgins();
        services.ConfigureRoomMappings();
    }
}
