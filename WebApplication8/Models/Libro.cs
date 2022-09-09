using System.ComponentModel.DataAnnotations;

namespace WebApplication8.Models
{
    public class Libro
    {
        public int LibroId { get; set; }
        public string? LibroName { get; set; }
        public DateTime FechaAgregado { get; set; }

    }
}
