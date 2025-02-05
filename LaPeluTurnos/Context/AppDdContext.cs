using Microsoft.EntityFrameworkCore;
using LaPeluTurnos.Models;
namespace LaPeluTurnos.Context
{
    public class AppDdContext: DbContext
    {
        public AppDdContext(DbContextOptions<AppDdContext> options): base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<UserAppoint> UserAppoints { get; set; }
    }
}
