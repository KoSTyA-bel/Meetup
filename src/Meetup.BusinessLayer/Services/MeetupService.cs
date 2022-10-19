using Meetup.BusinessLayer.Interfaces;
using System.Globalization;

namespace Meetup.BusinessLayer.Services;

public class MeetupService : IMeetupService
{
    private readonly IMeetupProvider _provider;
    private readonly IMeetupRepository _repository;
    private readonly IDataContext _context;

    public MeetupService(IMeetupProvider provider, IMeetupRepository repository, IDataContext context)
    {
        _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Models.Meetup> Create(Models.Meetup meetup, CancellationToken token)
    {
        if (meetup is null)
        {
            throw new ArgumentNullException(nameof(meetup));
        }

        await _repository.Create(meetup, token);
        await _context.SaveCanges(token);

        return meetup;
    }

    public async Task Delete(Guid id, CancellationToken token)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can`t be empty.", nameof(id));
        }

        var meetup = await _provider.GetById(id, token);
        await _context.SaveCanges(token);
    }

    public Task<List<Models.Meetup>> GetAll(CancellationToken token)
    {
        return _provider.GetAll(token);
    }

    public Task<Models.Meetup> GetById(Guid id, CancellationToken token)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id can`t be empty.", nameof(id));
        }

        return _provider.GetById(id, token);
    }

    public Task<List<Models.Meetup>> GetRange(int page, int pageSize, CancellationToken token)
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

    public async Task Update(Models.Meetup meetup, CancellationToken token)
    {
        if (meetup is null)
        {
            throw new ArgumentNullException(nameof(meetup));
        }

        await _repository.Update(meetup, token);
        await _context.SaveCanges(token);
    }
}
