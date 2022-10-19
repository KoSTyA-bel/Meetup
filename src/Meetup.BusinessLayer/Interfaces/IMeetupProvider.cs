
namespace Meetup.BusinessLayer.Interfaces;

public interface IMeetupProvider
{
    Task<Models.Meetup> GetById(Guid id, CancellationToken token);

    Task<List<Models.Meetup>> GetAll(CancellationToken token);

    Task<List<Models.Meetup>> GetRange(int page, int pageSize, CancellationToken token);
}
