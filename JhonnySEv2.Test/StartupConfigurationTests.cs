using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Net;

namespace JhonnySEv2.Test
{
    public class StartupTests
    {
        [Fact]
        public void ConfigureServices_RegistersControllersWithViews()
        {
            // Arrange
            var services = new ServiceCollection();
            var startup = new JhonnySEv2.Startup(null);

            // Act
            startup.ConfigureServices(services);
            var provider = services.BuildServiceProvider();

            // Assert
            var mvcBuilder = provider.GetService<Microsoft.AspNetCore.Mvc.Infrastructure.IActionDescriptorCollectionProvider>();
            Assert.NotNull(mvcBuilder);
        }

        [Fact]
        public void ConfigureServices_AddsPartialsViewLocation()
        {
            // Arrange
            var services = new ServiceCollection();
            var startup = new JhonnySEv2.Startup(null);

            // Act
            startup.ConfigureServices(services);
            var provider = services.BuildServiceProvider();
            var options = provider.GetService<Microsoft.Extensions.Options.IOptions<RazorViewEngineOptions>>();

            // Assert
            Assert.NotNull(options);
            Assert.Contains("/Views/Shared/Partials/{0}.cshtml", options.Value.ViewLocationFormats);
        }

        [Fact]
        public async Task Request_To_UnKnown_Endpoint_Returns_Ok()
        {
            var appFactory = new WebApplicationFactory<Program>();
            var client = appFactory.CreateClient();

            var response = await client.GetAsync("/api/protected-endpoint");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}