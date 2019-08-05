using Microsoft.AspNetCore.Mvc;
using SOLID.Context;
using SOLID.Dtos;
using SOLID.Helpers;
using SOLID.Mappers;
using SOLID.Services;
using System.Collections.Generic;
using System.Linq;

namespace SOLID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        //private UserService _userService;

        //public UsersController(UserService service)
        //{
        //    _userService = service;
        //}

        private SolidDbContext _context;
        private UserMapper Mapper;


        public UsersController(SolidDbContext context)
        {
            _context = context;
            Mapper = new UserMapper();
        }

        [HttpGet]
        public ActionResult<List<UserDto>> FindAll()
        {
            return _context.User
                .Select(user => Mapper.ToDto(user))
                .ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> FindOne(int id)
        {
            return _context.User
                .Where(user => user.Id.Equals(id))
                .Select(user => Mapper.ToDto(user))
                .First();
        }

        [HttpPost]
        public ActionResult<IValue<int>> Create([FromBody] UserDto userDto)
        {
            var user = Mapper.ToEntity(userDto);
            _context.User.Add(user);
            var result = _context.SaveChanges();

            return new IdValue<int>(result);
        }

        [HttpPut("{id}")]
        public ActionResult<IValue<int>> Put(int id, [FromBody] UserDto userDto)
        {
            var userEntity = _context.User
                .Where(user => user.Id.Equals(id))
                .First();

            userEntity = Mapper.ToEntity(userDto);
            var result = _context.Update(userEntity).Entity;

            return new IdValue<int>(result.Id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = FindOne(id);
            _context.Remove(user);
        }
    }
}
