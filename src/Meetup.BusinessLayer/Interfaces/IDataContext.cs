namespace Meetup.BusinessLayer.Interfaces;

/// <summary>
/// Describes methods for data context.
/// </summary>
public interface IDataContext
{
    /// <summary>
    /// Saves the changes.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The task of saving changes.</returns>
    Task SaveCanges(CancellationToken cancellationToken);
}
