using ECom.API.Controllers;
using ECom.Common;
using ECom.Tests.Doubles;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace ECom.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public void GetUserShouldReturnUser()
        {
            var userCtrl = new UserController(new FakeOptions());
            var result = userCtrl.GetUser();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsAssignableFrom<User>(okResult.Value);
            Assert.Equal("Mehdi Torkamani", user.Name);
            Assert.Equal("TOKEN", user.Token);
        }
    }
}
