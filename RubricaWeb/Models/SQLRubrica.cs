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

        public void AggiungiPersona(Persona p)
        {
            Persone.Add(p);
            SaveChanges();
        }

        public void RimuoviPersona(List<int> ListPK) 
        {
            foreach (int PK in ListPK) 
            {
                foreach (Persona p in Persone)
                    if (p.PersonaId == PK)
                        Persone.Remove(p);

                foreach (Recapito r in Recapiti)
                    if (r.PersonaId == PK)
                        Recapiti.Remove(r);
            }

            SaveChanges();
        }

        public void AggiungiRecapito(Recapito r)
        {
            Recapiti.Add(r);
            SaveChanges();
        }
    }
}

