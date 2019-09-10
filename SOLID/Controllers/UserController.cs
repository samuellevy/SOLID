using Microsoft.AspNetCore.Mvc;
using SOLID.Models.User;
using SOLID.ObjectValues.IdValue;
using SOLID.Services.User;
using System.Collections.Generic;

namespace SOLID.Domain.User
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
      
        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet]
        public ActionResult<List<UserModel>> FindAll()
        {
            return _userService.FindAll();
        }

        [HttpGet("{id}")]
        public ActionResult<UserModel> FindOne(int id)
        {
            return _userService.FindOne(id);
        }

        [HttpPost]
        public ActionResult<IValue<int>> Create([FromBody] UserModel user)
        {
            var result = _userService.Create(user);
            return result;
        }

        [HttpPut("{id}")]
        public virtual ActionResult<IValue<int>> Update(int id, [FromBody] UserModel user)
        {
            return _userService.Update(id, user);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
           var isDeleted = _userService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
