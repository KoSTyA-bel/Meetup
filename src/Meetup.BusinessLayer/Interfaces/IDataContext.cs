namespace Meetup.BusinessLayer.Interfaces;

public interface IDataContext
{
    Task SaveCanges(CancellationToken token);
}
