﻿namespace LaPeluTurnos.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int EstadoId {  get; set; }
    }
}
