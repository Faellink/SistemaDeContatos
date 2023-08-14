using ControleContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleContatos.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<ContatoModel> Contatos { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
