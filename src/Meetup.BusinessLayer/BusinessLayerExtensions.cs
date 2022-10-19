using Meetup.BusinessLayer.Interfaces;
using Meetup.BusinessLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Meetup.BusinessLayer;

public static class BusinessLayerExtensions
{
    public static IServiceCollection AddMeetupService(this IServiceCollection services)
    {
        services.AddScoped<IMeetupService, MeetupService>();

        return services;
    }
}
