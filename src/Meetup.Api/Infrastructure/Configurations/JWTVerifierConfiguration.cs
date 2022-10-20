using Meetup.BusinessLayer.Settings;

namespace Meetup.Api.Infrastructure.Configurations;

/// <summary>
/// Expands functionality of web application builder.
/// </summary>
public static class JWTVerifierConfiguration
{
    /// <summary>
    /// Adds the JWT verifier settings.
    /// </summary>
    /// <param name="applicationBuilder">The application builder.</param>
    /// <param name="prefix">The prefix.</param>
    /// <returns>Web application builder.</returns>
    public static WebApplicationBuilder AddJWTVerifierSettings(this WebApplicationBuilder applicationBuilder, string prefix = "MeetupService_")
    {
        var section = applicationBuilder.Configuration.GetSection(nameof(JWTVerifierSettings));
        applicationBuilder.Services.Configure<JWTVerifierSettings>(applicationBuilder.Configuration.GetSection(nameof(JWTVerifierSettings)));

        return applicationBuilder;
    }
}
