using Meetup.BusinessLayer.Interfaces;

namespace Meetup.Api.Infrastructure.Middlewares;

/// <summary>
/// Authentication pipeline component.
/// </summary>
public class JWTMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IJWTVerifier _verifier;

    /// <summary>
    /// Initializes a new instance of the <see cref="JWTMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next.</param>
    /// <param name="verifier">The verifier.</param>
    /// <exception cref="System.ArgumentNullException">If <paramref name="next"/> is null or <paramref name="verifier"/> is null.</exception>
    public JWTMiddleware(RequestDelegate next, IJWTVerifier verifier)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _verifier = verifier ?? throw new ArgumentNullException(nameof(verifier));
    }

    /// <inheritdoc/>
    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            await AttachAccountToContext(context, token);
        }

        await _next(context);
    }

    private async Task AttachAccountToContext(HttpContext context, string token)
    {
        try
        {
            var userName = await _verifier.VerifyJWT(token, CancellationToken.None);

            context.Items["User"] = userName;
        }
        catch
        {
            // do nothing if jwt validation fails
        }
    }
}
