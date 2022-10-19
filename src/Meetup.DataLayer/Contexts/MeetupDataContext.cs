using Meetup.BusinessLayer.Interfaces;

namespace Meetup.DataLayer.Contexts;

public class MeetupDataContext : IDataContext
{
    private readonly MeetupContext _context;

    public MeetupDataContext(MeetupContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task SaveCanges(CancellationToken token)
    {
        return _context.SaveChangesAsync(token);
    }
}
