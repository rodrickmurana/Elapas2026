using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElapasSucre.Models
{
    public class Medidor
    {
        [Key]
        public int IdMedidor { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public string Codigo { get; set; }

        public string Estado { get; set; } = "ACTIVO";

        // Relación
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
    }
}