using System.ComponentModel.DataAnnotations;

namespace ReservaApi.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        [Required]
        public string Cliente { get; set; }

        [Required]
        public string Servicio { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string Horario { get; set; }
    }
}
