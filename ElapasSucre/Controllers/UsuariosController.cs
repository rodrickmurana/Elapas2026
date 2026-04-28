using Microsoft.AspNetCore.Mvc;
using ElapasSucre.Data;
using ElapasSucre.Models;

namespace ElapasSucre.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ElapasDbContext _context;

        public UsuariosController(ElapasDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Usuarios.ToList());
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }
    }
}