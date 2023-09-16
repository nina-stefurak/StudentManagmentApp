using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentProjectManager.Models.auth;
using System.Threading.Tasks;

namespace StudentProjectManager.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET api/users
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userManager.Users;
            return Ok(users);
        }

        // GET api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound(new { Message = "User not found" });
        }

        // PUT api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] ApplicationUser user)
        {
            if (user == null)
            {
                return BadRequest(new { Message = "Invalid user data" });
            }
            var existingUser = await _userManager.FindByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound(new { Message = "User not found" });
            }

            existingUser.Email = user.Email;
            existingUser.Position = user.Position;
            existingUser.Capabilities = user.Capabilities;
            existingUser.SeniorityLevel = user.SeniorityLevel;

            var result = await _userManager.UpdateAsync(existingUser);
            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest(new { Message = "Error updating user", Errors = result.Errors });
        }

        // DELETE api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = "User not found" });
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest(new { Message = "Error deleting user", Errors = result.Errors });
        }
    }
}
