using JhonnySEv2.Helpers;
using System.Globalization;
using Xunit;

public class CultureHelpersTests
{
    [Fact]
    public void GetCurrentWeek_ReturnsValidWeekNumber()
    {
        // Arrange
        CultureInfo.CurrentCulture = new CultureInfo("sv-SE");
        int week = CultureHelpers.GetCurrentWeek();

        // Assert
        Assert.InRange(week, 1, 53); // Swedish calendar can have up to 53 weeks
    }

    [Fact]
    public void GetCurrentCultureNameUs_ReturnsCorrectName()
    {
        // Arrange
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        string name = CultureHelpers.GetCurrentCultureName();

        // Assert
        Assert.Equal("en-US", name);
    }

    [Fact]
    public void GetCurrentCultureNameSe_ReturnsCorrectName()
    {
        // Arrange
        CultureInfo.CurrentCulture = new CultureInfo("sv-SE");
        string name = CultureHelpers.GetCurrentCultureName();

        // Assert
        Assert.Equal("sv-SE", name);
    }
}