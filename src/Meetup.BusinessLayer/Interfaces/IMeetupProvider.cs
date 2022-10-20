using Meetup.BusinessLayer.Models;

namespace Meetup.BusinessLayer.Interfaces;

/// <summary>
/// Describes methods for battle provider.
/// </summary>
public interface IMeetupProvider
{
    /// <summary>
    /// Gets Meeting by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="token">Cancellation token.</param>
    /// <returns>Meeting with specific id.</returns>
    Task<Meeting> GetById(Guid id, CancellationToken token);

    /// <summary>
    /// Gets list of meetings.
    /// </summary>
    /// <param name="token">Cancellation token.</param>
    /// <returns>All meetings.</returns>
    Task<List<Meeting>> GetAll(CancellationToken token);

    /// <summary>
    /// Gets the range of meetings.
    /// </summary>
    /// <param name="page">The page.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="token">Cancellation token.</param>
    /// <returns>Range of meetings.</returns>
    Task<List<Meeting>> GetRange(int page, int pageSize, CancellationToken token);
}
