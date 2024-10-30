using System.Globalization;

namespace JhonnySEv2.Test
{
    public class HelperTests
    {
        [Fact]
        public void CultureGetCurrentWeek_ReturnsInt_TypeIsInt()
        {
            // Arrange
            // Act
            var result = JhonnySEv2.Helpers.CultureHelpers.GetCurrentWeek();

            // Assert
            Assert.IsType<int>(result);
        }

        [Fact]
        public void CultureGetCurrentWeek_ReturnsInt_MoreThanZeroLessThan53()
        {
            // Arrange
            // Act
            var result = JhonnySEv2.Helpers.CultureHelpers.GetCurrentWeek();

            // Assert
            Assert.True(result>0 && result<53);
        }

        [Theory]
        [InlineData("sv-SE")]
        [InlineData("en-SE")]
        [InlineData("en-GB")]
        [InlineData("en-US")]
        public void CultureGetCurrentCulture_ReturnsCultureName_IsSameAsSelected(string cultureName)
        {
            // Arrange
            CultureInfo.CurrentCulture = new CultureInfo(cultureName, false);
            var currentCultureNames = new[] { CultureInfo.CurrentCulture.Name, CultureInfo.CurrentCulture.TwoLetterISOLanguageName };
            // Act
            var result = JhonnySEv2.Helpers.CultureHelpers.GetCurrentCultureName();

            // Assert
            Assert.Contains(result, currentCultureNames);
        }

    }
}
