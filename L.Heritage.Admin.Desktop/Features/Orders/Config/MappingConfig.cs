using L.Heritage.Admin.Desktop.Entities.Order.Model;
using L.Heritage.Admin.Desktop.Features.Orders.Model;
using Microsoft.Extensions.DependencyInjection;
using Mapster;

namespace L.Heritage.Admin.Desktop.Features.Orders.Config;

public static partial class MappingConfig
{
    public static void ConfigureOrderMappings(this IServiceCollection _)
    {
        TypeAdapterConfig<Order, OrderRowVM>.NewConfig()
            .Map(dest => dest.IsChanged, _ => false);
    } 
}
