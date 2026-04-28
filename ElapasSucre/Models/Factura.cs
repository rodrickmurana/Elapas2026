using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElapasSucre.Models
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }

        public int IdUsuario { get; set; }

        public string Periodo { get; set; }

        public decimal Consumo { get; set; }

        public decimal Monto { get; set; }

        public string Estado { get; set; } = "PENDIENTE";

        public DateTime FechaEmision { get; set; } = DateTime.Now;

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
    }
}