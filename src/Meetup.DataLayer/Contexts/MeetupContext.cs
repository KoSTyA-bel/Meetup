using Meetup.DataLayer.Configurations;
using Microsoft.EntityFrameworkCore;
using Models = Meetup.BusinessLayer.Models;

namespace Meetup.DataLayer.Contexts;

public class MeetupContext : DbContext
{
	public MeetupContext(DbContextOptions<MeetupContext> options)
		:base(options)
	{}

	public DbSet<Models.Meetup> Meetups { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new MeetupConfiguration());

		base.OnModelCreating(modelBuilder);
	}
}
