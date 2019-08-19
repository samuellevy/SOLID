using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SOLID.Domain.IdValue;
using SOLID.Domain.User;
using System.Collections.Generic;

namespace SOLIDTest.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        private Mock<UserService> _userService = new Mock<UserService>(null);

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

            var controller = new UserController(_userService.Object);

            var result = controller.Create(newUser);

            Assert.IsNotNull(result.Value);
            Assert.AreEqual(result.Value.Id, 1);
            _userService.Verify(mock => mock.Create(It.IsAny<UserModel>()), Times.Once);
            _userService.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void ShouldFindAllUsers()
        {
            List<UserModel> users = new List<UserModel>();

            _userService.Setup(mock => mock.FindAll()).Returns(users);

            var controller = new UserController(_userService.Object);

            var result = controller.FindAll();

            _userService.Verify(mock => mock.FindAll());
            _userService.VerifyNoOtherCalls();
        }

        [TestMethod]
        [DataRow(1)]
        public void ShouldFindOneUser(int id)
        {
            var user = new UserModel()
            {
                Id = id,
                FirstName = "Dummy",
                LastName = "User",
                Email = "Dummy@email.com",
                Password = "secret"
            };

            _userService.Setup(mock => mock.FindOne(id)).Returns(user);

            var controller = new UserController(_userService.Object);

            var result = controller.FindOne(id);

            Assert.IsNotNull(result.Value);
            _userService.Verify(mock => mock.FindOne(id));
            _userService.VerifyNoOtherCalls();
        }

        [TestMethod]
        [DataRow(1)]
        public void ShouldUpdateUser(int id)
        {
            var user = new UserModel()
            {
                Id = id,
                FirstName = "Dummy",
                LastName = "User",
                Email = "Dummy@email.com",
                Password = "secret"
            };

            _userService.Setup(mock => mock.Update(id, user)).Returns(new IdValue<int>(1));

            var controller = new UserController(_userService.Object);

            var result = controller.Update(id, user);

            Assert.IsNotNull(result.Value);
            _userService.Verify(mock => mock.Update(id, user));
            _userService.VerifyNoOtherCalls();
        }
    }
}
