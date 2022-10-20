using Meetup.BusinessLayer.Interfaces;
using Meetup.BusinessLayer.Services;
using Meetup.BusinessLayer.Settings;
using Meetup.BusinessLayer.Verifiers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Meetup.BusinessLayer;

/// <summary>
/// Expands functionality of service collection.
/// </summary>
public static class BusinessLayerExtensions
{
    /// <summary>
    /// Adds a scoped serivices to the service collection.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection AddMeetupService(this IServiceCollection services)
    {
        services.AddScoped<IMeetupService, MeetupService>();

        return services;
    }

    /// <summary>
    /// Adds serivices to the service collection.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection AddJWTVerifier(this IServiceCollection services)
    {
        services
            .AddTransient<IJWTVerifier, JWTVerifier>()
            .AddSingleton(GetJWTVerifierSettings);

        return services;

        static JWTVerifierSettings GetJWTVerifierSettings(IServiceProvider sp)
        {
            var settings = sp.GetRequiredService<IOptions<JWTVerifierSettings>>().Value;
            return settings;
        }
    }
}
