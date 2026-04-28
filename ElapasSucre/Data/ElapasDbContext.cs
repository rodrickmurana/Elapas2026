using ElapasSucre.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ElapasSucre.Data
{
    public class ElapasDbContext : DbContext
    {
        public ElapasDbContext(DbContextOptions<ElapasDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Medidor> Medidores { get; set; }
        public DbSet<Lectura> Lecturas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
    }
}