using JhonnySEv2.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Globalization;
using Xunit;

public class IApplicationBuilderExtensionsTests
{
    [Fact]
    public void UseCultureSettings_SetsDefaultCulture()
    {
        // Arrange
        var appMock = new Mock<IApplicationBuilder>();
        appMock.Setup(a => a.Use(It.IsAny<Func<RequestDelegate, RequestDelegate>>()))
               .Returns(appMock.Object);

        // Act
        appMock.Object.UseCultureSettings();

        // Assert
        Assert.NotNull(CultureInfo.DefaultThreadCurrentCulture);
        Assert.Equal("sv-SE", CultureInfo.DefaultThreadCurrentCulture.Name);
        Assert.NotNull(CultureInfo.DefaultThreadCurrentUICulture);
        Assert.Equal("sv-SE", CultureInfo.DefaultThreadCurrentUICulture.Name);
    }

    [Fact]
    public void UseCultureSettings_SetsCustomCulture()
    {
        // Arrange
        var appMock = new Mock<IApplicationBuilder>();
        appMock.Setup(a => a.Use(It.IsAny<Func<RequestDelegate, RequestDelegate>>()))
               .Returns(appMock.Object);

        // Act
        appMock.Object.UseCultureSettings("en-US");

        // Assert
        Assert.NotNull(CultureInfo.DefaultThreadCurrentCulture);
        Assert.Equal("en-US", CultureInfo.DefaultThreadCurrentCulture.Name);
        Assert.NotNull(CultureInfo.DefaultThreadCurrentUICulture);
        Assert.Equal("en-US", CultureInfo.DefaultThreadCurrentUICulture.Name);
    }

    [Fact]
    public void UseCultureSettings_ActionConfiguresCultureOptions()
    {
        // Arrange
        var appMock = new Mock<IApplicationBuilder>();
        appMock.Setup(a => a.Use(It.IsAny<Func<RequestDelegate, RequestDelegate>>()))
               .Returns(appMock.Object);

        // Act
        appMock.Object.UseCultureSettings(options =>
        {
            options.Culture = "fr-FR";
            options.DefaultThreadCurrentCulture = new CultureInfo("fr-FR");
            options.DefaultThreadCurrentUICulture = new CultureInfo("fr-FR");
        });

        // Assert
        Assert.NotNull(CultureInfo.DefaultThreadCurrentCulture);
        Assert.Equal("fr-FR", CultureInfo.DefaultThreadCurrentCulture.Name);
        Assert.NotNull(CultureInfo.DefaultThreadCurrentUICulture);
        Assert.Equal("fr-FR", CultureInfo.DefaultThreadCurrentUICulture.Name);
    }
}