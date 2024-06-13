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
    public class ReservationsController : ControllerBase
    {
        private readonly AppsDbContext _context;

        public ReservationsController(AppsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            var table = await _context.Tables.FirstOrDefaultAsync(t => t.Number == reservation.TableNumber && t.Date == reservation.Date && t.Time == reservation.Time);
            if (table != null)
            {
                table.Status = "booked";
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
