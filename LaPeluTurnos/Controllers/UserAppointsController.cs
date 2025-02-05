using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaPeluTurnos.Context;
using LaPeluTurnos.Models;

namespace LaPeluTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAppointsController : ControllerBase
    {
        private readonly AppDdContext _context;

        public UserAppointsController(AppDdContext context)
        {
            _context = context;
        }

        // GET: api/UserAppoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAppoint>>> GetUserAppoint()
        {
            return await _context.UserAppoints.ToListAsync();
        }

        // GET: api/UserAppoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAppoint>> GetUserAppoint(int id)
        {
            var userAppoint = await _context.UserAppoints.FindAsync(id);

            if (userAppoint == null)
            {
                return NotFound();
            }

            return userAppoint;
        }

        // PUT: api/UserAppoints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAppoint(int id, UserAppoint userAppoint)
        {
            if (id != userAppoint.Id)
            {
                return BadRequest();
            }

            _context.Entry(userAppoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAppointExists(id))
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

        // POST: api/UserAppoints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserAppoint>> PostUserAppoint(UserAppoint userAppoint)
        {
            _context.UserAppoints.Add(userAppoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserAppoint", new { id = userAppoint.Id }, userAppoint);
        }

        // DELETE: api/UserAppoints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAppoint(int id)
        {
            var userAppoint = await _context.UserAppoints.FindAsync(id);
            if (userAppoint == null)
            {
                return NotFound();
            }

            _context.UserAppoints.Remove(userAppoint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserAppointExists(int id)
        {
            return _context.UserAppoints.Any(e => e.Id == id);
        }
    }
}
