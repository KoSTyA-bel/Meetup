using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Meetup.IntegrationTest;

public class AutomapperMappingTests: IClassFixture<RestApiAppBuilder>, IDisposable
{
    private readonly IServiceScope _scope;
    private readonly IMapper _mapper;

    public AutomapperMappingTests(RestApiAppBuilder factory)
    {
        _scope = factory.Services.CreateScope();
        _mapper = _scope.ServiceProvider.GetRequiredService<IMapper>();
    }

    [Fact]
    public void AutoMapper_Should_Have_Valid_Configuration()
    {
        _mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }

    public void Dispose()
    {
        _scope.Dispose();
    }
}
