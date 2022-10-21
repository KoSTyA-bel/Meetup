using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Meetup;

namespace Meetup.IntegrationTest;

public class RestApiAppBuilder : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseSetting("Enviroment", "Integration");
        base.ConfigureWebHost(builder);
    }
}
