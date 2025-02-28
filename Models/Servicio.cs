using System.ComponentModel.DataAnnotations;

namespace ReservaApi.Models
{
    public class Servicio
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
    }
}
