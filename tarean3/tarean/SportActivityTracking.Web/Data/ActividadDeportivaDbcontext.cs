using Microsoft.EntityFrameworkCore;
using SportActivityTracking.Web.Models.Entidad;

namespace SportActivityTracking.Web.Data
{
    public class ActividadDeportivaDbContext : DbContext
    {
        public ActividadDeportivaDbContext()
        {
        }

        public ActividadDeportivaDbContext(DbContextOptions<ActividadDeportivaDbContext> options)
            : base(options)
        {
        }

        public DbSet<ActividadDeportiva> ActividadesDeportivas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}