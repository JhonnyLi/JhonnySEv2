using JhonnySEv2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace JhonnySEv2.Test
{
    public class ControllerTests
    {
        [Fact]
        public void HomeIndex_ReturnsAViewResult_IsSuccessful()
        {
            // Arrange
            var mockRepo = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void GithubIndex_ReturnsARedirectResult_IsSuccessful()
        {
            // Arrange
            var controller = new GithubController();

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<RedirectResult>(result);
        }

        [Fact]
        public void Index_ReturnsRedirectToGithub()
        {
            // Arrange
            var controller = new GithubController();
    
            // Act
            var result = controller.Index();
    
            // Assert
            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal("https://www.github.com/jhonnyli", redirectResult.Url);
        }
    }
}