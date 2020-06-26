using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskApp.Infrastructure.Services;
using TaskApp.MVC.Models;

namespace TaskApp.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.BrowseAsync();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel user)
        {
            await _userService.AddAsync(user.Firstname, user.Lastname);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int userId)
        {
            var user = await _userService.GetAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteAsync(userId);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserModel user)
        {
            var userdb = await _userService.GetAsync(user.UserId);
            if (userdb == null)
            {
                return NotFound();
            }

            await _userService.UpdateAsync(user.UserId, user.Firstname, user.Lastname);

            return NoContent();
        }

    }
}