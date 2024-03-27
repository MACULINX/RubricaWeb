using Microsoft.EntityFrameworkCore;
namespace RubricaWeb.Models
{
public class SQLRubrica : DbContext
    {
        private readonly DbContextOptions? _options;
        public SQLRubrica()
        {
            _DBRubrica = new();
        }

        protected override void 
                OnConfiguring(DbContextOptionsBuilder options)
                => options.UseSqlite("Data Source=/Data/database.db");

        public Rubrica _DBRubrica { get ; set; }
    }
}

