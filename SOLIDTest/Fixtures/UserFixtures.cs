using SOLID.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDTest.Fixtures
{
    public class UserFixtures
    {

        public static UserDto GetUserDtoFixtures()
        {
            var userDto = new UserDto();
            userDto.Id = 1;
            userDto.FirstName = "Dummy";
            userDto.LastName = "Dto";
            userDto.Email = "dummy@email.com";

            return userDto;
        }

    }
}
