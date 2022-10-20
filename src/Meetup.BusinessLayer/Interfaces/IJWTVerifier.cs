namespace Meetup.BusinessLayer.Interfaces;

/// <summary>
/// Describes methods for jwt verifiers.
/// </summary>
public interface IJWTVerifier
{
    /// <summary>
    /// Verifies the JWT.
    /// </summary>
    /// <param name="token">JWT.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>User name or null.</returns>
    Task<string> VerifyJWT(string token, CancellationToken cancellationToken);
}
