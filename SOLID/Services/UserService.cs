using SOLID.Context;
using SOLID.Dtos;
using SOLID.Helpers;
using SOLID.Mappers;
using SOLID.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.Services
{
    public class UserService : IService<UserDto, int>
    {
        private readonly SolidDbContext _context;
        private readonly UserMapper Mapper;

        public UserService()
        {
            Mapper = new UserMapper();
        }

        public List<UserDto> FindAll()
        {
            return _context.User
                .Select(user => Mapper.toDto(user))
                .ToList();
        }

        public UserDto FindOne(int id)
        {
            return _context.User
                .Where(user => user.Id.Equals(id))
                .Select(user => Mapper.toDto(user))
                .First();
        }

        public IValue<int> Create(UserDto userDto)
        {
            var user = Mapper.ToEntity(userDto);
            _context.User.Add(user);
            var result = _context.SaveChanges();

            return new IdValue<int>(result);
        }

        public IValue<int> Update(int id, UserDto userDto)
        {
           var userEntity = _context.User
                .Where(user => user.Id.Equals(id))
                .First();

            userEntity = Mapper.ToEntity(userDto);
            var result = _context.Update(userEntity).Entity;

            return new IdValue<int>(result.Id);
        }

        public void Delete(int Id)
        {
            var user = FindOne(Id);
            _context.Remove(user);
        }
    }
}
