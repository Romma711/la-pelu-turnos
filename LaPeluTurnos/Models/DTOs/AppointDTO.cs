namespace LaPeluTurnos.Models.DTOs
{
    public class AppointDTO
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public string[] Services { get; set; }
        public string Status { get; set; }
    }
}
