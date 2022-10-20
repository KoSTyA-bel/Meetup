using Meetup.BusinessLayer.Models;

namespace Meetup.Api.Infrastructure.MappingProfiles;

/// <summary>
/// Install custom mapping settings.
/// </summary>
/// <seealso cref="AutoMapper.Profile" />
public class MappingProfile : AutoMapper.Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingProfile"/> class with specific rules of mapping.
    /// </summary>
    public MappingProfile()
    {
        CreateMap<string, Guid>()
            .ConvertUsing((x, res) => res = Guid.TryParse(x, out var id) ? id : Guid.Empty);
        CreateMap<Guid?, string>()
            .ConvertUsing((x, res) => res = x?.ToString() ?? string.Empty);

        CreateMap<string, DateTime>()
            .ConvertUsing((x, res) => res = DateTime.TryParse(x, out var date) ? date : DateTime.MinValue);
        CreateMap<DateTime?, string>()
            .ConvertUsing((x, res) => res = x?.ToString() ?? string.Empty);

        CreateMap<Meeting, Models.Meetup>()
            .ReverseMap();
    }
}
