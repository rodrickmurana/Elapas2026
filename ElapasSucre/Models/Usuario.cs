using System.ComponentModel.DataAnnotations;

namespace ElapasSucre.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }
        public string CI_NIT { get; set; }
        public string Direccion { get; set; }
        public int Distrito { get; set; }
        public string Tipo { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
}