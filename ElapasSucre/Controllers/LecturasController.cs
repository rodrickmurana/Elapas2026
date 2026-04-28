using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElapasSucre.Data;
using ElapasSucre.Models;

namespace ElapasSucre.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LecturasController : ControllerBase
    {
        private readonly ElapasDbContext _context;

        public LecturasController(ElapasDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult RegistrarLectura(Lectura nuevaLectura)
        {
            // 🔎 Buscar última lectura
            var ultimaLectura = _context.Lecturas
                .Where(l => l.IdMedidor == nuevaLectura.IdMedidor)
                .OrderByDescending(l => l.Fecha)
                .FirstOrDefault();

            decimal consumo = 0;

            if (ultimaLectura != null)
            {
                consumo = nuevaLectura.LecturaActual - ultimaLectura.LecturaActual;

                if (consumo < 0)
                    return BadRequest("Lectura inválida (menor a la anterior)");
            }

            // 💰 Cálculo simple (luego lo mejoramos con tarifas)
            decimal precioPorM3 = 3;
            decimal monto = consumo * precioPorM3;

            // 🔎 Obtener usuario desde medidor
            var medidor = _context.Medidores
                .FirstOrDefault(m => m.IdMedidor == nuevaLectura.IdMedidor);

            if (medidor == null)
                return BadRequest("Medidor no existe");

            // 🧾 Crear factura
            var factura = new Factura
            {
                IdUsuario = medidor.IdUsuario,
                Periodo = DateTime.Now.ToString("yyyy-MM"),
                Consumo = consumo,
                Monto = monto
            };

            // 💾 Guardar todo
            _context.Lecturas.Add(nuevaLectura);
            _context.Facturas.Add(factura);
            _context.SaveChanges();

            return Ok(new
            {
                mensaje = "Lectura registrada y factura generada",
                consumo,
                monto
            });
        }
    }
}