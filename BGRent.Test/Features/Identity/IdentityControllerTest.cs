namespace BGRent.Test.Features.Identity
{
    using BGRent.Server;
    using BGRent.Server.Data.Models;
    using BGRent.Server.Features.Identity;
    using BGRent.Server.Features.Identity.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Moq;
    using System.Threading.Tasks;
    using Xunit;

    public class IdentityControllerTest
    {
        [Fact]
        // [ClassData(typeof(SetUps.IdentitySetUp))]
        public async Task Register_WithInvalidModel_ShouldReturnBadRequest()
        {
            //Arrange
            var model = new RegisterRequestModel
            {
                Email = "a",
                Password = "22",
                UserName = "aa"
            };

            var mockAppSetting = new Mock<IOptions<AppSettings>>();
            var mockUserMangager = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(),null, null, null, null, null, null, null, null);

            mockUserMangager
                .Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new IdentityResult()));

            var identityController = new IdentityController(mockUserMangager.Object, mockAppSetting.Object, null);

            //Act
            var result = await identityController.Register(model);

            //Assert

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
