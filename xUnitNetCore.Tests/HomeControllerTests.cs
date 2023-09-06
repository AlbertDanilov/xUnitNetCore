using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using xUnitNetCore.Controllers;
using xUnitNetCore.Models;

namespace xUnitNetCore.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexReturnsAViewResultWithAListOfUsers()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestUsers());
            var controller = new HomeController(mock.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<User>>(viewResult.Model);
            Assert.Equal(GetTestUsers().Count(), model.Count());
        }

        private List<User> GetTestUsers()
        {
            var users = new List<User>()
            {
                new User { Id = 1, Name = "Albert", Age = 28},
                new User { Id = 1, Name = "Denis", Age = 26},
                new User { Id = 1, Name = "Mikhail", Age = 37}
            };

            return users;
        }

        //[Fact]
        //public void IndexViewDataMessage()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();

        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;

        //    // Assert
        //    Assert.Equal("Hello world!", result?.ViewData["Message"]);
        //}

        //[Fact]
        //public void IndexViewResultNotNull()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();
        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;
        //    // Assert
        //    Assert.NotNull(result);
        //}

        //[Fact]
        //public void IndexViewNameEqualIndex()
        //{
        //    // Arrange
        //    HomeController controller = new HomeController();
        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;
        //    // Assert
        //    Assert.Equal("Index", result?.ViewName);
        //}
    }
}
