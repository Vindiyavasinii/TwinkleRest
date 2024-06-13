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
    public class adminsController : ControllerBase
    {
        private readonly AppsDbContext _context;

        public adminsController(AppsDbContext context)
        {
            _context = context;
        }

        // GET: api/admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<admin>>> Getadmins()
        {
            return await _context.admins.ToListAsync();
        }

        // GET: api/admins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<admin>> Getadmin(int id)
        {
            var admin = await _context.admins.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        // PUT: api/admins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putadmin(int id, admin admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!adminExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/admins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<admin>> Postadmin(admin admin)
        {
            _context.admins.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getadmin", new { id = admin.Id }, admin);
        }

        // DELETE: api/admins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteadmin(int id)
        {
            var admin = await _context.admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            _context.admins.Remove(admin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool adminExists(int id)
        {
            return _context.admins.Any(e => e.Id == id);
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Email == loginRequest.Email && c.Password == loginRequest.Password);
            if (user == null)
            {
                return BadRequest(ModelState);

            }
            return Ok(new { message = "Login Successful" });

        }
    }
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
