namespace Meetup.Api.Infrastructure.Configurations;

/// <summary>
/// Expands functionality of web application builder.
/// </summary>
public static class AppConfiguration
{
    /// <summary>
    /// Adds the application settings from enviroment variables.
    /// </summary>
    /// <param name="applicationBuilder">The application builder.</param>
    /// <param name="prefix">The prefix.</param>
    /// <returns>Web application builder.</returns>
    public static WebApplicationBuilder AddAppSettings(this WebApplicationBuilder applicationBuilder, string prefix = "MeetupService_")
    {
        applicationBuilder.Host.ConfigureAppConfiguration(config =>
        {
            config.AddEnvironmentVariables(prefix);
            config.Build();
        });

        return applicationBuilder;
    }
}
