namespace Meetup.Api;

public class MappingProfile : AutoMapper.Profile
{
	public MappingProfile()
	{
        CreateMap<string, Guid>()
            .ConvertUsing((x, res) => res = Guid.TryParse(x, out var id) ? id : Guid.Empty);
        CreateMap<Guid?, string>()
            .ConvertUsing((x, res) => res = x?.ToString() ?? string.Empty);
    }
}
