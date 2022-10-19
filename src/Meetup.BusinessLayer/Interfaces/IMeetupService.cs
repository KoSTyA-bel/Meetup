namespace Meetup.BusinessLayer.Interfaces;

public interface IMeetupService
{
    Task<Models.Meetup> GetById(Guid id, CancellationToken token);

    Task<List<Models.Meetup>> GetAll(CancellationToken token);

    Task<List<Models.Meetup>> GetRange(int page, int pageSize, CancellationToken token);

    Task<Models.Meetup> Create(Models.Meetup meetup, CancellationToken token);

    Task Update(Models.Meetup meetup, CancellationToken token);

    Task Delete(Guid id, CancellationToken token);
}
