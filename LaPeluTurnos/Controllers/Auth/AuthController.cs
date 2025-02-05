using LaPeluTurnos.Context;
using LaPeluTurnos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaPeluTurnos.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDdContext _context;

        public AuthController(AppDdContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<User>> LoginUser(User user)
        {

            var found =await _context.Users.FindAsync(keyValues: user);
            if (found == null) {
                return NotFound();
            }


        }
    }
}
