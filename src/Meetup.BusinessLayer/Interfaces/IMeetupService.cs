using Meetup.BusinessLayer.Models;

namespace Meetup.BusinessLayer.Interfaces;

/// <summary>
/// Describes methods for meetup service.
/// </summary>
public interface IMeetupService
{
    /// <summary>
    /// Gets the meeting by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="token">Cancellation token.</param>
    /// <returns>Meeting with specific id.</returns>
    Task<Meeting> GetById(Guid id, CancellationToken token);

    /// <summary>
    /// Gets all meetings.
    /// </summary>
    /// <param name="token">Cancellation token.</param>
    /// <returns>List of all meetings.</returns>
    Task<List<Meeting>> GetAll(CancellationToken token);

    /// <summary>
    /// Gets the range of meetings.
    /// </summary>
    /// <param name="page">The page.</param>
    /// <param name="pageSize">Size of the page.</param>
    /// <param name="token">Cancellation token.</param>
    /// <returns>Range of meetings.</returns>
    Task<List<Meeting>> GetRange(int page, int pageSize, CancellationToken token);

    /// <summary>
    /// Creates the specified meeting.
    /// </summary>
    /// <param name="meeting">The meeting.</param>
    /// <param name="token">Cancellation token.</param>
    /// <returns>Created meeting.</returns>
    Task<Meeting> Create(Meeting meeting, CancellationToken token);

    /// <summary>
    /// Updates the specified meeting.
    /// </summary>
    /// <param name="meeting">The meeting.</param>
    /// <param name="token">Cancellation token.</param>
    /// <returns>Task of updating meeting.</returns>
    Task Update(Meeting meeting, CancellationToken token);

    /// <summary>
    /// Deletes meeting with specific id.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="token">Cancellation token.</param>
    /// <returns>Task of deleting meeting.</returns>
    Task Delete(Guid id, CancellationToken token);
}
