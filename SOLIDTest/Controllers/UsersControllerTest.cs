using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SOLID.Domain;
using SOLID.Domain.IdValue;
using SOLID.Domain.User;

namespace SOLIDTest.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        private Mock<UserService> _userService = new Mock<UserService>();

        [TestMethod]
        public void ShouldSaveNewUser()
        {
            var newUser = new UserModel() {

                FirstName = "Dummy",
                LastName = "User",
                Email = "Dummy@email.com",
                Password = "secret"
            };

            _userService.Setup(mock => mock.Create(It.IsAny<UserModel>())).Returns(new IdValue<int>(1));

            var controller = new UsersController(_userService.Object);

            var result = controller.Create(newUser);

            Assert.IsNotNull(result.Value);
            Assert.AreEqual(result.Value.Id, 1);
            _userService.Verify(mock => mock.Create(It.IsAny<UserModel>()), Times.Once);
            _userService.VerifyNoOtherCalls();

        }
    }
}
