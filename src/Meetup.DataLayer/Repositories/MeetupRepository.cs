using Meetup.BusinessLayer.Interfaces;
using Meetup.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Meetup.DataLayer.Repositories;

/// <summary>
/// Provides methods for creating, deleting and modifying meetings.
/// </summary>
/// <seealso cref="Meetup.BusinessLayer.Interfaces.IMeetupRepository" />
public class MeetupRepository : IMeetupRepository
{
    private readonly DbSet<Meeting> _meetings;
    private readonly ILogger<MeetupRepository> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="MeetupRepository"/> class.
    /// </summary>
    /// <param name="meetups">The meetups.</param>
    /// <param name="logger">The logger.</param>
    /// <exception cref="System.ArgumentNullException">if <paramref name="meetups"/> is null or <paramref name="logger"/> is null.</exception>
    public MeetupRepository(DbSet<Meeting> meetups, ILogger<MeetupRepository> logger)
    {
        _meetings = meetups ?? throw new ArgumentNullException(nameof(meetups));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc/>
    public Task Create(Meeting meetup, CancellationToken token)
    {
        _logger.LogTrace("Creating new meetup={meetup}", meetup);
        return Task.FromResult(_meetings.Add(meetup));
    }

    /// <inheritdoc/>
    public Task Delete(Meeting meetup, CancellationToken token)
    {
        _logger.LogTrace("Deleting meetup={meetup}", meetup);
        return Task.FromResult(_meetings.Remove(meetup));
    }

    /// <inheritdoc/>
    public Task Update(Meeting meetup, CancellationToken token)
    {
        _logger.LogTrace("Updating meetup={battle}", meetup);
        return Task.FromResult(_meetings.Update(meetup));
    }
}
