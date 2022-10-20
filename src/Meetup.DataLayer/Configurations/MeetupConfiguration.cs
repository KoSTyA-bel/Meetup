using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Meetup.BusinessLayer.Models;

namespace Meetup.DataLayer.Configurations;

/// <summary>
/// Configures an entity type <see cref="Meeting"/>.
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration&lt;Meetup.BusinessLayer.Models.Meeting&gt;" />
public class MeetupConfiguration : IEntityTypeConfiguration<Meeting>
{
    /// <inheritdoc/>
    public void Configure(EntityTypeBuilder<Meeting> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Place).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Speaker).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Desciption).IsRequired();
        builder.Property(x => x.Date).IsRequired();

        builder.ToTable("Meetings");
    }
}
