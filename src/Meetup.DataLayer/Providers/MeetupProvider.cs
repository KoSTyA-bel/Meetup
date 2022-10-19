using Meetup.BusinessLayer.Interfaces;
using Models = Meetup.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Meetup.DataLayer.Providers;

public class MeetupProvider : IMeetupProvider
{
    private readonly DbSet<Models.Meetup> _meetups;
    private readonly ILogger<MeetupProvider> _logger;

    public MeetupProvider(DbSet<Models.Meetup> battles, ILogger<MeetupProvider> logger)
    {
        _meetups = battles ?? throw new ArgumentNullException(nameof(battles));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public Task<List<Models.Meetup>> GetAll(CancellationToken token)
    {
        _logger.LogTrace("Get all meetups");
        return _meetups.ToListAsync(token);
    }

    public Task<Models.Meetup> GetById(Guid id, CancellationToken token)
    {
        _logger.LogTrace("Get meetup by id={id}", id);
        return _meetups.FirstOrDefaultAsync(x => x.Id == id, token);
    }

    public Task<List<Models.Meetup>> GetRange(int page, int pageSize, CancellationToken token)
    {
        _logger.LogTrace("Get range of meetups. Page={page}, page size={pageSize}", page, pageSize);
        return _meetups
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(token);
    }
}
