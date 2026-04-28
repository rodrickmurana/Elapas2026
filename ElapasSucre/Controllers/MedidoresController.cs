using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElapasSucre.Data;
using ElapasSucre.Models;

namespace ElapasSucre.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedidoresController : ControllerBase
    {
        private readonly ElapasDbContext _context;

        public MedidoresController(ElapasDbContext context)
        {
            _context = context;
        }

        // GET: api/medidores
        [HttpGet]
        public IActionResult Get()
        {
            var medidores = _context.Medidores
                .Include(m => m.Usuario)
                .ToList();

            return Ok(medidores);
        }

        // POST: api/medidores
        [HttpPost]
        public IActionResult Post(Medidor medidor)
        {
            _context.Medidores.Add(medidor);
            _context.SaveChanges();

            return Ok(medidor);
        }
    }
}