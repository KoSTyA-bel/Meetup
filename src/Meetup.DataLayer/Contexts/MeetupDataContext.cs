using Meetup.BusinessLayer.Interfaces;

namespace Meetup.DataLayer.Contexts;

/// <summary>
/// Provides methods for working with the database context.
/// </summary>
/// <seealso cref="Meetup.BusinessLayer.Interfaces.IDataContext" />
public class MeetupDataContext : IDataContext
{
    private readonly MeetupContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="MeetupDataContext"/> class.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <exception cref="System.ArgumentNullException">If <paramref name="context"/> is null.</exception>
    public MeetupDataContext(MeetupContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <inheritdoc/>
    public Task SaveCanges(CancellationToken token)
    {
        return _context.SaveChangesAsync(token);
    }
}
