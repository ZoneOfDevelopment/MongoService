using Microsoft.AspNetCore.Mvc;
using MongoService.Model.Entities;
using MongoService.Service;
using System.Collections.Generic;

namespace MongoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAllUser() => _userService.GetAllUsers();

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> GetUserById(string id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> AddUser(User user)
        {
            _userService.AddUser(user);

            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, User userInput)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.UpdateUser(id, userInput);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.RemoveUser(user.Id);

            return NoContent();
        }
    }
}
