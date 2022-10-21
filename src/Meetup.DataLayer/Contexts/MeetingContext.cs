using Meetup.DataLayer.Configurations;
using Microsoft.EntityFrameworkCore;
using Meetup.BusinessLayer.Models;

namespace Meetup.DataLayer.Contexts;

/// <summary>
/// Meeting database context.
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
public class MeetingContext : DbContext
{
	/// <summary>
	/// Initializes a new instance of the <see cref="MeetingContext"/> class.
	/// </summary>
	/// <param name="options">The context options.</param>
	public MeetingContext(DbContextOptions<MeetingContext> options)
		:base(options)
	{}

	/// <summary>
	/// Gets or sets the meetings.
	/// </summary>
	/// <value>
	/// The meetings.
	/// </value>
	public DbSet<Meeting> Meetings { get; set; }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new MeetupConfiguration());

		base.OnModelCreating(modelBuilder);
	}
}
