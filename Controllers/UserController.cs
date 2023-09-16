using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using StudentProjectManager.Models.auth;
using System.Threading.Tasks;

namespace StudentProjectManager.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // GET api/user/profile
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                return Ok(new UserProfileModel
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Position = user.Position,
                    Capabilities = user.Capabilities,
                    SeniorityLevel = user.SeniorityLevel
                });
            }
            return BadRequest(new { Message = "User not found" });
        }

        // PUT api/user/profile
        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UserProfileModel model)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                user.Email = model.Email;
                user.Position = model.Position;
                user.Capabilities = model.Capabilities;
                user.SeniorityLevel = model.SeniorityLevel;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Ok(new { Message = "Profile updated successfully" });
                }
                return BadRequest(result.Errors);
            }
            return BadRequest(new { Message = "User not found" });
        }
    }

    public class UserProfileModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public List<string> Capabilities { get; set; }
        public SeniorityLevel SeniorityLevel { get; set; } 
    }
}
