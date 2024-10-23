using WebRoster.Models;
using WebRoster.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.AspNetCore.Http;
namespace WebRoster.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller{
    private readonly IUserService _userService;

    public UserController(IUserService userService) {
        this._userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers() {
        try {
            return Ok(await _userService.GetAllUsersAsync());
        }
        catch{
            return BadRequest();
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id) {
        try {
            User user = await _userService.GetUserByIdAsync(id);
            if (user is null) {
                return NotFound();
            }
            return Ok(user);
        }
        catch {
            return BadRequest();
        }
    }
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] User user){
        try {
            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new {id = user.ID}, user);
        }
        catch {
            return BadRequest();
        }
    }
    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] User user){
        try {
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }
        catch {
            return BadRequest();
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id){
        try{
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
        catch{
            return BadRequest();
        }
    }
}
