using Microsoft.EntityFrameworkCore;
namespace RubricaWeb.Models
{
    public class Db : DbContext
    {
        public Db() { }

        protected override void
                OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source=database.db");

        public DbSet<Persona> Persone { get; set; }
        public DbSet<Recapito> Recapiti { get; set; }
    }
}

