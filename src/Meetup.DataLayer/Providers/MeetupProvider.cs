using Meetup.BusinessLayer.Interfaces;
using Meetup.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Meetup.DataLayer.Providers;

/// <summary>
/// Provides methods for meetings collections from a database.
/// </summary>
/// <seealso cref="Meetup.BusinessLayer.Interfaces.IMeetupProvider" />
public class MeetupProvider : IMeetupProvider
{
    private readonly DbSet<Meeting> _meetings;
    private readonly ILogger<MeetupProvider> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="MeetupProvider"/> class.
    /// </summary>
    /// <param name="meetings">The meetups.</param>
    /// <param name="logger">The logger.</param>
    /// <exception cref="System.ArgumentNullException">If <paramref name="logger"/> is null or <paramref name="meetings"/> is null.</exception>
    public MeetupProvider(DbSet<Meeting> meetings, ILogger<MeetupProvider> logger)
    {
        _meetings = meetings ?? throw new ArgumentNullException(nameof(meetings));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc/>
    public Task<List<Meeting>> GetAll(CancellationToken token)
    {
        _logger.LogTrace("Get all meetups");
        return _meetings.ToListAsync(token);
    }

    /// <inheritdoc/>
    public Task<Meeting> GetById(Guid id, CancellationToken token)
    {
        _logger.LogTrace("Get meetup by id={id}", id);
        return _meetings.FirstOrDefaultAsync(x => x.Id == id, token);
    }

    /// <inheritdoc/>
    public Task<List<Meeting>> GetRange(int page, int pageSize, CancellationToken token)
    {
        _logger.LogTrace("Get range of meetups. Page={page}, page size={pageSize}", page, pageSize);
        return _meetings
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(token);
    }
}
