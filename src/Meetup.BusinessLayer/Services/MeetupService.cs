using Meetup.BusinessLayer.Interfaces;
using Meetup.BusinessLayer.Models;

namespace Meetup.BusinessLayer.Services;

/// <summary>
/// Provides methods for working with meetings.
/// </summary>
/// <seealso cref="Meetup.BusinessLayer.Interfaces.IMeetupService" />
public class MeetupService : IMeetupService
{
    private readonly IMeetupProvider _provider;
    private readonly IMeetupRepository _repository;
    private readonly IDataContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="MeetupService"/> class.
    /// </summary>
    /// <param name="provider">The provider.</param>
    /// <param name="repository">The repository.</param>
    /// <param name="context">The context.</param>
    /// <exception cref="System.ArgumentNullException">If <paramref name="context"/> is null or <paramref name="provider"/> is null or <paramref name="repository"/> is null.<</exception>
    public MeetupService(IMeetupProvider provider, IMeetupRepository repository, IDataContext context)
    {
        _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <inheritdoc/>
    public async Task<Meeting> Create(Meeting meetup, CancellationToken token)
    {
        if (meetup is null)
        {
            throw new ArgumentNullException(nameof(meetup));
        }

        await _repository.Create(meetup, token);
        await _context.SaveCanges(token);

        return meetup;
    }

    /// <inheritdoc/>
    public async Task Delete(Guid id, CancellationToken token)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can`t be empty.", nameof(id));
        }

        var meetup = await _provider.GetById(id, token);

        if (meetup is null)
        {
            return;
        }

        await _repository.Delete(meetup, token);

        await _context.SaveCanges(token);
    }

    /// <inheritdoc/>
    public Task<List<Meeting>> GetAll(CancellationToken token)
    {
        return _provider.GetAll(token);
    }

    /// <inheritdoc/>
    public Task<Meeting> GetById(Guid id, CancellationToken token)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can`t be empty.", nameof(id));
        }

        return _provider.GetById(id, token);
    }

    /// <inheritdoc/>
    public Task<List<Meeting>> GetRange(int page, int pageSize, CancellationToken token)
    {
        if (page < 1)
        {
            throw new ArgumentException("Page should be greater than or equal to 1", nameof(page));
        }

        if (pageSize < 1)
        {
            throw new ArgumentException("Page size should be greater than or equal to 1", nameof(pageSize));
        }

        return _provider.GetRange(page, pageSize, token);
    }

    /// <inheritdoc/>
    public async Task Update(Meeting meetup, CancellationToken token)
    {
        if (meetup is null)
        {
            throw new ArgumentNullException(nameof(meetup));
        }

        try
        {
            var meetupInDb = await GetById(meetup.Id, token);

            if (meetupInDb is null)
            {
                throw new ArgumentNullException(nameof(meetup));
            }
        }
        catch (ArgumentException)
        {
            throw new ArgumentNullException(nameof(meetup));
        }

        await _repository.Update(meetup, token);
        await _context.SaveCanges(token);
    }
}
