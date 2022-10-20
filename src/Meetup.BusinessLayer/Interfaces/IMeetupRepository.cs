using Meetup.BusinessLayer.Models;

namespace Meetup.BusinessLayer.Interfaces;

/// <summary>
/// Describes methods for battle repository.
/// </summary>
public interface IMeetupRepository
{
    /// <summary>
    /// Creates meeting.
    /// </summary>
    /// <param name="meeting">Meeting.</param>
    /// <param name="token">Cancellation token.</param>
    /// <returns>The task of creating meeting.</returns>
    Task Create(Meeting meeting, CancellationToken token);

    /// <summary>
    /// Updates meeting data.
    /// </summary>
    /// <param name="meeting">meeting.</param>
    /// <param name="token">Cancellation token.</param>
    /// <returns>The task of updating meeting data.</returns>
    Task Update(Meeting meeting, CancellationToken token);

    /// <summary>
    /// Deletes meeting.
    /// </summary>
    /// <param name="meeting">Meeting.</param>
    /// <param name="token">Cancellation token.</param>
    /// <returns>The task of deleting meeting.</returns>
    Task Delete(Meeting meeting, CancellationToken token);
}
