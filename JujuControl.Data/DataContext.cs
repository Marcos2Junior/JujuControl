using JujuControl.Data.Models.dbModels;
using Microsoft.EntityFrameworkCore;

namespace JujuControl.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
        public DbSet<ExceptionFull> ExceptionFull { get; set; }
    }
}
