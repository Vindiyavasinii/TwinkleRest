using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TwinkleRestaurant.Models;

namespace TwinkleRestaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly AppsDbContext _context;

        public TablesController(AppsDbContext context)
        {
            _context = context;
        }

        [HttpGet("availability")]
        public async Task<ActionResult<IEnumerable<Table>>> GetTableAvailability([FromQuery] DateTime date, [FromQuery] TimeSpan time)
        {
            var tables = await _context.Tables
                .Where(t => t.Date == date && t.Time == time && t.Status == "available")
                .ToListAsync();

            return tables.Count > 0 ? Ok(tables) : (ActionResult<IEnumerable<Table>>)NotFound(new { message = "No tables available." });
        }
    }
}
