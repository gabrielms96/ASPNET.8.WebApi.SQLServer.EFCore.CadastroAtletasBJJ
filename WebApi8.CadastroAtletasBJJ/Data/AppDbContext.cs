using Microsoft.EntityFrameworkCore;
using WebApi8.CadastroAtletasBJJ.Models;

namespace WebApi8.CadastroAtletasBJJ.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        {
        }

        public DbSet<EquipeModel> Equipes { get; set; }
        public DbSet<AtletaModel> Atletas { get; set; }

    }
}
