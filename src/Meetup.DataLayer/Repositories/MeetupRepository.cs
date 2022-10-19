using Meetup.BusinessLayer.Interfaces;
using Models = Meetup.BusinessLayer.Models;
using Meetup.DataLayer.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Meetup.DataLayer.Repositories;

public class MeetupRepository : IMeetupRepository
{
    private readonly DbSet<Models.Meetup> _meetups;
    private readonly ILogger<MeetupRepository> _logger;

    public MeetupRepository(DbSet<Models.Meetup> battles, ILogger<MeetupRepository> logger)
    {
        _meetups = battles ?? throw new ArgumentNullException(nameof(battles));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public Task Create(Models.Meetup meetup, CancellationToken token)
    {
        _logger.LogTrace("Creating new meetup={meetup}", meetup);
        return Task.FromResult(_meetups.Add(meetup));
    }

    public Task Delete(Models.Meetup meetup, CancellationToken token)
    {
        _logger.LogTrace("Deleting meetup={meetup}", meetup);
        return Task.FromResult(_meetups.Remove(meetup));
    }

    public Task Update(Models.Meetup meetup, CancellationToken token)
    {
        _logger.LogTrace("Updating meetup={battle}", meetup);
        return Task.FromResult(_meetups.Update(meetup));
    }
}
