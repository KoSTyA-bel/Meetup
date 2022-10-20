using Meetup.BusinessLayer.Interfaces;
using Meetup.DataLayer.Contexts;
using Meetup.DataLayer.Providers;
using Meetup.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meetup.DataLayer;

/// <summary>
/// Expands functionality of service collection.
/// </summary>
public static class DataLayerExtensions
{
    /// <summary>
    /// Adds the meeting database.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection AddMeetingDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MeetupDB");

        services.AddMeetingDatabase(connectionString);

        return services;
    }

    /// <summary>
    /// Adds the Meeting database.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <param name="connectionString">The connection string.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection AddMeetingDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextPool<MeetupContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped(provider =>
            {
                var service = provider.GetService(typeof(MeetupContext)) as MeetupContext;
                return service.Meetings;
            })
            .AddScoped<IDataContext, MeetupDataContext>()
            .AddScoped<IMeetupRepository, MeetupRepository>()
            .AddScoped<IMeetupProvider, MeetupProvider>();

        return services;
    }
}
