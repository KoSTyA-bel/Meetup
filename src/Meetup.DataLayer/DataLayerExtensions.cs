using Meetup.BusinessLayer.Interfaces;
using Meetup.DataLayer.Contexts;
using Meetup.DataLayer.Providers;
using Meetup.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meetup.DataLayer;

public static class DataLayerExtensions
{
    public static IServiceCollection AddMeetupDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MeetupDB");

        services.AddMeetupDatabase(connectionString);

        return services;
    }

    public static IServiceCollection AddMeetupDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextPool<MeetupContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped(provider =>
            {
                var service = provider.GetService(typeof(MeetupContext)) as MeetupContext;
                return service.Meetups;
            })
            .AddScoped<IDataContext, MeetupDataContext>()
            .AddScoped<IMeetupRepository, MeetupRepository>()
            .AddScoped<IMeetupProvider, MeetupProvider>();

        return services;
    }
}
