using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models = Meetup.BusinessLayer.Models;

namespace Meetup.DataLayer.Configurations;

public class MeetupConfiguration : IEntityTypeConfiguration<Models.Meetup>
{
    public void Configure(EntityTypeBuilder<Models.Meetup> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Place).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Speaker).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Desciption).IsRequired();
        builder.Property(x => x.Date).IsRequired();

        builder.ToTable("Meetups");
    }
}
