using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOLID.Dtos;
using SOLID.Mappers;
using SOLID.Models;
using SOLIDTest.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDTest.Mappers
{
    [TestClass]
    public class UserMapperTest
    {
        private IMapper<User, UserDto> _mapper;

        [TestInitialize]
        public void Setup()
        {
            _mapper = new UserMapper();
        }
        
        [TestMethod]
        public void ShouldConvertDtoToEntity()
        {
            var userDto = UserFixtures.GetUserDtoFixtures();

            var userEntity = _mapper.ToEntity(userDto);

            Assert.IsInstanceOfType(userEntity, typeof(User));
            Assert.Equals(userDto.Id, userEntity.Id);
            Assert.Equals(userDto.FirstName, userEntity.FirstName);
            Assert.Equals(userDto.LastName, userEntity.LastName);
            Assert.Equals(userDto.Email, userEntity.Email);
        }
    }
}
