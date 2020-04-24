using JujuControl.Data.Models.dbModels;
using Microsoft.EntityFrameworkCore;

namespace JujuControl.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
