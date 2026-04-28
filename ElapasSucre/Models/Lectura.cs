using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElapasSucre.Models
{
    public class Lectura
    {
        [Key]
        public int IdLectura { get; set; }

        [Required]
        public int IdMedidor { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public decimal LecturaActual { get; set; }

        public string? FotoURL { get; set; }
        public string? GPS { get; set; }
        public string? UsuarioTecnico { get; set; }

        [ForeignKey("IdMedidor")]
        public Medidor Medidor { get; set; }
    }
}