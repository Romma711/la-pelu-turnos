using LaPeluTurnos.Context;
using LaPeluTurnos.Models;
using LaPeluTurnos.Models.DTOs;

namespace LaPeluTurnos.Services.Security
{
    public class AuthService
    {
        private readonly AppDdContext _context;
        private readonly JWTService _jwtService;

        public AuthService(AppDdContext context, JWTService jwtservice)
        {
            _context = context;
            _jwtService = jwtservice;
        }

        public async Task<User?> RegisterService(RegisterDTO request)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new User { Username = request.Username, Email = request.Email, Password = hashedPassword, Phone = request.Phone };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<string?> Loginservice(LoginDTO request)
        {
            var user = new User();
            try
            {
                user = _context.Users.SingleOrDefault(u => u.Email == request.Email);
            }
            catch (ArgumentException ex) { return "Invalid arguments"; }
            catch (InvalidOperationException ex) { return "Invalid arguments"; }
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return null;
            }

            return _jwtService.GenerateJWToken(user);    //Enviar el JWT Generado
        }

    }
}
