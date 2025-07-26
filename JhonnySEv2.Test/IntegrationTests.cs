using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace JhonnySEv2.Test
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCultureSettings(this IApplicationBuilder app, string cultureName)
        {
            return app.Use(async (context, next) =>
            {
                var cultureInfo = new CultureInfo(cultureName);
                CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
                await next.Invoke();
            });
        }
    }

    public class IntegrationTests
    {
        [Fact]
        public async Task IndexPage_Contains_ExpectedHeading()
        {
            var appFactory = new WebApplicationFactory<Program>();
            var client = appFactory.CreateClient();

            var response = await client.GetAsync("/");
            var html = await response.Content.ReadAsStringAsync();

            Assert.Contains(@"<a href=""/"">Jhonny Li</a>", html);
        }

        [Fact]
        public async Task UseCultureSettings_ExecutesMiddleware()
        {
            using var host = await new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder.UseTestServer();
                    webBuilder.Configure(app =>
                    {
                        app.UseCultureSettings("en-US");
                        app.Run(context =>
                        {
                            // This will execute the pipeline and the middleware
                            var cultureName = CultureInfo.DefaultThreadCurrentCulture?.Name ?? "unknown";
                            return context.Response.WriteAsync(cultureName);
                        });
                    });
                })
                .StartAsync();

            var client = host.GetTestClient();
            var response = await client.GetAsync("/");
            var culture = await response.Content.ReadAsStringAsync();

            Assert.Equal("en-US", culture);
        }
    }

    public class BasicIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public BasicIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task IndexPage_ReturnsSuccess()
    {
        var response = await _client.GetAsync("/");
        response.EnsureSuccessStatusCode();
    }
}
}