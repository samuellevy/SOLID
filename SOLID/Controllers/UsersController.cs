using Microsoft.AspNetCore.Mvc;
using SOLID.Dtos;
using SOLID.Helpers;
using SOLID.Services;
using System.Collections.Generic;

namespace SOLID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IService<UserDto, int> _userService;

        public UsersController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        public ActionResult<List<UserDto>> FindAll()
        {
            return _userService.FindAll();
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> FindOne(int id)
        {
            return _userService.FindOne(id);
        }

        [HttpPost]
        public ActionResult<IValue<int>> Create([FromBody] UserDto userDto)
        {
            return new ActionResult<IValue<int>>(_userService.Create(userDto));
        }

        [HttpPut("{id}")]
        public ActionResult<IValue<int>> Put(int id, [FromBody] UserDto userDto)
        {
            return new ActionResult<IValue<int>>(_userService.Update(id, userDto));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }
    }
}
