using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwinkleRestaurant.Models;

namespace TwinkleRestaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppsDbContext _context;

        public UsersController(AppsDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                return BadRequest("Email is already in use.");
            }

            // Hash the password before saving it (implement password hashing as needed)
            // user.Password = HashPassword(user.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(new { message = "User registered successfully" });
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginRequest loginRequest)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Email == loginRequest.Email && c.Password == loginRequest.Password);
            if (user == null)
            {
                return BadRequest(ModelState);

            }
            return Ok(new { message = "Login Successful" });

        }

    }
    public class UserLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}




