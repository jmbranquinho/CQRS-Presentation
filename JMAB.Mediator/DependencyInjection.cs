using Microsoft.Extensions.DependencyInjection;
using JMAB.Mediator.Services;

namespace JMAB.Mediator;

public static class DependencyInjection//mediatr
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Services.Mediator>();
    }
}
