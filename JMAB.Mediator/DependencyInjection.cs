using Microsoft.Extensions.DependencyInjection;
using JMAB.Mediator.Services;

namespace JMAB.Mediator;

public static class DependencyInjection
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Services.Mediator>();
    }
}
