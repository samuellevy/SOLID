using SOLID.Dtos;
using SOLID.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.Mappers
{
    public class UserMapper : IMapper<User, UserDto>
    {
        public UserDto toDto(User entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Password = entity.Password,
                Address = entity.Address,
                Number = entity.Number,
                City = entity.City,
                PostalCode = entity.PostalCode
            };
    }

        public User ToEntity(UserDto dto)
        {
            return new User
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                Address = dto.Address,
                Number = dto.Number,
                City = dto.City,
                PostalCode = dto.PostalCode
            };
        }
    }
}
