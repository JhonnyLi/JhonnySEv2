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
            var controller = new RedirectController();

            // Act
            var result = controller.Github();

            // Assert
            var viewResult = Assert.IsType<RedirectResult>(result);
        }

        [Fact]
        public void Index_ReturnsRedirectToGithub()
        {
            // Arrange
            var controller = new RedirectController();

            // Act
            var result = controller.Github();

            // Assert
            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal(controller._githubUrl, redirectResult.Url);
        }

                [Fact]
        public void Index_ReturnsRedirectToLinkedIn()
        {
            // Arrange
            var controller = new RedirectController();

            // Act
            var result = controller.Linkedin();

            // Assert
            var redirectResult = Assert.IsType<RedirectResult>(result);
            Assert.Equal(controller._linkedinUrl, redirectResult.Url);
        }

        [Fact]
        public void ErrorIndex_WithErrorStatus_ReturnsAViewResult()
        {
            // Arrange
            var mockRepo = new Mock<ILogger<ErrorController>>();
            var controller = new ErrorController(mockRepo.Object);
        
            // Act
            var result = controller.Index(500);
        
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }
    }
}