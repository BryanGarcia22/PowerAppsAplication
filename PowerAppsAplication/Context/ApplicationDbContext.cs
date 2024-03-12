using PowerAppsAplication.Models;
using Microsoft.EntityFrameworkCore;

namespace PowerAppsAplication.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}
        public DbSet<Equipos> Equipos { get; set; }
        public DbSet<HistoricoEquipos> HistoricoEquipos { get; set; }

    }
}
