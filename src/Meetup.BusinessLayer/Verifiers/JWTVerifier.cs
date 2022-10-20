using Meetup.BusinessLayer.Interfaces;
using Meetup.BusinessLayer.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime;
using System.Text;

namespace Meetup.BusinessLayer.Verifiers;

/// <summary>
/// Provides methods for verification jwt.
/// </summary>
/// <seealso cref="Meetup.BusinessLayer.Interfaces.IJWTVerifier" />
public class JWTVerifier : IJWTVerifier
{
    private readonly JWTVerifierSettings _settings;

    /// <summary>
    /// Initializes a new instance of the <see cref="JWTVerifier"/> class.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <exception cref="System.ArgumentNullException">If <paramref name="settings"/> is null.</exception>
    public JWTVerifier(JWTVerifierSettings settings)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
    }

    /// <inheritdoc/>
    public Task<string> VerifyJWT(string token, CancellationToken cancellationToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_settings.Key);
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = _settings.Issuer,
            ValidAudience = _settings.Audience,
            ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;
        var userName = jwtToken.Claims.First(x => x.Type == "id").Value;

        return Task.FromResult(userName);
    }
}
