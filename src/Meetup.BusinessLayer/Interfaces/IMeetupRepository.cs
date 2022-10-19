namespace Meetup.BusinessLayer.Interfaces;

public interface IMeetupRepository
{
    Task Create(Models.Meetup meetup, CancellationToken token);

    Task Update(Models.Meetup meetup, CancellationToken token);

    Task Delete(Models.Meetup meetup, CancellationToken token);
}
